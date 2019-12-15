﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class ActivateKitchen : ActionTask
{
    Move move;
    FollowCurve PathControl;
    KitchenScrip KitchenScrip;
    Status StatusController;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();

    StatusController = ownerAgent.gameObject.GetComponent<Status>();
        GameObject Kitchen = GameObject.FindGameObjectWithTag("Kitchen");
        KitchenScrip = Kitchen.GetComponent<KitchenScrip>();

    }

    // Update is called once per frame
    protected override void OnUpdate()
    {

        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
        KitchenScrip.attendant = true;
        StatusController.PreviousAction = StatusController.TodoAction;
        ownerAgent.gameObject.GetComponent<Status>().TodoAction = WorkerState.NONE;
        EndAction(true);

    }



    

}