using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class GotoKitchen : ActionTask
{
    public BGCcMath curve;
    public bool lol = false;

    //Called only the first time the action is executed and before anything else.
    protected override void OnExecute()
    {

        //blackboard.GetVariable < "GoingToTable" > ;
        //return "true";
    }

    //Called every frame while the action is running.
    protected override void OnUpdate()
    {
        if(lol)
        EndAction(true);

    }


    //public void EndAction(bool);
}
