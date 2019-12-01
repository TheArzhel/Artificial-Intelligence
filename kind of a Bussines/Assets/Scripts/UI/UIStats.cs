using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStats : MonoBehaviour
{



    private int Money =100;
    private int Popularity = 50;
    private int UnitsFood = 20;
    private int UnitsAlcohol = 0;
    private int PriceFood = 5;
    private int PriceAlcohol = 10;

    public int FoodStockPrice = 10;
    public int AlcoholStockPrice = 10;

    public int FoodUnitPerBuy = 20;
    public int AlcoholUnitPerBuy = 5;

    public Text MoneyText;
    public Text PopularityText;
    public Text UnitsFoodText;
    public Text UnitsAlcoholText;
    public Text PriceFoodText;
    public Text PriceAlcoholText;

    public GameObject Layer;


    void Start()
    {

        Layer.SetActive(false);
        MoneyText.text = Money.ToString();
        PopularityText.text = Popularity.ToString();
        UnitsFoodText.text = UnitsFood.ToString();
        UnitsAlcoholText.text = UnitsAlcohol.ToString();
        PriceFoodText.text = PriceFood.ToString();
        PriceAlcoholText.text = PriceAlcohol.ToString();
    }

    //// Update is called once per frame
    //void Update()
    //{


    //    MoneyText.text = money.ToString();

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {

    //        money+=5;

    //    }


    //}


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

        Money -= FoodStockPrice;

        if (Money < 0)
            Money = 0;

        MoneyText.text = Money.ToString();

        if (Money > FoodStockPrice)
        {
            UnitsFood += FoodUnitPerBuy;
            UnitsFoodText.text = UnitsFood.ToString();
        }
    }

    public void BuyAlcoholUnits()
    {


        Money -= AlcoholStockPrice;

        if (Money < 0)
            Money = 0;

        MoneyText.text = Money.ToString();


        if (Money > AlcoholStockPrice)
        {
            UnitsAlcohol += AlcoholUnitPerBuy;
            UnitsAlcoholText.text = UnitsAlcohol.ToString();
        }
    }


    public void RiseFoodPrice()
    {

        PriceFood += 5;
        PriceFoodText.text = PriceFood.ToString();


       




    }

    public void RiseAlcoholPrice()
    {

        PriceAlcohol += 7;
        PriceAlcoholText.text = PriceAlcohol.ToString();


    }



}
