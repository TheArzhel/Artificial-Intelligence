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
            Debug.Log("new info");
            path = new NavMeshPath();
            path = path_;
            Cornersize = path.corners.Length;
            Debug.Log("CL "+Cornersize);
            if (!move)
            move = GetComponent<Move>();
            if (!seek)
            seek = GetComponent<SteeringSeek>();

            iterator = 0;
            
        }

       // Debug.Log("SteerFollowPath: ");

        //if the object arrive to the end
        if (Vector3.Distance(transform.position, move.target.transform.position) <= min_distance || iterator >= Cornersize)
        {
            Debug.Log("iterator: "+iterator);
            Debug.Log("cournes: "+Cornersize);

            path.ClearCorners();
            Debug.Log("arrive: ");
            iterator = 0;
            Cornersize = 0;
            path = null;

            return true;
        }

        // the obj moving is far from the target
        else if (Vector3.Distance(transform.position, move.target.transform.position) > slow_Distance)
        {
           
            // Debug.Log("%f" + Vector3.Distance(transform.position, move.target.transform.position));



            //if i arrive at the position
            //if (Vector3.Distance(transform.position, move.target.transform.position) <= min_distance)
            //{
            //    path.ClearCorners();
            //    Debug.Log("arrive: ");

            //}

            // if I can get more points, go for next
            if (iterator < Cornersize)
            {
               // Debug.Log("1.1");
                //Debug.Log(iterator);
                nextPoint = path.corners[iterator];
                //Debug.Log("go to next corner");
            }


            //go to point
            if (Vector3.Distance(transform.position, nextPoint) > slow_Distance)
            {
                Debug.Log("nexpoint"+nextPoint);

                Debug.Log("transform" + transform.position);

                seek.Steer(nextPoint);
                //Debug.Log("go to point");
            }

            //go and ask for next point if there is any
            else if (Vector3.Distance(transform.position, nextPoint) < slow_Distance)
            {
                Debug.Log("1.3");
                iterator++;
                //Debug.Log("go to point, next iterator");
            }
        }

        //The object is really near from the target
        else if (Vector3.Distance(transform.position, nextPoint) <= slow_Distance)
        {
            //Debug.Log("nextpoint and mine distance  is smaller than slow: ");
            //delete information and do nothing
            if (Vector3.Distance(nextPoint, move.target.transform.position) <= min_distance)
            {
                Debug.Log("2");
                path.ClearCorners();
                Debug.Log("arrive23: ");

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

        

    

