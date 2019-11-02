using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour
{

    public float min_distance = 0.1f;
    public float slow_distance = 5.0f;
    public float time_to_target = 0.6f;

    public bool ArriveActive = true;

    float DistanceFromTarget;
    float NeededSpeed;
    Vector3 DirectionMov;
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
        Steer(move.target.transform.position);
    }

    public void Steer(Vector3 target)
    {
       // //Get the target direction and distance
       //DirectionMov = target - transform.position;
       //DistanceFromTarget = DirectionMov.magnitude;

       // //check if it's the min distance
       // if (DistanceFromTarget < min_distance)
       //     ArriveActive = false;
       // else
       //     ArriveActive = true;

       // //check slow speed is needed
       // //if not keep it max, else reduce depending on distance
       // if (DistanceFromTarget>slow_distance)
       //     NeededSpeed=move.max_speed; 
       // else
       //     NeededSpeed = move.max_speed * (DistanceFromTarget/slow_distance);

       // //set the direction of agent to target and assing the speed needed 
       // NeededVelocity = DirectionMov;
       // NeededVelocity = NeededVelocity.normalized*NeededSpeed;

       // //obtain de desired acceleration in order slow on target:
       // //a=(Vf-Vo)/time_taken
       // Vector3 steering_linear;
       // steering_linear = (NeededVelocity - move.Velocity)/time_to_target;

       // //if a>max_a then cap
       // if (steering_linear.magnitude > move.max_acceleration)
       //       steering_linear=steering_linear.normalized* move.max_acceleration;

       // //Apply force
       // move.AccelerateMovement(steering_linear);

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
