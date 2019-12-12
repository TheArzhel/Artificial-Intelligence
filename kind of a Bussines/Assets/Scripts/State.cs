using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AdquisitionalState
{
    RICH,
    MEDIUM,
    POOR

}



public class State : MonoBehaviour
{



    AdquisitionalState CapitalStatus;
    private GameObject SceneCurrency;
    Currencies Curr;

    float moneyOwner;

    float AuxPriceFood;
    float AuxPriceAlcohol;


    // Start is called before the first frame update
    void Start()
    {

        SceneCurrency = GameObject.FindGameObjectWithTag("Day");
        Curr= SceneCurrency.GetComponent<Currencies>();

        int i = Random.Range(0,2);
        CapitalStatus = (AdquisitionalState)i;


        AuxPriceFood = Curr.PriceFood;
        AuxPriceAlcohol = Curr.PriceAlcohol;


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Pay(Currencies.Bill_Type type)
    {

        bool ret = true;

    
        switch (CapitalStatus)
        {
            case AdquisitionalState.POOR:
                moneyOwner = Curr.MinimumBillCost;
               
                    break;


            case AdquisitionalState.MEDIUM:
                moneyOwner = Curr.MinimumBillCost+10;

                break;

            case AdquisitionalState.RICH:
                moneyOwner = Curr.MinimumBillCost+20;

                break;

        }
        

        switch (type)
        {

            case Currencies.Bill_Type.FOOD:


                if (moneyOwner >= Curr.PriceFood)
                    Curr.CashIn(AuxPriceFood);
                else
                    ret = false;


                break;

            case Currencies.Bill_Type.ALCOHOL:


                if (moneyOwner >= Curr.PriceAlcohol)
                    Curr.CashIn(AuxPriceAlcohol);
                else
                    ret = false;

                break;
        }




        return ret;
    }
}
