using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour
{

    public float min_angle = 0.01f;
    public float slow_angle = 0.1f;
    public float time_to_target = 0.1f;
    public float AngAccel = 0;
    public float angle = 0;
    public float W = 0;
    Move move;


    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDir = move.target.transform.position - transform.position;
        Vector3 forward = transform.forward;


        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        float positive_angle;


        if (angle < 0)
            positive_angle = -angle;
        else
            positive_angle = angle;

        if (positive_angle < min_angle)
        {
            move.SetRotationVelocity(0.0f);
            move.AccelerateRotation(0.0f);
            return;
        }


        W = move.max_rot_speed;

        if (positive_angle < slow_angle)
        {
            W *= (positive_angle / slow_angle);
        }
        else if (positive_angle < min_angle)
        {
            W = 0.0f;
        }
        move.SetRotationVelocity(W);

        AngAccel = W / time_to_target;

        //if (angle < 0)
        //{
        //    //angle = angle - 180;
        //    AngAccel = -AngAccel;
        //    //W = -W;
        //    //move.SetRotationVelocity(W);
        //}

        AngAccel = Mathf.Clamp(AngAccel, -move.max_rot_acceleration, move.max_rot_acceleration);

        move.AccelerateRotation(AngAccel);

    }


}

