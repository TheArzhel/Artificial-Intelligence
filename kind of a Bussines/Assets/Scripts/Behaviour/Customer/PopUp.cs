using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class PopUp : ActionTask
{

    Status stat;
    Move move;
    FollowCurve PathControl;

    Currencies curr;

    public bool FoodService;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        stat = ownerAgent.gameObject.GetComponent<Status>();
        GameObject aux=GameObject.FindGameObjectWithTag("Day");
        curr = aux.GetComponent<Currencies>();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (FoodService)
        {
            if (stat.KitchenAttendant == false || stat.IsThereFood == false)
            {
                stat.AgentMood = Mood.ANGRY;
                ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
                curr.DecreasePopularity();
            }
        }
        else
        {
            if (stat.BarAttendant == false || stat.IsThereDrinks == false)
            {
                stat.AgentMood = Mood.ANGRY;
                ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
                curr.DecreasePopularity();
            }
        }
            EndAction(false);
        
    }

    

}
