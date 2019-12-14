using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class Fine : ActionTask
{
    Currencies curr;
    public float cashout = 250;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        GameObject scene = GameObject.FindGameObjectWithTag("Day");
        curr = scene.GetComponent<Currencies>();
        ownerAgent.gameObject.GetComponent<Status>().AgentMood = Mood.FOCUSED;
        ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        curr.CashOut(cashout);
        curr.DecreasePopularity();
        EndAction(true);
    }
}
