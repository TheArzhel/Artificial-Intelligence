using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class GotoTable : ActionTask
{
    private BGCcMath curve;

    public GameObject kitchen;

    private bool ret = false;
    Move move;
    FollowCurve PathControl;
    

    //Called only the first time the action is executed and before anything else.
    protected override void OnExecute()
    {
        ret = false;
        //Debug.Log("ret  " + ret);
        //to get values:
        //ownerAgent.gameObject.getcompo...
        //ThisGameObject.value.
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
    }

    //Called every frame while the action is running.
    protected override void OnUpdate()
    {

        if (!ret)
        {
            ret = FindTable();
            //Debug.Log(ret);
            if (ret)
            {

               
                PathControl.SetCurve(curve);
               // Debug.Log("set curve" + curve );
             


            }
            else
            {

                EndAction(false);
            }
        }
        else if (move.finished && ret)
        {
           
            EndAction(true);
            Debug.Log("end table");
        }

    }


    bool FindTable()
    {

        GameObject Kitchen = GameObject.FindGameObjectWithTag("Kitchen");
        TableScrip TableControler;
        TableControler = Kitchen.GetComponent<TableScrip>();
        curve = TableControler.AskPath();
        if (curve != null)
        {
            return true;
        }
       
        return false;
    }

  
}
