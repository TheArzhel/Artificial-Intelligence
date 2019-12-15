using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class GotoDepositHideAlcochol : ActionTask
{
    public BGCcMath DepositRestock;
    public BGCcMath DepositHide;
    public BGCcMath BarSeel;
    public BGCcMath BarDoor;
    public BGCcMath Kitchen;

    private BGCcMath CurrentCurve;

    private bool ret = false;


    Move move;
    FollowCurve PathControl;
    Status StatusController;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        ret = false;
        CurrentCurve = null;
        move = ownerAgent.gameObject.GetComponent<Move>();
        move.finished = false;
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        //Debug.Log("ret" + ret + CurrentCurve);
        StatusController = ownerAgent.gameObject.GetComponent<Status>();

    }

    // Update is called once per frame
    protected override void OnUpdate()
    {

        if (!ret)
        {
            if (CurrentCurve == null)
            {
                ret = ChooseCurve();
               // Debug.Log("choose curve ret " + ret + CurrentCurve);
            }

           // Debug.Log(ret);
            if (ret)
            {
                ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
                ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
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

    public bool ChooseCurve()
    {
        bool ret = false;
        switch (StatusController.PreviousAction)
        {
            case WorkerState.CLOSEBAR:
                CurrentCurve = BarDoor;

                break;


            case WorkerState.HIDEALCOHOL:
                CurrentCurve = DepositHide;

                break;

            case WorkerState.RESTOCK:
                CurrentCurve = DepositRestock;

                break;

            case WorkerState.SELLBAR:
                CurrentCurve =BarSeel ;

                break;
            case WorkerState.SELLKITCHEN:
                CurrentCurve = Kitchen;

                break;
        }

        
        ret = true;
        return ret;
    }
}
