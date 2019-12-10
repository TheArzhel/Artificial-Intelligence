using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;


public class TableScrip : MonoBehaviour
{
    //public curves how to get in kithcen
    public BGCcMath curve1;
    public BGCcMath curve2;
    public BGCcMath curve3;
    public BGCcMath curve4;
    public BGCcMath curve5;
    public BGCcMath curve6;
    public BGCcMath curve7;
    public BGCcMath curve8;
    public BGCcMath curve9;
    public BGCcMath curve10;

    //timer variables
    private float Timer1 = 0.0f;
    private bool timerON1 = false;
    public int TimeToStop1 = 0;

    private float Timer2 = 0.0f;
    private bool timerON2 = false;
    public int TimeToStop2 = 0;

    private float Timer3 = 0.0f;
    private bool timerON3 = false;
    public int TimeToStop3 = 0;

    private float Timer4 = 0.0f;
    private bool timerON4 = false;
    public int TimeToStop4 = 0;

    private float Timer5 = 0.0f;
    private bool timerON5 = false;
    public int TimeToStop5 = 0;

    private float Timer6 = 0.0f;
    private bool timerON6 = false;
    public int TimeToStop6 = 0;

    private float Timer7 = 0.0f;
    private bool timerON7 = false;
    public int TimeToStop7 = 0;

    private float Timer8 = 0.0f;
    private bool timerON8 = false;
    public int TimeToStop8 = 0;

    private float Timer9 = 0.0f;
    private bool timerON9 = false;
    public int TimeToStop9 = 0;

    private float Timer10 = 0.0f;
    private bool timerON10 = false;
    public int TimeToStop10 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        if (timerON2)
        {
            Timer2 += Time.deltaTime;

            if (Timer2 % 60 >= TimeToStop2)//timetostop)
            {
                Timer2 = 0.0f;
                timerON2 = false;


            }
        }
        if (timerON3)
        {
            Timer3 += Time.deltaTime;

            if (Timer3 % 60 >= TimeToStop3)//timetostop)
            {
                Timer3 = 0.0f;
                timerON3 = false;


            }
        }

        if (timerON4)
        {
            Timer4 += Time.deltaTime;

            if (Timer4 % 60 >= TimeToStop4)//timetostop)
            {
                Timer4 = 0.0f;
                timerON4 = false;


            }
        }
        if (timerON5)
        {
            Timer5 += Time.deltaTime;

            if (Timer5 % 60 >= TimeToStop5)//timetostop)
            {
                Timer5 = 0.0f;
                timerON5 = false;


            }
        }
        if (timerON6)
        {
            Timer6 += Time.deltaTime;

            if (Timer6 % 60 >= TimeToStop6)//timetostop)
            {
                Timer6 = 0.0f;
                timerON6 = false;


            }
        }
        if (timerON7)
        {
            Timer7 += Time.deltaTime;

            if (Timer7 % 60 >= TimeToStop7)//timetostop)
            {
                Timer7 = 0.0f;
                timerON7 = false;


            }
        }
        if (timerON8)
        {
            Timer8 += Time.deltaTime;

            if (Timer8 % 60 >= TimeToStop8)//timetostop)
            {
                Timer8 = 0.0f;
                timerON8 = false;


            }
        }
        if (timerON9)
        {
            Timer9 += Time.deltaTime;

            if (Timer9 % 60 >= TimeToStop9)//timetostop)
            {
                Timer9 = 0.0f;
                timerON9 = false;


            }
        }
        if (timerON10)
        {
            Timer10 += Time.deltaTime;

            if (Timer10 % 60 >= TimeToStop10)//timetostop)
            {
                Timer10 = 0.0f;
                timerON10 = false;


            }
        }
    }

    public BGCcMath AskPath()
    {
        BGCcMath curve = null;
        int random = Random.Range(1, 10);

        Debug.Log(random);

        if (random <= 1 && timerON1 == false)
        {
            curve = curve1;
            timerON1 = true;
            Debug.Log("inside");
        }
        else if (random <= 2 && timerON2 == false)
        {
            curve = curve2;
            timerON2 = true;
            Debug.Log("inside");
        }
        else if (random <= 3 && timerON3 == false)
        {
            curve = curve3;
            timerON3 = true;
            Debug.Log("inside");
        }
        else if (random <= 4 && timerON4 == false)
        {
            curve = curve4;
            timerON4 = true;
            Debug.Log("inside");
        }
        else if (random <= 5 && timerON5 == false)
        {
            curve = curve5;
            timerON5 = true;
            Debug.Log("inside");
        }
        else if (random <= 6 && timerON6 == false)
        {
            curve = curve6;
            timerON6 = true;
            Debug.Log("inside");
        }
        else if (random <= 7 && timerON7 == false)
        {
            curve = curve7;
            timerON7 = true;
            Debug.Log("inside");
        }
        else if (random <= 8 && timerON8 == false)
        {
            curve = curve8;
            timerON8 = true;
            Debug.Log("inside");
        }
        else if (random <= 9 && timerON9 == false)
        {
            curve = curve9;
            timerON9 = true;
            Debug.Log("inside");
        }
        else if (random <= 10 && timerON10 == false)
        {
            curve = curve10;
            timerON10 = true;
            Debug.Log("inside");
        }

        if (curve == null)
        {
            if ( timerON1 == false)
            {
                curve = curve1;
                timerON1 = true;
                Debug.Log("inside");
            }
            else if ( timerON2 == false)
            {
                curve = curve2;
                timerON2 = true;
                Debug.Log("inside");
            }
            else if ( timerON3 == false)
            {
                curve = curve3;
                timerON3 = true;
                Debug.Log("inside");
            }
            else if ( timerON4 == false)
            {
                curve = curve4;
                timerON4 = true;
                Debug.Log("inside");
            }
            else if ( timerON5 == false)
            {
                curve = curve5;
                timerON5 = true;
                Debug.Log("inside");
            }
            else if ( timerON6 == false)
            {
                curve = curve6;
                timerON6 = true;
                Debug.Log("inside");
            }
            else if (timerON7 == false)
            {
                curve = curve7;
                timerON7 = true;
                Debug.Log("inside");
            }
            else if ( timerON8 == false)
            {
                curve = curve8;
                timerON8 = true;
                Debug.Log("inside");
            }
            else if ( timerON9 == false)
            {
                curve = curve9;
                timerON9 = true;
                Debug.Log("inside");
            }
            else if ( timerON10 == false)
            {
                curve = curve10;
                timerON10 = true;
                Debug.Log("inside");
            }

        }
        

        return curve;
    }

        

}
