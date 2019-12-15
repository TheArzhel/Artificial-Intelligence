using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class HideAlcohol: ActionTask
{
    Move move;
    FollowCurve PathControl;
    DepositScrip DepositController;
    Status StatusController;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        
        StatusController = ownerAgent.gameObject.GetComponent<Status>();
       
        GameObject Deposit = GameObject.FindGameObjectWithTag("Cargo");
        DepositController = Deposit.GetComponent<DepositScrip>();

        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
        DepositController.Hidedrink();
        ownerAgent.gameObject.GetComponent<Status>().TodoAction = WorkerState.NONE;
        StatusController.PreviousAction = StatusController.TodoAction;
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
