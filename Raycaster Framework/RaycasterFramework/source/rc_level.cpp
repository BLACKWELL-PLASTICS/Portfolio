#include <stdafx.h>
#include "rc_level.h"
#include "rc_renderer.h"
#include "rc_player.h"
#include "rc_texture.h"
#include "rc_textureManager.h"
#include "rc_imageLoader.h"
#include "rc_pcxLoader.h"

Level::Level() : m_width (0), m_height(0), m_map(nullptr), m_texMan(nullptr), m_texture(nullptr)
{
}

Level::~Level()
{
	// If the map isnt null
	if (m_map != nullptr)
	{
		// Delete the map
		delete[] m_map;
		// Make the map null
		m_map = nullptr;	
	}
}

void Level::GetSize(u32& a_w, u32& a_h)
{
	a_w = m_width;
	a_h = m_height;
}

u8 Level::GetGridValue(u32 a_x, u32 a_y)
{
	u32 index = a_x + (a_y * m_width);
	if (index < (m_width * m_height))
	{
		return m_map[index];
	}
	return 255; // values of 255 will indicate a map out of bounds error
}

bool Level::LoadLevel(const char* a_filename)
{
	// When we Load the Level, i load all of the textures which are being used into the Texture Manager
	m_texMan->LoadTexture("../resources/images/BRICKS.PCX", RC_ImageType::IM_PCX);
	m_texMan->LoadTexture("../resources/images/DOOR.PCX", RC_ImageType::IM_PCX);
	m_texMan->LoadTexture("../resources/images/STONES.PCX", RC_ImageType::IM_PCX);

	// We are going to load a level if the map is not null then we need to delete it and free up memory
	// then open the file and load in the level data
	if (m_map != nullptr)
	{
		delete[] m_map;
		m_map = nullptr;
	}
	std::fstream file;
	file.open(a_filename, std::ios_base::in | std::ios_base::binary);
	// test to see if the file has opened in correctly
	if (file.is_open())
	{
		// success file has been opened, verify contents of file
		file.ignore(std::numeric_limits<std::streamsize>::max());
		std::streamsize fileSize = file.gcount();
		file.clear();
		file.seekg(0, std::ios_base::beg);
		if (fileSize == 0)
		{
			file.close();
			return false;
		}
		// read in the width and height of the level map
		file >> m_width >> m_height;
		file.ignore(1); // ignore end of line marker
		//allocate memory to hold all map data
		m_map = new u8[m_width * m_height];
		u32 index = 0;
		// read each line of the file to get one row worth of map data
		// Use getl;ine to read in a each line of the file
		for (std::string currentMapLine; std::getline(file, currentMapLine);)
		{
			// convert string from getline into stringstream and use comma seperator to break into chunks and store values in map
			std::istringstream ss{ currentMapLine };
			int val = 0;
			while (ss >> val)
			{
				// when parsing store as int valye tempotatily then static cast to u8 otherwaise we read values as char! car value of 0 is 48
				m_map[index] = (u8)(val);
				++index;
				if ((ss >> std::ws).peek() == ',') // std:: ws ignors white space, if the next char is a comma ignore it too
				{
					ss.ignore();
				}
			}
		}
		// always close filestream
		file.close();
		return true;
	}

	return false;
}

