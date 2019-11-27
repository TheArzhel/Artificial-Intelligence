using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class FollowCurve : MonoBehaviour
{
  
    public BGCcMath curve;

    float ratio = 0.0f;
    //FollowPath path_manager;
    Move move;
    public bool loop = true;
    bool reversed = false;
    Vector3 final_position;
    // Start is called before the first frame update
    void Start()
    {
        //path_manager = GetComponent<FollowPath>();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(curve);
       
    }

    public bool Move(BGCcMath curve)
    {
        // --- FollowCurve works in cohesion with FollowPath, if activated it will ask for a path to the given curve waypoint.
        // FollowPath will return true on waypoint reached so FollowCurve can send the next waypoint ---
        if (ratio > 1 && !curve.Curve.Closed)
        {
            loop = false;
            ratio = 1;
        }
        else if (ratio > 1 && loop)
            ratio = 0;
        else if (1 - ratio < 0 && reversed)
        {
            ratio = 1;
        }

        // --- Whenever an agent reaches end of curve, reverse it (not using Reverse() function of curve since it would affect every agent) ---
        if (reversed)
            final_position = curve.CalcPositionByDistanceRatio(1 - ratio);
        else
            final_position = curve.CalcPositionByDistanceRatio(ratio);

        final_position.y = 0.0f;


        if (final_position.x == curve.CalcPositionByDistanceRatio(ratio).x && final_position.z == curve.CalcPositionByDistanceRatio(ratio).z)
        {
            // --- Ratio based on speed and curve distance that goes from 0 to 1 and determines next curve waypoint ---
            ratio += (move.max_speed / curve.GetDistance() * Time.deltaTime);
        }

        move.target3 = final_position;
        final_position = Vector3.positiveInfinity;

        // --- Return whether end of curve has been reached or not ---

        return loop;
    }

    public void Reset(BGCcMath curve)
    {
        reversed = !reversed;
        loop = true;
        ratio = 0;
    }
}
