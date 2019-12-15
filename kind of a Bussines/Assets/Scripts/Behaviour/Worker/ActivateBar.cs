using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class ActivateBar : ActionTask
{
    Move move;
    FollowCurve PathControl;
    BarScrip BarScrip;
    Status StatusController;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();

        GameObject bar = GameObject.FindGameObjectWithTag("Bar");
        BarScrip = bar.GetComponent<BarScrip>();

        StatusController = ownerAgent.gameObject.GetComponent<Status>();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
        BarScrip.attendant = true;
        ownerAgent.gameObject.GetComponent<Status>().TodoAction = WorkerState.NONE;
        StatusController.PreviousAction = StatusController.TodoAction;
        EndAction(true);

    }





}