// the level knows how to draw itself
void Level::Draw(const Player* a_player)
{
	// Get the instance of the renderer to get the dimensions of the reder window
	Renderer* renderer = Renderer::GetInstance();

	u32 windowWidth = 0, windowHeight = 0;
	renderer->GetWindowSize(windowWidth, windowHeight);

	// from the passed in pointer to the player get the current position and the direction of the player
	float playerPosX = 0.f, playerPosY = 0.f;
	a_player->GetPosition(playerPosX, playerPosY);
	float playerDirX = 0.f, playerDirY = 0.f;
	a_player->GetRotation(playerDirX, playerDirY);
	float nearPlaneLength = a_player->GetNearPlaneLength();

	// Camera plane is perpendicular to player direction
	// swap components and negate y
	// multiply by near plane length to get vector to right length
	float camPlaneX = -playerDirY * nearPlaneLength;
	float camPlaneY = playerDirX * nearPlaneLength;

	for (u32 c = 0; c < windowWidth; c++) // c represents which screen column we are examining
	{
		// Get the x position as a value between -1 and 1
		float cameraX = ((2.f * c) / (float)windowWidth) - 1.f;
		float rayDirX = playerDirX + (camPlaneX * cameraX);
		float rayDirY = playerDirY + (camPlaneY * cameraX);
		// Length of ray from on X/Y side to next X/Y side
		float deltaDisX = (rayDirX != 0.f) ? std::abs(1.f / rayDirX) : 0;
		float deltaDisY = (rayDirY != 0.f) ? std::abs(1.f / rayDirY) : 0;

		// Players current grid position
		int mapX = (int)(playerPosX);
		int mapY = (int)(playerPosY);

		// Length of ray from current position to next x/y side
		float sideDistX = 0.f;
		float sideDistY = 0.f;

		float perpWallDist = 0.f;

		// Direction to step in x/y +-1
		int stepX = 0;
		int stepY = 0;

		int collision = 0;
		if (rayDirX < 0)
		{
			stepX = -1;
			sideDistX = (playerPosX - mapX) * deltaDisX;
		}
		else
		{
			stepX = 1;
			sideDistX = (mapX + 1.f - playerPosX) * deltaDisX;
		}
		// do the same for y direction of the ray
		if (rayDirY < 0)
		{
			stepY = -1;
			sideDistY = (playerPosY - mapY) * deltaDisY;
		}
		else
		{
			stepY = 1;
			sideDistY = (mapY + 1.f - playerPosY) * deltaDisY;
		}
		// Value to track whether we have hit a north/south wall or an east west wall
		int	yIntersection = 0;
		// loop through our ray cast incrementing along the ray by an interval by an interval and test to see if a collision with a non-blank tile
		while (collision == 0)
		{
			// jump to next map square in x or y direction 
			if (sideDistX < sideDistY)
			{
				sideDistX += deltaDisX;
				mapX += stepX;
				yIntersection = 0;
			}
			else
			{
				sideDistY += deltaDisY;
				mapY += stepY;
				yIntersection = 1;
			}
			// test current map location for a collision (tile values that are non zero indicate a wall or non empty tile)
			collision = m_map[(mapX + (mapY * m_width))];
		}
		// We have collided our raycast with a wall
		perpWallDist = (!yIntersection) ?
			(mapX - playerPosX + (1 - stepX) / 2.f) / rayDirX :
			(mapY - playerPosY + (1 - stepY) / 2.f) / rayDirY;

		// Calculate height of line to draw
		s32 lineHeight = (int)(windowHeight / perpWallDist);
		// Calculate upper lower points to draw
		u32 drawingStart = -lineHeight / 2 + windowHeight / 2;
		if (drawingStart < 0)
		{
			// If drawingStart is smaller than 0 
			// Set drawingStart to 0
			drawingStart = 0;
		}
		u32 drawingEnd = lineHeight / 2 + windowHeight / 2;
		if (drawingEnd >= windowHeight)
		{
			// If drawingEnd is bigger than or equal to windowHeight
			// Set the drawingEnd to the windowHeight - 1
			drawingEnd = windowHeight - 1;
		}

		u32 texWidth = 0;
		u32 texHeight = 0;
		if (collision == 1)
		{
			// If the wall collision number is 1, use Bricks as the texture
			m_texture = m_texMan->GetTexture("../resources/images/BRICKS.PCX");
		}	
		if (collision == 2)
		{
			// If the wall collision number is 2, use Stones as the texture
			m_texture = m_texMan->GetTexture("../resources/images/STONES.PCX");
		}
		if (collision == 3)
		{
			// If the wall collision number is 3, use Door as the texture
			m_texture = m_texMan->GetTexture("../resources/images/DOOR.PCX");
		}
		// Get the texture dimensions
		m_texture->GetDimensions(texWidth, texHeight);

		double wallX; // exactly where the wall was hit
		if (yIntersection == 0)
		{
			wallX = playerPosX + perpWallDist * rayDirY;
		}
		else
		{
			wallX = playerPosX + perpWallDist * rayDirX;
		}
		wallX -= floor((wallX));

		 int texX = int(wallX * double(texWidth));
		if (yIntersection == 0 && rayDirX > 0)
		{
			texX = texWidth - texX - 1;
		}
		if (yIntersection == 1 && rayDirY < 0)
		{
			texX = texWidth - texX - 1;
		}

		double step = 1.0 * texHeight / lineHeight;
		// Before we calculate the data to use to fill the render buffer
		// Get the Pixel Data and store it in this unsigned int pointer
		unsigned int* rawTextureData = (unsigned int*)m_texture->GetPixelData();
		double texPosition = (drawingStart - windowHeight / 2 + lineHeight / 2) * step;

		// Here we are looping through the pixels and columns and filling the render buffer with the specific pixel data
		for (u32 i = drawingStart; i < drawingEnd; i++)
		{
			int texY = (int)texPosition & (texHeight - 1);
			texPosition += step;
			u32 data = rawTextureData[texWidth * texY + texX];
			if (yIntersection == 1)
			{
				data = (data >> 1) & 8355711;
			}
			// Fill the render buffer using the data calculating at the specific pixels to fill them with the texture data
			renderer->FillRenderBuffer(c, i,1, 1, data);
		}
	}
}
