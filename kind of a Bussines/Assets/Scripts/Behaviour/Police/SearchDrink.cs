using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class SearchDrink : ActionTask
{

    public float MinTime = 1.0f;

    private float Timer = 0.0f;

    private bool found = true;

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
        //timer adding up
        Timer += Time.deltaTime;


        if (Timer > MinTime)
        {
            GameObject Cargo = GameObject.FindGameObjectWithTag("Cargo");
            //if (Cargo != null)
            // Debug.Log("exist");
            DepositScrip DepositControler;
            DepositControler = Cargo.GetComponent<DepositScrip>();
            //if (Cargo != null)
            //Debug.Log("exis2t");
            
            found = DepositControler.SeeDrink();
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
