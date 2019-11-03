using UnityEngine;
using UnityEngine.UI;
using System.Collections;



//struct Kinematic
//{
//    //Linear values
//    Vector3 pos;
//    float orientation;
//    Vector3 Velocity;
//    float Rotation;
//}


//struct Steering
//{
//    //accelerations
//    Vector3 linear;
//    float angular;

//}

//struct AgentData
//{

//    GameObject Target;

//    Kinematic Kinematic_Data;
//    Steering Steering_Data;

//}
public class Move : MonoBehaviour {


    //Agent Data
   public GameObject target;

    //Kinematics Data
   [Header("Kinematics Data")]
   public Vector3 pos;
   public float orientation;
   [Header("-------- Read Only --------")]
   public Vector3 Velocity= Vector3.zero;
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
  

    
    //public Vector3 current_velocity = Vector3.zero;
    //public float current_rotation_speed = 0.0f; // degrees

    // Methods for behaviours to set / add velocities

    public void SetMovementVelocity (Vector3 velocity) 
	{
       Velocity = velocity;
	}

	public void AccelerateMovement (Vector3 acceleration) 
	{
       Steering_linear = acceleration;
       Velocity += Steering_linear;
	}

	public void SetRotationVelocity (float rotation_speed) 
	{
       Rotation = rotation_speed;
	}

	public void AccelerateRotation (float rotation_acceleration) 
	{

      Steering_angular = rotation_acceleration;
      Rotation += Steering_angular;
	}
	
	// Update is called once per frame
	void Update () 
	{
         orientation = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);

        // cap velocity
        if (Velocity.magnitude > max_speed)
		{
            Velocity = Velocity.normalized * max_speed;
		}

  
        // final rotate & movement
        transform.rotation *= Quaternion.AngleAxis(Rotation * Time.deltaTime, Vector3.up);
        transform.position += Velocity * Time.deltaTime;

	}
}
