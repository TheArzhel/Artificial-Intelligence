using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class CloseBarAndFine : ActionTask
{
    public float MinTime = 1.0f;

    private float Timer = 0.0f;

    Move move;
    FollowCurve PathControl;

    // Start is called before the first frame update
    protected override void OnExecute()
    {

        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        Timer = 0.0f;

        //stop hambo from moving
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {

        GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
       
        BarScrip BarControler;
        BarControler = Bar.GetComponent<BarScrip>();
        //close and fine
        BarControler.CloseBar();
        //set fine
        // decrease popularity
        
        EndAction(true);
    }

    void CleanValues()
    {
        move.StopLinera();
        move.finished = true;
        PathControl.SetCurve(null);
        move.ChangeUseSteer(false);
        Debug.Log("end on clean value wait");
    }
}
