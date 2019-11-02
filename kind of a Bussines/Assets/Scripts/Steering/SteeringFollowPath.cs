using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringFollowPath : MonoBehaviour
{

    public float ratio = 0.0f;
    public float ratio_increment = 0.1f;
    public float min_distance = 1.0f;
    
    public float slow_Distance = 0.5f;
    
    NavMeshPath path;
    Move move;
    SteeringSeek seek;

    private int iterator = 0;
    private int Cornersize=0;
    
    private Vector3[] readablepath;
    Vector3 nextPoint;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        path = new NavMeshPath();


  

    }

    // Update is called once per frame
    void Update()
    {
        Steer(path);
    }

    public bool Steer(NavMeshPath path_)
    {
        // if first time entering 
        if (path == null)
        {
            path = new NavMeshPath();
            path = path_;
            Cornersize = path.corners.Length;
            move = GetComponent<Move>();
            seek = GetComponent<SteeringSeek>();
        }

        Debug.Log("SteerFollowPath: ");

        //if the object arrive to the end
        if (Vector3.Distance(transform.position, move.target.transform.position) <= min_distance || iterator >= Cornersize)
        {
            path.ClearCorners();
            Debug.Log("arrive: ");
            return true;
        }

        // the obj moving is far from the target
        else if (Vector3.Distance(transform.position, move.target.transform.position) > slow_Distance)
        {
            // Debug.Log("%f" + Vector3.Distance(transform.position, move.target.transform.position));
           // Debug.Log("your distance and mine is greater than slow: ");


            // if I can get more points, go for next
            if (iterator < Cornersize)
            {
                Debug.Log(iterator);
                nextPoint = path.corners[iterator];
                Debug.Log("go to next corner");
            }

            //if i arrive at the position
            //if (Vector3.Distance(transform.position, move.target.transform.position) <= min_distance)
            //{
            //    path.ClearCorners();
            //    Debug.Log("arrive: ");

            //}


            //go to point
            if (Vector3.Distance(transform.position, nextPoint) > slow_Distance)
            {
                seek.Steer(nextPoint);
                Debug.Log("go to point");
            }

            //go and ask for next point if there is any
            else if (Vector3.Distance(transform.position, nextPoint) < slow_Distance)
            {
                iterator++;
                Debug.Log("go to point, next iterator");
            }
        }

        //The object is really near from the target
        else if (Vector3.Distance(transform.position, nextPoint) <= slow_Distance)
        {
            Debug.Log("nextpoint and mine distance  is smaller than slow: ");
            //delete information and do nothing
            if (Vector3.Distance(nextPoint, move.target.transform.position) <= min_distance)
            {

                path.ClearCorners();
                Debug.Log("arrive: ");

            }

            //else
            //{
            //    iterator++;
            //    if (iterator < Cornersize)
            //    {
            //        nextPoint = path.corners[iterator];
            //    }

            //}
        }

        return false;
    }
}

        

    

