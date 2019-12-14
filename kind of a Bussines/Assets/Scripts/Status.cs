using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AdquisitionalState
{
    RICH,
    MEDIUM,
    POOR

}

public enum WorkerState
{
    NONE,
    SELLKITCHEN,
    SELLBAR,
    HIDEALCOHOL,
    CLOSEBAR,
    RESTOCK

}


public enum Mood
{
    NONE,
    ANGRY,
    HUNGRY,
    THIRSTY,
    CONFUSE,
    FOCUSED,
    PAYING



}

public class Status : MonoBehaviour
{

    public AdquisitionalState CapitalStatus;
    private GameObject SceneCurrency;
    Currencies Curr;

    float moneyOwner;

    float AuxPriceFood;
    float AuxPriceAlcohol;

    //DaynightControlVariables
    DayNight Day;
    public bool day = true;
    GameObject scene;

    //WorkerVariables
    public WorkerState TodoAction;
    public WorkerState PreviousAction;

    //FoodandDrinkControlVars
    //Food
    public bool IsThereFood = false;
    //Drinks
    public bool IsThereDrinks = false;

    //bar control vars
    public bool BarIsOpen = false;
    BarScrip BarControl;

   public Mood AgentMood=Mood.ANGRY;

    // Start is called before the first frame update
    void Start()
    {

        SceneCurrency = GameObject.FindGameObjectWithTag("Day");
        Curr= SceneCurrency.GetComponent<Currencies>();

        GameObject Bar = GameObject.FindGameObjectWithTag("Bar");
        BarControl = Bar.GetComponent<BarScrip>();
        BarIsOpen = BarControl.IsitOpen();

        if (Curr.UnitsAlcohol > 0)
            IsThereDrinks = true;
        else
            IsThereDrinks = false;

        if (Curr.UnitsFood > 0)
            IsThereFood = true;
        else
            IsThereFood = false;


        int i = Random.Range(0,2);
        CapitalStatus = (AdquisitionalState)i;


        AuxPriceFood = Curr.PriceFood;
        AuxPriceAlcohol = Curr.PriceAlcohol;

        //day or night chechk
        scene = GameObject.FindGameObjectWithTag("Day");

        if (Day == null)
            Day = scene.GetComponent<DayNight>();


    }

    // Update is called once per frame
    void Update()
    {
        BarIsOpen = BarControl.IsitOpen();

        //check day or night
        day = Day.getdate();

        if (Curr.UnitsAlcohol > 0)
            IsThereDrinks = true;
        else
            IsThereDrinks = false;

        if (Curr.UnitsFood > 0)
            IsThereFood = true;
        else
            IsThereFood = false;
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
                {
                      Curr.CashIn(AuxPriceFood);
                    Curr.UnitsFood -= 1;
                }
                else
                    ret = false;


                break;

            case Currencies.Bill_Type.ALCOHOL:


                if (moneyOwner >= Curr.PriceAlcohol)
                {
                    Curr.CashIn(AuxPriceAlcohol);
                    Curr.UnitsAlcohol -= 1;
                }
                else
                    ret = false;

                break;
        }



        if (ret)
        {
            Curr.PopularityStreak++;
            Curr.IncreasePopularity();
        }

        return ret;
    }
}
