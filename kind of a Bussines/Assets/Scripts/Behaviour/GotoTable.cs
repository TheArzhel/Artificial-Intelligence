using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class GotoTable : ActionTask
{
    private BGCcMath curve;

    public GameObject[] tables;
    public bool active = false;

    private GameObject Destiny;
    private bool ret = false;
    Move move;
    FollowCurve PathControl;
    TableManager tablemanager = null;

    public GameObject ThisGameObject;


    //Called only the first time the action is executed and before anything else.
    protected override void OnExecute()
    {
        ret = false;
        tables = GameObject.FindGameObjectsWithTag("Table");
         Debug.Log("ret  " + ret);
        //to get values:
        //ownerAgent.gameObject.getcompo...
        //ThisGameObject.value.
        move = ThisGameObject.GetComponent<Move>();
        PathControl = ThisGameObject.GetComponent<FollowCurve>();
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

                tablemanager = Destiny.GetComponent<TableManager>();
                curve = tablemanager.AskPath();
                PathControl.SetCurve(curve);
               // Debug.Log("set curve" + curve );
                move.finished = false;


            }
            else
            {

            EndAction(false);
            }
        }
        if (move.finished && ret)
        {
           
            EndAction(true);
            Debug.Log("end table");
        }

    }


    bool FindTable()
    {
        foreach (GameObject GO in tables)
        {
            tablemanager = null;
            tablemanager = GO.GetComponent<TableManager>();
            if (tablemanager != null)
            {
                if (tablemanager.AskDisponibility())
                {
                    Destiny = GO;
                    // Debug.Log("Found");
                    return true;

                }
            }
        }
        return false;
    }

    public void EnableACtivityScript(bool on)
    {
        active = on;
    }

    //public void EndAction(bool);
}
