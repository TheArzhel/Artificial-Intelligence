﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class CloseBar : ActionTask
{
    Move move;
    FollowCurve PathControl;
    BarScrip BarController;
    Status StatusController;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();

    StatusController = ownerAgent.gameObject.GetComponent<Status>();
        GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
        BarController = Bar.GetComponent<BarScrip>();
        
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
        BarController.CloseBar();
        StatusController.PreviousAction = StatusController.TodoAction;
        ownerAgent.gameObject.GetComponent<Status>().TodoAction = WorkerState.NONE;
        EndAction(true);
       
    }



    void CleanValues()
    {
        move.StopLinera();
        move.finished = true;
        PathControl.SetCurve(null);
        move.ChangeUseSteer(false);
        
    }

}
