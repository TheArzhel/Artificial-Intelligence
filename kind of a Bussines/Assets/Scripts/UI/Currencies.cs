using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currencies : MonoBehaviour
{

   public enum AdquisitionalState
    {
        RICH,
        MEDIUM,
        POOR

    }

    public enum Bill_Type
    {
        FOOD,
        ALCOHOL
    }


    public float GameMoney=100.00f;
    

    public int UnitsFood = 20;
    public int UnitsAlcohol = 0;

    public float PriceFood = 5.99f;//selling to
    public float PriceAlcohol = 10.99f;

    public float FoodStockPrice = 10.50f;//buying to
    public float AlcoholStockPrice = 20.50f;

    public float RisePriceRate = 5.99f;// selling to values
    public float LowePriceRate = 10.50f;


    public int FoodUnitPerBuy = 20;//quantity of food/alcohol recieved everytime u buy
    public int AlcoholUnitPerBuy = 5;



    //popularity 
    public int GamePopularity = 50;
    public int PopularityStreak=0;
    public int popularityGoalStreak = 5;//max value to arrive for popularity rise
    public int RisePopularityRate = 5;//Rate of quantitivity increasement popularity
    public int LowePopularityRate = 10;



    public float MaximumBillCost;

    // Start is called before the first frame update
    void Start()
    {
    
        MaximumBillCost=GamePopularity*0.15f;


    }

// Update is called once per frame
void Update()
    {
        
    }


    public bool Pay(Bill_Type type) { 
    
     

        



         switch (type)
         {
        
            case Bill_Type.FOOD:

                CashIn(PriceFood);
                
                break;

            case Bill_Type.ALCOHOL:
                CashIn(PriceAlcohol);
  
                break;
         }




        return true;
    }

    public void CashIn(float income)
    {

        GameMoney += income;


       
    }
   
    public void CashOut(float bill)
    {

        GameMoney -= bill;

    }


    public void IncreasePopularity()
    {

        if(PopularityStreak == popularityGoalStreak)
        {

            GamePopularity += RisePopularityRate;
            PopularityStreak = 0;
                       
        }
                     
    }

    public void DecreasePopularity()
    {

        GamePopularity -= LowePopularityRate;

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

                UnitsFood += FoodUnitPerBuy;
              
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

                



                UnitsAlcohol += AlcoholUnitPerBuy;
                
            }
        }

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









}
