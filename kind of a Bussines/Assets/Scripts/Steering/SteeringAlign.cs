using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringAlign : MonoBehaviour
{

    public float min_angle =5f;
    public float slow_angle =15f;
    public float time_to_target = 0.4f;
    public float min_distance = 1.0f;
    public bool AlignActive = true;

    Vector3 DirectionMov;

  public  float rotation;
    float needed_rotation_speed; 
    float steering_angular;

    Move move;
   


    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
      DirectionMov = move.target.transform.position - transform.position;

        if (DirectionMov.magnitude <= min_distance)
        {
            AlignActive = false;
        }

    float Target_orientation = Vector3.SignedAngle(Vector3.forward, DirectionMov, Vector3.up);

      rotation = Target_orientation - move.orientation;

        // Map the result to the (-pi, pi) interval
        //rotation = mapToRange(rotation)
      

        float rotationSize = Mathf.Abs(rotation);

        if (rotationSize > min_angle || AlignActive)
        {

            if (rotationSize < min_angle)
                AlignActive = false;
            else
                AlignActive = true;

            if (rotationSize > slow_angle)
                needed_rotation_speed = Deg2Rad(move.max_rot_speed);
            else
                needed_rotation_speed = Deg2Rad(move.max_rot_speed) * (Deg2Rad(rotationSize) / Deg2Rad(slow_angle));
        

            needed_rotation_speed *= Deg2Rad(rotation) / Deg2Rad(rotationSize);


            if (needed_rotation_speed > Deg2Rad(move.max_rot_speed))
                needed_rotation_speed = Deg2Rad(move.max_rot_speed);

                steering_angular = (needed_rotation_speed - Deg2Rad(move.Rotation)) / time_to_target;


            if (Mathf.Abs(steering_angular) > Deg2Rad(move.max_rot_acceleration))
                steering_angular = Deg2Rad(move.max_rot_acceleration);

               move.AccelerateRotation(Rad2Deg(steering_angular));
        }
        else
        {
            Debug.Log("DYINGGGG HERREEEEEE");
            move.Rotation = 0;
            move.Steering_angular = 0;

        }

    }

    float Deg2Rad(float Deg)
    {
        return Deg * Mathf.Deg2Rad;
    }
    float Rad2Deg(float Rad)
    {

       return Rad * Mathf.Rad2Deg;
    }

}

