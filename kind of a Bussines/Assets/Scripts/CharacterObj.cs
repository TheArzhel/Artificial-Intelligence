using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterObj : MonoBehaviour
{
    NavMeshPath path;
    Move move;
    SteeringSeek seek;
    SteeringFollowPath FollowPath;
    
    public float min_Distance = 0.1f;
    public float slow_Distance = 0.5f;


   
    private bool taskDone = false;
    Vector3 nextPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        path = new NavMeshPath();
        FollowPath = GetComponent<SteeringFollowPath>();
        NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: charactes behaviour");

        if (!taskDone)
        {
            taskDone = FollowPath.Steer(path);
        }
        else
        {
            move.current_velocity = Vector3.zero;

            move.current_rotation_speed = 0;

            move.max_mov_acceleration = 0;

            move.max_mov_speed= 0;
        }

      
        }

        
    }


