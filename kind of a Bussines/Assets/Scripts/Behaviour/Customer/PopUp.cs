using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class PopUp : ActionTask
{

    Status stat;
    Move move;
    FollowCurve PathControl;
    public bool FoodService;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        stat = ownerAgent.gameObject.GetComponent<Status>();
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
            }
        }
        else
        {
            if (stat.BarAttendant == false || stat.IsThereDrinks == false)
            {
                stat.AgentMood = Mood.ANGRY;
                ownerAgent.gameObject.GetComponent<EnablePopUps>().ShowPopUp();
            }
        }
            EndAction(false);
        
    }

    

}
