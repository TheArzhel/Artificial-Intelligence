using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class CloseBar : ActionTask
{
    Move move;
    FollowCurve PathControl;
    BarScrip BarController;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();

        GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
        BarController = Bar.GetComponent<BarScrip>();
        
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        BarController.CloseBar();

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
