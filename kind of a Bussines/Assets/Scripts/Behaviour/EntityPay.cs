using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class EntityPay : ActionTask
{
    public float MinTime = 1.0f;
    public float MaxTime = 7.0f;

    private float Timer = 0.0f;
    private float Expecedwait = 0.0f;


    public bool FoodService;

    

    Move move;
    
    private GameObject SceneCurrency;
    Currencies GameCurrency;



    FollowCurve PathControl;


    Status EntityStates;//entity states 



    protected override void OnExecute()
    {

        SceneCurrency = GameObject.FindGameObjectWithTag("Day");
        GameCurrency = SceneCurrency.GetComponent<Currencies>();
        EntityStates = ownerAgent.gameObject.GetComponent<Status>();


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


            bool ret = false;
            //move.finished = false;


            if(FoodService)
               ret= EntityStates.Pay(Currencies.Bill_Type.FOOD);
            else
               ret= EntityStates.Pay(Currencies.Bill_Type.ALCOHOL);


            GameCurrency.PopularityStreak++;

            if (ret)
            {
                EndAction(true);
            }
            else
            {
                EndAction(false);
            }


        }
        else if (Timer >= MaxTime + 1)
        {
            EndAction(false);
        }
    }

    void Randomice(float min, float max)
    {
        Expecedwait = Random.Range(min, max);
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
