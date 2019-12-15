using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class GotoBar : ActionTask
{
    //public BGCcMath Curve;
    //public BGCcMath Curve1;
    //public BGCcMath Curve2;

    private BGCcMath CurrentCurve;

    private bool ret = false;

    private GameObject Bar;

    Move move;
    FollowCurve PathControl;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        ret = false;
        CurrentCurve = null;
        move = ownerAgent.gameObject.GetComponent<Move>();
        move.finished = false;
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();

        //Debug.Log("ret" + ret + CurrentCurve);

    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        

        if (!ret)
        {
            if (CurrentCurve == null)
            {
                FindCurve();
                if (CurrentCurve != null)
                { ret = true; }
                //Debug.Log("choose curve ret " + ret + CurrentCurve);

            }

           // Debug.Log(ret);
            if (ret)
            {

                PathControl.SetCurve(CurrentCurve);

                // move.finished = false;
            }
            else
                EndAction(false);
        }
        else if (move.finished && ret)
        {

            EndAction(true);
            //Debug.Log("end " + CurrentCurve);
        }

    }

   

    private void FindCurve()
    {
        Bar = GameObject.FindGameObjectWithTag("Bar");
        //if (Bar != null)
        //    Debug.Log("exist");
        BarScrip BarController;
        BarController = Bar.GetComponent<BarScrip>();
        //if (Bar != null)
        //    Debug.Log("exis2t");
        CurrentCurve = BarController.AskPath();
    }
}
