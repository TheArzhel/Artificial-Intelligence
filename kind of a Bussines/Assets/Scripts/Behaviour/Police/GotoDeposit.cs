using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class GotoDeposit : ActionTask
{

    private BGCcMath CurrentCurve;

    private bool ret = false;

    private GameObject Cargo;

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

            Debug.Log(ret);
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
        Cargo = GameObject.FindGameObjectWithTag("Cargo");
        //if (Cargo != null)
           // Debug.Log("exist");
        DepositScrip DepositControler;
        DepositControler = Cargo.GetComponent<DepositScrip>();
        //if (Cargo != null)
            //Debug.Log("exis2t");
        CurrentCurve = DepositControler.AskPath();
    }
}
