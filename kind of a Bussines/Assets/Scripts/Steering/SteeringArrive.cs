using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour
{

    public float min_distance = 0.1f;
    public float slow_distance = 4.0f;
    public float time_to_target = 0.6f;

    public bool ArriveActive = true;

    float DistanceFromTarget;
    float NeededSpeed;

    Vector3 Distance;
    Vector3 NeededVelocity;







    Move move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (move.useSteer)
            Steer(move.target3);
    }

    public void Steer(Vector3 target)
    {
        if (!move)
            move = GetComponent<Move>();

        //Get the target direction and distance
       Distance = target - transform.position;
       DistanceFromTarget = Distance.magnitude;
       Vector3 DistanceToEnd = target - transform.position;

        //check if it's the min distance
        if (DistanceToEnd.magnitude < min_distance)
            ArriveActive = false;
        else
            ArriveActive = true;

        if (ArriveActive)
        {
           


            NeededVelocity = target - transform.position;
            NeededVelocity.Normalize();
            NeededVelocity *= move.max_speed;


            if (DistanceFromTarget <= slow_distance)
            {
               
                NeededVelocity *= DistanceFromTarget / slow_distance * 1.5f;

            }

            Vector3 NeededAccel = NeededVelocity - move.Velocity;
            NeededVelocity /= time_to_target;


            //if a>max_a then cap
            if (NeededAccel.magnitude > move.max_acceleration)
            {

                NeededAccel.Normalize();
                NeededAccel *= move.max_acceleration;

            }


            //Apply force

             NeededAccel.y = 0;
              move.AccelerateMovement(NeededAccel);
            
        }
        else
        {
            //move.Velocity = Vector3.zero;

            //move.Steering_linear = Vector3.zero;
        //stop linear only    
        move.StopLinera();

        }

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, min_distance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, slow_distance);
    }


}
