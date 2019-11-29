using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class Wait : ActionTask
{
    public float MinTime = 1.0f;
    public float MaxTime = 15.0f;

    private float Timer = 0.0f;
    private float Expecedwait = 0.0f;

    Move move;
    FollowCurve PathControl;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        move = ownerAgent.gameObject.GetComponent<Move>();
        PathControl = ownerAgent.gameObject.GetComponent<FollowCurve>();
        Timer = 0.0f;
        Randomice(MinTime, MaxTime);

        //stop hambo from moving
        CleanValues();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        //timer adding up
        Timer += Time.deltaTime;

        //id the time passes correctly end in true. otherwise false
        if (Timer >= Expecedwait)
        {
            move.finished = false;
            EndAction(true);
        }
        else if (Timer >= MaxTime+1)
        {
            EndAction(false);
        }
    }
    void Randomice(float min, float max)
    {
        Expecedwait = Random.Range(min,max);
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
