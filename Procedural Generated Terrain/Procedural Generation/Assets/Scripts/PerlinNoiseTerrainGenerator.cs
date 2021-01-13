// Written by Oliver Blackwell
// Created on : 20 / 11 / 2020
// Last edited : 07 / 12 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <Summary>
// This contains the terrain generator, using perlin noise and
// octave offsets to allow the world to seem more endless
public class PerlinNoiseTerrainGenerator : MonoBehaviour {
    // Depth of noise
    [SerializeField] int depth = 20;
    // Size of the Terrain
    private int width = 256;
    private int height = 256;
    // Scale of terrian (Lower Scale, Less Noise)
    [SerializeField] float scale = 20f;
    // Map Offsetts
    public float offsetX = 100f;
    public float offsetY = 100f;

    // Update is called once per frame
    private void Update() {
        // This can be used to generate new terrain
        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    offsetX = Random.Range(0, 999f);
        //    offsetY = Random.Range(0, 999f);
        //}

        // THIS IS IN UPDATE SO THAT THE MOVEMENT OF THE PLAYER CAN WORK
        // Creating a local variable of the Terrain and accessing its terrain data.
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = MakeTerrainData(terrain.terrainData);
    }

    // <Summary>
    // This returns a new TerrainData for the terrain within our scene
    TerrainData MakeTerrainData(TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);
        // This uses the height map which has been created, and sets the heights for the terrain to those heights
        // doing this turns the 2D heightmap into 3D on the terrain
        terrainData.SetHeights(0, 0, GenerateHeightmap());
        return terrainData;
    }

    // <Summary>
    // This returns a height map (float array) which is used to set the heights for the terrain data
    // This has to be a float array due to the Set Heights function in terrain data needing a float array
    float[,] GenerateHeightmap() {
        // creating a local float array for the height map and initialising it to the width and height of the terrain
        float[,] heights = new float[width, height];
        // then this multi-dimensional loop, loops through the array and sets the heights for each co-ordinate of the terrain
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heights[x, y] = CalculateHeights(x, y);
            }
        }
        return heights;
    }

    // <Summary>
    // This returns each Perlin Noise value off of the Perlin Noise Map
    // to represent each x and y value within the height map
    float CalculateHeights(int x, int y) {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
