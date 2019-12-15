using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourcesUI : MonoBehaviour
{


    //float & integers
    private float Money;
    private int Popularity;

    private int UnitsFood;
    private int UnitsAlcohol;

    private float PriceFood;//selling to
    private float PriceAlcohol;

    private float FoodStockPrice;//buying to
    private float AlcoholStockPrice;

    private float RisePriceRate;// selling to values
    private float LowePriceRate;


    private int FoodUnitPerBuy;//quantity of food/alcohol recieved everytime u buy
    private int AlcoholUnitPerBuy;

    private int RestockFoodUnits;
    private int RestockAlcoholUnits;

    //Text

    public Text MoneyText;
    public Text PopularityText;

    public Text UnitsFoodText;
    public Text UnitsAlcoholText;

    public Text PriceFoodText;//selling to
    public Text PriceAlcoholText;

    public Text CostFoodUnitText;//buying to
    public Text CostAlcoholUnitText;


    public Text RestockUnitsFood;
    public Text RestockUnitsAlcohol;


    public GameObject Layer;
    private GameObject scene;//scenario

    //slider
    public Slider PopularitySlider;

    //Feedback var tools
   // public GameObject FloatingTextMoney;

    //Currency class
    Currencies Curr;
    CharacterActionUI ActionsUI;

    bool PanelIsActive;

    void Start()
    {

        scene = GameObject.FindGameObjectWithTag("Day");
        Curr=scene.GetComponent<Currencies>();


        Money=Curr.GameMoney;
        Popularity= Curr.GamePopularity;

        UnitsFood=Curr.UnitsFood;
        UnitsAlcohol = Curr.UnitsAlcohol;

        PriceFood = Curr.PriceFood;
        PriceAlcohol = Curr.PriceAlcohol;

        FoodStockPrice = Curr.FoodStockPrice;
        AlcoholStockPrice = Curr.AlcoholStockPrice;

        RisePriceRate = Curr.RisePriceRate;
        LowePriceRate = Curr.LowePriceRate;

        RestockFoodUnits=Curr.RestockUnitsFood;
        RestockAlcoholUnits= Curr.RestockUnitsAlcohol;

        Layer.SetActive(false);
        PanelIsActive = false;

        MoneyText.text = Money.ToString();
        PopularityText.text = Popularity.ToString();

        UnitsFoodText.text = UnitsFood.ToString();
        UnitsAlcoholText.text = UnitsAlcohol.ToString();

        PriceFoodText.text = PriceFood.ToString() + "€/Unit";
        PriceAlcoholText.text = PriceAlcohol.ToString()+"€/Unit";

        FoodStockPrice = 10.50f;
        AlcoholStockPrice = 20.50f;

        CostFoodUnitText.text = "-" + FoodStockPrice.ToString() + "€/Unit";
        CostAlcoholUnitText.text = "-" + AlcoholStockPrice.ToString() + "€/Unit";

        RestockUnitsFood.text = RestockFoodUnits.ToString();
        RestockUnitsAlcohol.text= RestockAlcoholUnits.ToString();



        PopularitySlider.value = Curr.GamePopularity; ;




        ActionsUI = gameObject.GetComponent<CharacterActionUI>();

    }

    void Update()
    {

        if (Curr.GamePopularity > 0)
        {
            PopularityText.color = Color.blue;

        }
        else if(Curr.GamePopularity<0)
        {
            PopularityText.color = Color.red;
            
        }
    }

  public void OpenMenu()
    {

        if (Layer.activeSelf==false)
        {

            Layer.SetActive(true);
            PanelIsActive = true;


            //if the other panel is open then close

            ActionsUI.CloseActionMenu();

        }
        else
            Layer.SetActive(false);

    }


    public void CloseMenu()
    {

        Layer.SetActive(false);
        PanelIsActive = false;
    }

    public void BuyFoodUnits()
    {



        Curr.BuyFoodUnits();
        
        MoneyText.text = Curr.GameMoney.ToString();              
        UnitsFoodText.text = Curr.UnitsFood.ToString();
       
    }

    public void BuyAlcoholUnits()
    {




        Curr.BuyAlcoholUnits();

        MoneyText.text = Curr.GameMoney.ToString();
        UnitsAlcoholText.text = Curr.UnitsAlcohol.ToString();
                
               
    
        
        

    }


    public void RiseFoodPrice()
    {


        Curr.RiseFoodPrice();
        PriceFoodText.text = Curr.PriceFood.ToString() + "€/Unit";
       
    }

    public void RiseAlcoholPrice()
    {

        Curr.RiseAlcoholPrice();
        PriceAlcoholText.text = Curr.PriceAlcohol.ToString() + "€/Unit";
        

    }


    public void LowerFoodPrice()
    {



        Curr.LowerFoodPrice();
        PriceFoodText.text = Curr.PriceFood.ToString() + "€/Unit";
        
    }

    public void LowerAlcoholPrice()
    {

        Curr.LowerAlcoholPrice();
        PriceAlcoholText.text = Curr.PriceAlcohol.ToString() + "€/Unit";

        
    }



    public void UpdateUIValues()
    {

        MoneyText.text = Curr.GameMoney.ToString();
        UnitsFoodText.text = Curr.UnitsFood.ToString();
        UnitsAlcoholText.text = Curr.UnitsAlcohol.ToString();
        PriceFoodText.text = Curr.PriceFood.ToString() + "€/Unit";
        PriceAlcoholText.text = Curr.PriceAlcohol.ToString() + "€/Unit";
        PopularityText.text = Curr.GamePopularity.ToString();

        RestockUnitsFood.text = Curr.RestockUnitsFood.ToString();
        RestockUnitsAlcohol.text= Curr.RestockUnitsAlcohol.ToString();



    }


    public void UpdateUIGlobalCurrencies()
    {

        MoneyText.text = Curr.GameMoney.ToString();
        PopularityText.text = Curr.GamePopularity.ToString();
        PopularitySlider.value = Curr.GamePopularity;

    }




   public void ShowMoneySum()
    {


        //Vector3 offset=new Vector3(0,-50, 0);
        //var go=Instantiate(FloatingTextMoney, MoneyText.transform.position + offset, Quaternion.identity, MoneyText.transform);
        //go.GetComponent<Text>().text = "+"+Curr.GameMoney.ToString();


    }


}
