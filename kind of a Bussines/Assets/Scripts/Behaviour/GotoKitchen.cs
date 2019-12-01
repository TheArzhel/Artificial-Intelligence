using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class GotoKitchen : ActionTask
{
    public BGCcMath Curve;
    public BGCcMath Curve1;
    public BGCcMath Curve2;

    private BGCcMath CurrentCurve;

    private bool ret = false;


    Move move;
    FollowCurve PathControl;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        ret=false;
        CurrentCurve = null;
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (!ret)
        {
            if (CurrentCurve == null)
            {
                ret= ChooseCurve();
            }
            
            //Debug.Log(ret);
            if (ret)
            {
                PathControl.SetCurve(CurrentCurve);

            }
            else
                EndAction(false);
        }
        if (move.finished && ret)
        {

            EndAction(true);
        }

    }

    public bool ChooseCurve()
    {
        bool ret=false;
        //must choose random
        int a= Random.Range(1, 3);
        if (a <= 1)
        {
            CurrentCurve = Curve;
            ret = true;
        }
        else if (a <= 2)
        {
            CurrentCurve = Curve1;
            ret = true;
        }
        else
        {
            CurrentCurve = Curve2;
            ret = true;

        }

        return ret;
    }
}
