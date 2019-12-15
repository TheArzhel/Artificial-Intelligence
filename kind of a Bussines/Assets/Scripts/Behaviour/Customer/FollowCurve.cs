using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class FollowCurve : MonoBehaviour
{
    float ratio = 0.0f;
    //FollowPath path_manager;
    Move move;
    public bool loop = true;
   
    bool reversed = false;
    Vector3 final_position;

    public bool onGoing = false;

    [Header("-------- Read Only --------")]
    public BGCcMath curve;

    // Start is called before the first frame update
    void Start()
    {
        //path_manager = GetComponent<FollowPath>();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curve != null)
        {
           onGoing = Move(curve);
        }
       
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
        Vector2 TargetPos;
        TargetPos.x = (final_position.x - move.transform.position.x);
        TargetPos.y = (final_position.z - move.transform.position.z);
        //Vector3 distaceFrom =  final_position - move.transform.position ;

        if ( ratio < 1)
        {
            if (TargetPos.magnitude > 0.5f)
            {
                move.useSteer = true;
                move.finished = false;
               // Debug.Log("HI THERe" + ratio + "    " + lol.magnitude);
                

            }
            else
            {
                ratio += (move.max_speed / curve.GetDistance() * Time.deltaTime);

            }
            // --- Ratio based on speed and curve distance that goes from 0 to 1 and determines next curve waypoint ---
            if (ratio >= 0.99f)
            {
                move.useSteer = false;
                curve = null;
                move.finished = true;
               // Debug.Log("arrive curve editor");

            }
        }
        else if (ratio > 1.00f)
        {
            move.useSteer = false;
            curve = null;
            move.finished = true;
           // Debug.Log("arrive curve editor");

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

    public void SetCurve(BGCcMath newcurve)
    {
        if (curve != null)
        {
            curve = newcurve;
            move.ChangeUseSteer(true);
        }
        else {
            move = GetComponent<Move>();
            curve = newcurve;
            move.ChangeUseSteer(false);
        }
        ratio = 0;
       // Debug.Log("set curve" + curve);

    }


}
