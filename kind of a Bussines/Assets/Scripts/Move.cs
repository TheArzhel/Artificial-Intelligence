using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Move : MonoBehaviour
{


    //Agent Data
    public GameObject target;
    public Vector3 target3;

    //Kinematics Data
    [Header("Kinematics Data")]
    public Vector3 pos;
    public float orientation;
    [Header("-------- Read Only --------")]
    public Vector3 Velocity = Vector3.zero;
    public float Rotation = 0.0f;

    //Steering Data
    [Header("Steering Data")]
    public Vector3 Steering_linear;
    public float Steering_angular;

    //limits
    [Header("Limits Param")]
    //velocities
    public float max_speed = 5.0f;
    public float max_rot_speed = 5.0f; // in degrees / second
    //Accelerations
    public float max_acceleration = 0.1f;
    public float max_rot_acceleration = 0.5f; // in degrees


    [Header("-------- Read Only --------")]
    public Vector3 current_velocity = Vector3.zero;
    public float current_rotation_speed = 0.0f; // degrees

    public bool useSteer = false;
    Animator anim;
    DayNight Day;
    public bool finished = false;

    public static bool day = true;

    GameObject scene;
    public enum ACTIVITY
    {
        Eat
    };

    public ACTIVITY action;


    // Methods for behaviours to set / add velocities

    public void SetMovementVelocity(Vector3 velocity)
    {
        Velocity = velocity;
    }

    public void AccelerateMovement(Vector3 acceleration)
    {
        Steering_linear = acceleration;
        Velocity += Steering_linear;
    }

    public void SetRotationVelocity(float rotation_speed)
    {
        Rotation = rotation_speed;
    }

    public void AccelerateRotation(float rotation_acceleration)
    {

      Steering_angular = rotation_acceleration;
      Rotation += Steering_angular;
	}
    public void ChangeTarget(GameObject tar)
    {
        target = tar;

    }

     void Start()
    {
       anim= GetComponent<Animator>();
        action = ACTIVITY.Eat;

        scene = GameObject.FindGameObjectWithTag("Day");

        if (Day == null)
            Day = scene.GetComponent<DayNight>();


    }

    public void Stop()
    {

        //anim.SetBool("IsWalking", false);
        //linear Velocity
        Velocity = Vector3.zero;

        //rot velocity
        Rotation = 0;
        SetRotationVelocity(0);
        AccelerateRotation(0);
        
    }

    public void StopRotation()
    {
      
        Rotation = 0;
        SetRotationVelocity(0);
        AccelerateRotation(0);

    }

    public void StopLinera()
    {
        //linear Velocity
        Velocity = Vector3.zero;
        AccelerateMovement(Vector3.zero);
        //finished = true;

    }

    // Update is called once per frame
    void Update()
    {
        day =Day.getdate();

        orientation = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);

        // cap velocity
        if (Velocity.magnitude > max_speed)
		{
            Velocity = Velocity.normalized * max_speed;
		}


        if (Velocity.magnitude > 3)
        {
            anim.SetBool("IsWalking", true);

        }
        else if (Velocity.magnitude == 0 || Velocity.magnitude < 3)
        {
            anim.SetBool("IsWalking", false);

        }

        //if (Rotation > 0 && Rotation > max_rot_speed)
        //{
        //    //be carefull with signs
        //    Rotation = max_rot_speed;
        //}
        //else if (Rotation < 0 && Rotation < -max_rot_speed)
        //{
        //    //be carefull with signs
        //    Rotation = -max_rot_speed;
        //}


        // final rotate & movement
        transform.rotation *= Quaternion.AngleAxis(Rotation * Time.deltaTime, Vector3.up);
        transform.position += Velocity * Time.deltaTime;

    }

    public void ChangeUseSteer(bool on)
    {
        useSteer = on;
        finished = !on;
        if (on == true)
        Debug.Log("end here ");
        
    }
}
