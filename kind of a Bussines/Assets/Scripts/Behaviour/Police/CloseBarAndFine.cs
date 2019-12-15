using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class CloseBarAndFine : ActionTask
{
    Move move;
    FollowCurve PathControl;

    Currencies curr;
    public float cashout = 500;

    // Start is called before the first frame update
    protected override void OnExecute()
    {

        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        

        
        GameObject scene = GameObject.FindGameObjectWithTag("Day");
        curr = scene.GetComponent<Currencies>();
        //stop hambo from moving
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
        GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
       
        BarScrip BarControler;
        BarControler = Bar.GetComponent<BarScrip>();
        //close and fine
        BarControler.lockBar();
        //set fine
        // decrease popularity
        curr.CashOut(cashout);
        curr.DecreasePopularity(100);

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
