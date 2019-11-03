using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State
{
    WAIT, 
    LOOKTABLE
}

public class CharacterObj : MonoBehaviour
{
    NavMeshPath path;
    Move move;
    SteeringSeek seek;
    SteeringFollowPath FollowPath;
    
    public LayerMask mask;


    public float min_Distance = 0.1f;
    public float slow_Distance = 0.5f;

    public List<GameObject> TableList;

    Table tableScript;
    State action = State.WAIT;
    private GameObject Objective;

    private bool taskDone = false;
    Vector3 nextPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
       
        path = new NavMeshPath();
        FollowPath = GetComponent<SteeringFollowPath>();
        //NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);

        ListTag("Table");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update: charactes behaviour");

        if (action == State.WAIT)
        {
            for (int i = 0; i < TableList.Count; ++i)
            {
                Debug.Log("1 this ");
                Objective = TableList[i];
                tableScript = Objective.GetComponent<Table>();

                if (tableScript.GetOcupy() == false)
                {
                    Debug.Log("2 this");
                    
                    CalculatePath(Objective);
                    action = State.LOOKTABLE;
                    taskDone = false;
                    break;
                } else
                {
                    //Debug.Log("2 this true" + i);
                    //taskDone = true;
                }
            }
        }
        else if (action == State.LOOKTABLE)
        {
            if (!taskDone)
            {
                taskDone = FollowPath.Steer(path);
            }
            else if (taskDone)
            {
                //Debug.Log("before interact" + tableScript.GetOcupy());
               //if (Vector3.Distance(transform.position, move.target.transform.position) <= min_Distance)
                Objective.GetComponent<Table>().ocupy = true;
               // tableScript.OnInteract();
               // Debug.Log("on interact"+ tableScript.GetOcupy());

                move.current_velocity = Vector3.zero;

                move.current_rotation_speed = 0;

                move.max_mov_acceleration = 0;

                move.max_mov_speed= 0;

                action = State.WAIT;
                taskDone = false;
            }

        }

      
    }



    void ListTag(string tag)
        {
        
           TableList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            TableList.Add(ObjectF);
        }

        Objective = TableList[0];
        tableScript = Objective.GetComponent<Table>();

       // Debug.Log("Table list size" + TableList.Count);
       // Debug.Log("Table" + tableScript.GetOcupy());

    }

    void CalculatePath(GameObject objevit)
    {
        Debug.Log(move.target.name);
        move.target = objevit;
        Debug.Log(objevit.name);
        Debug.Log(move.target.name);
        if (path != null)
        {
            path.ClearCorners();
            path = null;

        }

        path = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, objevit.transform.position, NavMesh.AllAreas, path);
        Debug.Log("newPath");
    }
}
  

