using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStats : MonoBehaviour
{



    private float Money =100.00f;
    private int Popularity = 50;

    private int UnitsFood = 20;
    private int UnitsAlcohol = 0;

    private float PriceFood = 5.99f;//selling to
    private float PriceAlcohol = 10.99f;

    public float FoodStockPrice = 10.50f;//buying to
    public float AlcoholStockPrice = 20.50f;

    public float RisePriceRate = 5.99f;// selling to values
    public float LowePriceRate = 10.50f;


    public int FoodUnitPerBuy = 20;//quantity of food/alcohol recieved everytime u buy
    public int AlcoholUnitPerBuy = 5;




    public Text MoneyText;
    public Text PopularityText;

    public Text UnitsFoodText;
    public Text UnitsAlcoholText;

    public Text PriceFoodText;//selling to
    public Text PriceAlcoholText;

    public Text CostFoodUnitText;//buying to
    public Text CostAlcoholUnitText;

    public GameObject Layer;


    void Start()
    {

        Layer.SetActive(false);
        MoneyText.text = Money.ToString();
        PopularityText.text = Popularity.ToString();

        UnitsFoodText.text = UnitsFood.ToString();
        UnitsAlcoholText.text = UnitsAlcohol.ToString();

        PriceFoodText.text = PriceFood.ToString() + "€/Unit";
        PriceAlcoholText.text = PriceAlcohol.ToString()+"€/Unit";

        FoodStockPrice = 10.50f;
        AlcoholStockPrice = 20.50f;

        CostFoodUnitText.text = FoodStockPrice.ToString() + "€/Unit";
        CostAlcoholUnitText.text = AlcoholStockPrice.ToString() + "€/Unit";
    }

 
  

  public void OpenMenu()
    {

        if (!Layer.activeSelf)
            Layer.SetActive(true);
        else
            Layer.SetActive(false);

    }


    public void CloseMenu()
    {

        Layer.SetActive(false);

    }

    public void BuyFoodUnits()
    {

        if (Money > 0)
        {
            if (Money > FoodStockPrice)
            {
                Money -= FoodStockPrice;

              if (Money < 0)
                Money = 0;

            MoneyText.text = Money.ToString();


          
                UnitsFood += FoodUnitPerBuy;
                UnitsFoodText.text = UnitsFood.ToString();
            }
        }
    }

    public void BuyAlcoholUnits()
    {

        if (Money > 0)
        {
            if (Money > AlcoholStockPrice)
            {
                Money -= AlcoholStockPrice;

            if (Money < 0)
                Money = 0;

            MoneyText.text = Money.ToString();


          
                UnitsAlcohol += AlcoholUnitPerBuy;
                UnitsAlcoholText.text = UnitsAlcohol.ToString();
            }
        }

    }


    public void RiseFoodPrice()
    {
        
            PriceFood += RisePriceRate;
            PriceFoodText.text = PriceFood.ToString() + "€/Unit";
       
    }

    public void RiseAlcoholPrice()
    {

            PriceAlcohol += LowePriceRate;
            PriceAlcoholText.text = PriceAlcohol.ToString() + "€/Unit";
        

    }


    public void LowerFoodPrice()
    {
       
            PriceFood -= RisePriceRate;
        if (PriceFood < 0)
            PriceFood = 0.00f;

        PriceFoodText.text = PriceFood.ToString() + "€/Unit";
        
    }

    public void LowerAlcoholPrice()
    {
       
            PriceAlcohol -= LowePriceRate;

        if (PriceAlcohol < 0)
            PriceAlcohol = 0.00f;
            PriceAlcoholText.text = PriceAlcohol.ToString() + "€/Unit";

        
    }



}
