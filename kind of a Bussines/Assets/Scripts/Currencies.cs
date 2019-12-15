using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currencies : MonoBehaviour
{


    public enum Bill_Type
    {
        FOOD,
        ALCOHOL
    }

    //Money
    public float GameMoney=100.00f;

    //Food Units
    public int UnitsFood = 20;
    public int RestockUnitsFood = 20;

    public int UnitsAlcohol = 0;
    public int RestockUnitsAlcohol = 0;

    //price food
    public float PriceFood = 5.99f;//selling to
    public float PriceAlcohol = 10.99f;

    //StockPrice
    public float FoodStockPrice = 10.50f;//buying to
    public float AlcoholStockPrice = 20.50f;

    //rates
    public float RisePriceRate = 1.99f;// selling to values
    public float LowePriceRate = 2.99f;

    //RateQuantities per buy
    public int FoodUnitPerBuy = 20;//quantity of food/alcohol recieved everytime u buy
    public int AlcoholUnitPerBuy = 5;

    //popularity
    public int GamePopularity = 0;
    public int PopularityStreak=0;
    public int popularityGoalStreak = 5;//max value to arrive for popularity rise
    public int RisePopularityRate = 50;//Rate of quantitivity increasement popularity
    public int LowePopularityRate = 40;

    float factorA = 100;


    //canvas vars
    GameObject UICanvas;
    ResourcesUI UIstats;

    //Status var
    public float MinimumBillCost;//Currently for food& alcohol

    float TimerForFade=0.00f;

    ChangeScene changer;

  
    public AudioSource audioSRC;
    public AudioClip Clip;
    public AudioClip LoseClip;
    public AudioClip WinClip;



    bool playWin = true;
    bool playLose = true;

    void Start()
    {

       //if factorA is 100 the fisrt price is 10

        float factorB = factorA * 0.2f;
        MinimumBillCost = factorB - (factorB / 2);
        UICanvas = GameObject.FindGameObjectWithTag("UI");
        UIstats = UICanvas.GetComponent<ResourcesUI>();


        GameObject aux = GameObject.Find("LevelChanger");
        changer = aux.GetComponent<ChangeScene>();


    
      




    }

    // Update is called once per frame

    void Update()
    {


        if (Input.GetMouseButton(0))
            CashIn(100);

        if (GameMoney < 0)
        {
            GameMoney = 0;

        }

        if (GamePopularity <= -250)
        {

            TimerForFade += Time.deltaTime;
            UIstats.LoseGame.SetActive(true);

            if (playLose)
            {
                audioSRC.clip = LoseClip;
                audioSRC.Play();
                playLose = false;
            }
            if (TimerForFade>=4.00f)
            Lose();


        }
        else if (GamePopularity >= 250)
        {

            TimerForFade += Time.deltaTime;
            UIstats.winGame.SetActive(true);

            if (playWin)
            {
                audioSRC.clip = WinClip;
                audioSRC.Play();
                playWin = false;
            }

            if (TimerForFade >= 4.00f)
                Win();

        }


    }

    public void CashIn(float income)
    {

        GameMoney += income;
        //UIstats.UpdateUIGlobalCurrencies();
        UIstats.UpdateUIValues();

        audioSRC.clip=Clip;
        audioSRC.Play();

    }

    public bool CashOut(float bill)
    {
        bool ret = false;
        if ((GameMoney - bill) >= 0)
        {
        GameMoney -= bill;
        //UIstats.UpdateUIGlobalCurrencies();
        UIstats.UpdateUIValues();

            ret = true;
        }

        return ret;
    }


    public void IncreasePopularity()
    {


        PopularityStreak++;

        if(PopularityStreak >= popularityGoalStreak)
        {

            GamePopularity += RisePopularityRate;
            PopularityStreak = 0;


            if (GamePopularity > 100)
            {
                factorA = GamePopularity;
                float factorB = factorA * 0.2f;
                MinimumBillCost = factorB - (factorB / 2);
            }


            UIstats.UpdateUIGlobalCurrencies();



        }

    }

    public void DecreasePopularity(int i)
    {

        GamePopularity -= i;
        UIstats.UpdateUIGlobalCurrencies();

    }


    //Food supplies
    public void BuyFoodUnits()
    {

        if (GameMoney > 0)
        {
            if (GameMoney > FoodStockPrice)
            {
                GameMoney -= FoodStockPrice;

                if (GameMoney < 0)
                    GameMoney = 0;

                RestockUnitsFood += FoodUnitPerBuy;
                UIstats.UpdateUIValues();
            }
        }
    }

    public void BuyAlcoholUnits()
    {

        if (GameMoney > 0)
        {
            if (GameMoney > AlcoholStockPrice)
            {
                GameMoney -= AlcoholStockPrice;

                if (GameMoney < 0)
                    GameMoney = 0;





                RestockUnitsAlcohol += AlcoholUnitPerBuy;

                UIstats.UpdateUIValues();
            }
        }

    }

    public void Restock()
    {
        UnitsFood += RestockUnitsFood;
        RestockUnitsFood = 0;
        UnitsAlcohol += RestockUnitsAlcohol;
        RestockUnitsAlcohol = 0;

        UIstats.UpdateUIValues();
    }


    public void RiseFoodPrice()
    {

        PriceFood += RisePriceRate;


    }

    public void RiseAlcoholPrice()
    {

        PriceAlcohol += LowePriceRate;


    }


    public void LowerFoodPrice()
    {

        PriceFood -= RisePriceRate;
        if (PriceFood < 0)
            PriceFood = 0.00f;



    }

    public void LowerAlcoholPrice()
    {

        PriceAlcohol -= LowePriceRate;

        if (PriceAlcohol < 0)
            PriceAlcohol = 0.00f;



    }


    ///Win&Lose conditions 

    public void Win()
    {

        
        changer.FadeTolevel(0);

    }

    public void Lose()
    {
      
        changer.FadeTolevel(0);

    }

}
