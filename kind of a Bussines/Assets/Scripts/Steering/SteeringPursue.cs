using UnityEngine;
using System.Collections;

public class SteeringPursue : MonoBehaviour
{

    public float max_seconds_prediction;
    public float second_prediction;
    Move move;
    SteeringSeek seek;
    SteeringArrive arrive;


    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        arrive = GetComponent<SteeringArrive>();
    }

    // Update is called once per frame
    void Update()
    {
        Steer(move.target.transform.position, move.target.GetComponent<Move>().current_velocity, move.target.GetComponent<Move>().max_mov_speed);
    }

    public void Steer(Vector3 target, Vector3 target_velocity, float max_target_speed)
    {
        // TODO 5: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time

        second_prediction = Vector3.Distance(target, transform.position) / move.max_mov_speed;


        if (second_prediction > max_seconds_prediction)
        {
            second_prediction = max_seconds_prediction;
        }
        else if (second_prediction < 0)
        {
            second_prediction = 0;
        }

        Vector3 pos_target_future = target + target_velocity * second_prediction;

        arrive.Steer(pos_target_future);

        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have


    }
}
