using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class DepositScrip : MonoBehaviour
{
    //public curves how to get in kithcen
    public BGCcMath curve1;


    //timer variables
    private float Timer1 = 0.0f;
    private bool timerON1 = false;
    public int TimeToStop1 = 0;

    //drink hide timer
    private float TimerDrink = 0.0f;
    private bool timerONDrink = false;
    public int TimeToStopDrink = 0;


    //Food controllers
    private int foodAmount ;
    public bool FoodExist = true;
    Currencies Currencies;

    //drinks
    private int DrinksAmount = 0;
    public bool ExistDrinks = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject Scene = GameObject.FindGameObjectWithTag("Day");
        Currencies = Scene.GetComponent<Currencies>();
        DrinksAmount = Currencies.UnitsAlcohol;
        DrinksAmount += Currencies.RestockUnitsAlcohol;
        foodAmount = Currencies.UnitsFood;

        if (foodAmount > 0)
        { FoodExist = true; }
        else
            FoodExist = false;
    }

    // Update is called once per frame
    void Update()
    {

        DrinksAmount = Currencies.UnitsAlcohol + Currencies.RestockUnitsAlcohol;
     
        foodAmount = Currencies.UnitsFood;

        if (foodAmount > 0)
        { FoodExist = true; }
        else
            FoodExist = false;

        if (DrinksAmount > 0 )
            ExistDrinks = true;
        else
            ExistDrinks = false;

        TimerUpdate();
    }

    void TimerUpdate()
    {
        if (timerON1)
        {
            Timer1 += Time.deltaTime;

            if (Timer1 % 60 >= TimeToStop1)//timetostop)
            {
                Timer1 = 0.0f;
                timerON1 = false;


            }
        }
        if (timerONDrink)
        {
            TimerDrink += Time.deltaTime;

            if (TimerDrink % 60 >= TimeToStopDrink)//timetostop)
            {
                TimerDrink = 0.0f;
                timerONDrink = false;
                
                ExistDrinks = true;

            }
        }

    }

    public BGCcMath AskPath()
    {
        BGCcMath curve = null;
        
        curve = curve1;
        timerON1 = true;

        return curve;
    }

    public void Hidedrink()
    {
        if (ExistDrinks == true)
        {

            ExistDrinks = false;
            timerONDrink = true;
        }

    }
    public bool SeeDrink()
    {
        
        return ExistDrinks;
    }
}
