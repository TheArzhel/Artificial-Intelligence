using UnityEngine;
using System.Collections;


public class SteeringSeek : MonoBehaviour
{

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
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()
        Vector3 Steering_linear;
        Steering_linear = (target - transform.position);
        Steering_linear = Steering_linear.normalized * move.max_acceleration;
        move.AccelerateMovement(Steering_linear);


    }

}