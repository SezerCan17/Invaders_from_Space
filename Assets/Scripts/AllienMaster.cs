using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AllienMaster : MonoBehaviour
{
    public GameObject bulletPrefabs;

    private Vector3 hMoveDistance = new Vector3 (0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);

    private const float MAX_LEFT = -2f;
    private const float MAX_RIGHT = 2f;

    public static List<GameObject>allAlliens = new List<GameObject>();

    private bool movingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private const float MAX_MOVE_SPEED = 0.02f;

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Allien"))
        {
            allAlliens.Add(go);
        }
    }

    
    void Update()
    {
        if(moveTimer<=0)
        {
            MoveEnemies();

        }
        moveTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        int hitMax = 0;
        if(allAlliens.Count > 0)
        {
            for(int i = 0; i < allAlliens.Count; i++)
            {
                if (movingRight)
                {
                    allAlliens[i].transform.position += hMoveDistance;

                }
                else
                {
                    allAlliens[i].transform.position -= hMoveDistance;
                }
                if (allAlliens[i].transform.position.x> MAX_RIGHT || allAlliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }
            if(hitMax > 0)
            {
                for(int i=0; i< allAlliens.Count; i++)
                {
                    allAlliens[i].transform.position -= vMoveDistance;
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    private float GetMoveSpeed()
    {
        float f = allAlliens.Count * moveTime;

        if (f< MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }

        
    }
}



