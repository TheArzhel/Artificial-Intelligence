using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class SearchBar: ActionTask
{

    public float MinTime = 1.0f;

    private float Timer = 0.0f;

    private bool found = false;

    Move move;
    FollowCurve PathControl;


    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        Timer = 0.0f;
        found = false;
        //stop hambo from moving
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        //timer adding up
        Timer += Time.deltaTime;


        if (Timer > MinTime)
        {
            GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
            //if (Cargo != null)
            // Debug.Log("exist");
            BarScrip BarControler;
            BarControler = Bar.GetComponent<BarScrip>();
            //if (Cargo != null)
            //Debug.Log("exis2t");

           found = BarControler.IsitOpen();
        }
        //id the time passes correctly end in true. otherwise false
        if (Timer * 2 >= MinTime && found == true)
        {
            //move.finished = false;
            EndAction(true);
        }
        else if (Timer >= MinTime + 1)
        {
            EndAction(false);
        }
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
