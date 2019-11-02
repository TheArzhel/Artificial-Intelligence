using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterObj : MonoBehaviour
{
    public NavMeshPath path;
    //private float elapsed = 0.0f;
    Move move;
    public float min_Distance = 0.1f;
    public float slow_Distance = 0.5f;
    private int iterator = 0;
    SteeringSeek seek;
    private NavMeshPathStatus status= NavMeshPathStatus.PathPartial;
    private int Cornersize;
    private Vector3[] readablepath;

    Vector3 nextPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        path = new NavMeshPath();
        
      //  elapsed = 0.0f;
        NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);

        Cornersize = path.corners.Length;
        //Cornersize = readablepath.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: ");

        if (Vector3.Distance(transform.position, move.target.transform.position) <= min_Distance || iterator >= Cornersize)
        {
           
            status = NavMeshPathStatus.PathComplete;
            path.ClearCorners();
            Debug.Log("arrive: ");

            


        }
        else if (Vector3.Distance(transform.position, move.target.transform.position) > slow_Distance)
        {
            Debug.Log("%f"+ Vector3.Distance(transform.position, move.target.transform.position));
            Debug.Log("your distance and mine is greater than slow: ");

            if (iterator < Cornersize)
            {
                Debug.Log(iterator);
                nextPoint = path.corners[iterator];
                Debug.Log("go to next corner");
            }

            if (Vector3.Distance(transform.position, move.target.transform.position) <= min_Distance)
            {

                status = NavMeshPathStatus.PathComplete;
                path.ClearCorners();
                Debug.Log("arrive: ");

            }

            if (Vector3.Distance(transform.position, nextPoint) > slow_Distance)
            {
                seek.Steer(nextPoint);
                Debug.Log("go to point");
            }
            else if (Vector3.Distance(transform.position, nextPoint) < slow_Distance)
            {
                iterator++;
                Debug.Log("go to point, next iterator");
            }
        }
        else if (Vector3.Distance(transform.position, nextPoint) <= slow_Distance)
        {
            Debug.Log("nextpoint and mine distance  is smaller than slow: ");
            if (Vector3.Distance(nextPoint, move.target.transform.position) <= min_Distance)
            {
              
                status = NavMeshPathStatus.PathComplete;
                path.ClearCorners();
                Debug.Log("arrive: ");

            }
            else
            {
                iterator++;
                if (iterator < Cornersize)
                {
                    nextPoint = path.corners[iterator];
                }

            }
        }

        
    }

}
