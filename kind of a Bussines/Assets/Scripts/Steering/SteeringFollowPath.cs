using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class SteeringFollowPath : MonoBehaviour
{



    Move move;
    SteeringSeek seek;
    public BGCcMath curve;

    public float ratio = 0.0f;
    public float ratio_increment = 0.1f;
    public float min_distance = 1.0f;
    float current_ratio = 0.0f;

    Vector3 ClosestPoint1;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        //curve = GetComponent<BGCcMath>();

        Vector3 ClosestPoint = curve.CalcPositionByClosestPoint(transform.position, out current_ratio);
        ClosestPoint1 = ClosestPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, ClosestPoint1) < min_distance)
        {
            seek.Steer(ClosestPoint1);
        }
        else
        {

            if (current_ratio >= 1.0f)
            {
                current_ratio = 0.0f;
            }

            current_ratio += (ratio_increment * Time.deltaTime);
            Vector3 newpos = curve.CalcPositionByDistance(current_ratio);
            transform.position = newpos;
        }

        // TODO 2: Check if the tank is close enough to the desired point
        // If so, create a new point further ahead in the path
    }

    void OnDrawGizmosSelected()
    {

        if (isActiveAndEnabled)
        {
            // Display the explosion radius when selected
            Gizmos.color = Color.green;
            // Useful if you draw a sphere were on the closest point to the path
        }

    }
}
