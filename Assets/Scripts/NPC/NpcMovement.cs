﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NpcMovement : MonoBehaviour {

    [SerializeField]
    Tilemap walls;

    [SerializeField]
    float MovementSpeed = 5f;

    [SerializeField]
    float approximationField = 0.05f;

    [SerializeField]
    int searchRadius = 1;

    Vector3 targetPosition;
    bool movingTowardsPosition = false;

	// Use this for initialization
	void Start ()
    {
    }

    private void FindOpenPositions()
    {
        Vector3Int cellPos = walls.WorldToCell(transform.position);

        List<Vector3> movablePositions = new List<Vector3>();

        // search around for walls
        for (int x = -searchRadius; x <= searchRadius; x++)
        {
            for (int y = -searchRadius; y <= searchRadius; y++)
            {
                if (x == 0 && y == 0) continue;

                var temp = new Vector3Int(cellPos.x + x, cellPos.y + y, cellPos.z);
                // IF there isnt a wall here add it to the list of potential next positions
                if (!walls.GetTile(temp))
                {
                    movablePositions.Add(walls.CellToWorld(temp));
                }

            }
        }

        // Have the list, choose randomly for the next position. 
        targetPosition = movablePositions[Random.Range(0, movablePositions.Count - 1)];

        movingTowardsPosition = true;
    }

    // Update is called once per frame
    void LateUpdate () {
	
        if(movingTowardsPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed * Time.deltaTime);

            // if its close enough move on 
            if ((transform.position - targetPosition).magnitude < approximationField)
            {
                movingTowardsPosition = false;
            }
        }
        else
        {
            FindOpenPositions();

        }
    }
}