using UnityEngine;
using System.Collections;

public class SteeringSeek : MonoBehaviour
{
    SteeringArrive arrive;
    Move move;
    public float mind_distance = 1.0f;
    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();
    }

    // Update is called once per frame
    void Update()
    {
        Steer(move.target.transform.position);
    }

    public void Steer(Vector3 target)
    {
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()
        if (!move)
        {
            move = GetComponent<Move>();
        }
        if (!arrive)
        {
            arrive = GetComponent<SteeringArrive>();
        }
        Vector3 Steering_linear;
        Steering_linear = (target - transform.position);
        if (Steering_linear.magnitude > mind_distance)
        {

        Steering_linear = Steering_linear.normalized * move.max_acceleration;

        move.AccelerateMovement(Steering_linear);

        //arrive.Steer(target);
        }
    }
}
