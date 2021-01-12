#include<stdafx.h>
#include "rc_player.h"
#include "rc_inputManager.h"
#include "rc_level.h"

Player::Player() : m_dirX(1.f), m_dirY(0.f), m_posX(2.f), m_posY(3.5f)
{
	float nearPlaneDistance = 1.f;
	m_nearPlaneLength = tanf(HALF_FOV * (float)(PI / 180.f)) * nearPlaneDistance;
}

Player::~Player()
{
}

void Player::Update(float a_fDT, Level* m_pLevel)
{
	// Process Player movement
	if (InputManager::GetInstance()->GetKeyDown('W')) 
	{
		m_posX += 2.f * m_dirX * a_fDT;
		m_posY += 2.f * m_dirY * a_fDT;
	}
	if (InputManager::GetInstance()->GetKeyDown('S'))
	{
		m_posX -= 2.f * m_dirX * a_fDT;
		m_posY -= 2.f * m_dirY * a_fDT;
	}

	// Player rotation
	if (InputManager::GetInstance()->GetKeyDown('A'))
	{
		// both camera direction and camera plane must be rotated
		float playerRotSpeed = -1.f * a_fDT;
		float oldDirX = m_dirX;
		m_dirX = oldDirX * cosf(playerRotSpeed) - m_dirY * sin(playerRotSpeed);
		m_dirY = oldDirX * sin(playerRotSpeed) + m_dirY * cos(playerRotSpeed);
	}
	if (InputManager::GetInstance()->GetKeyDown('D'))
	{
		// both camera direction and camera plane must be rotated
		float playerRotSpeed = 1.f * a_fDT;
		float oldDirX = m_dirX;
		m_dirX = oldDirX * cosf(playerRotSpeed) - m_dirY * sin(playerRotSpeed);
		m_dirY = oldDirX * sin(playerRotSpeed) + m_dirY * cos(playerRotSpeed);
	}

	if (m_posX >= 6.0f || m_posY >= 6.0f)
	{
		// Here i am loading in a second level 
		m_pLevel->LoadLevel("../resources/secondLevel.map");
		// i am setting the position of the player on the map
		m_posX = 1;
		m_posY = 4;
		//m_pLevel->Draw(this);
	}
}

// This function can be called to set the player position outside of the Player class
void Player::SetPosition(float a_x, float a_y)
{
	m_posX = a_x; m_posY = a_y;
}

// This function is used to get the players location in world space
void Player::GetPosition(float& a_x, float& a_y) const
{
	a_x = m_posX; a_y = m_posY;
}
// This function can be called to set the player rotation outside of the Player class
void Player::SetRotation(float a_degrees)
{
	float radians = a_degrees * (float)(PI / 180.f);
	m_dirX = 1.f * cosf(radians);
	m_dirY = 1.f * sin(radians);

}
// This function is used to get the players rotation in world space
void Player::GetRotation(float& a_x, float& a_y) const
{
	a_x = m_dirX; a_y = m_dirY;
}
