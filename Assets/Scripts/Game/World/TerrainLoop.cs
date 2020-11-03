﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainLoop : MonoBehaviour
{
    public GameObject camera;

    public float offsetRight = 0;
    public int countOfPrefabs = 2;

    private float x1;
    private float x2;
    private float width;
    private float height;
    private int countOfNodes = 1;

    private void Start()
    {
        height = camera.GetComponent<Camera>().orthographicSize * 2;
        width = camera.GetComponent<Camera>().aspect * height;

        x1 = transform.position.x;

        updateEdgesCoordinates();
    }

    void Update()
    {
        if (camera.transform.position.x + (width / 2) > x2 - 4)
        {
            generateNextNodes();
            updateEdgesCoordinates();
        }

        if (camera.transform.position.x > (x1 + 100))
        {
            removeLeftNode();
        }
    }

    void generateNextNodes()
    {
        int nextNodeNumber = Random.Range(1, countOfPrefabs + 1);

        GameObject nextNode = Instantiate(
            Resources.Load("prefabs/Terrain/Node" + nextNodeNumber),
            new Vector3(x2, transform.position.y, transform.position.z),
            Quaternion.identity
        ) as GameObject;

        countOfNodes = countOfNodes + 1;

        nextNode.transform.SetParent(transform);

        nextNode.name = "Node" + countOfNodes;

        int setupNumber = Random.Range(1, 4);

        if (setupNumber < 4)
        {
            //nextNode.transform.Find("Setup" + setupNumber).gameObject.active = true;
        }
    }

    void removeLeftNode()
    {
        GameObject leftTerrainNode = transform.GetChild(0).gameObject;

        float nodeWidth = calculateTerrainNodeWidth(leftTerrainNode) - offsetRight;

        Destroy(leftTerrainNode);

        x1 = x1 + (nodeWidth);
    }

    float calculateTerrainNodeWidth(GameObject terrain)
    {
        SpriteShapeController spriteShapeController = terrain.GetComponent<SpriteShapeController>();

        float minX = 0;
        float maxX = 0;

        for (int i = 0; i < spriteShapeController.spline.GetPointCount(); i++)
        {
            Vector3 pos = spriteShapeController.spline.GetPosition(i);
            if (pos.x > maxX)
            {
                maxX = pos.x;
            }
            if (pos.x < minX)
            {
                minX = pos.x;
            }
        }

        return maxX - minX;
    }

    void updateEdgesCoordinates()
    {
        GameObject terrainNode = transform.GetChild(transform.childCount - 1).gameObject;

        float terrainWidth = calculateTerrainNodeWidth(terrainNode);

        Debug.Log(terrainWidth);

        if (countOfNodes > 1)
        {
            x2 = x2 + terrainWidth + offsetRight;
        }
        else
        {
            x2 = x1 + terrainWidth + offsetRight;
        }
    }

}
