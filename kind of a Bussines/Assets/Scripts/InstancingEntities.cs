using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancingEntities : MonoBehaviour
{

    public GameObject CostumerPrefab;
    public GameObject CostumerPrefab2;
    public GameObject CostumerPrefab3;
    public GameObject CostumerPrefab4;
    public GameObject CostumerPrefab5;
    public GameObject CostumerPrefab6;
    public GameObject CostumerPrefab7;
    public GameObject CostumerPrefab8;
    public GameObject CostumerPrefab9;
    public GameObject CostumerPrefab10;


    public GameObject PolicePrefab;
    public GameObject PolicePrefab2;
    public GameObject PolicePrefab3;

    public GameObject Point0;
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;


    DayNight Cycle;
    Currencies Curr;
    public float Timer = 0.0f; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject aux=GameObject.FindGameObjectWithTag("Day");
        Cycle = aux.GetComponent<DayNight>();
        Curr=aux.GetComponent<Currencies>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;



        if (Curr.GamePopularity <= 0)
        {
            if (Timer > 10)
            {

                CostumerPrefab.SetActive(true);
                CostumerPrefab2.SetActive(true);
                CostumerPrefab3.SetActive(true);
                PolicePrefab.SetActive(true);


                Timer = 0.00f;


            }


        }
        else if(Curr.GamePopularity>0 && Curr.GamePopularity < 100)
        {

            if (Timer > 5)
            {


                CostumerPrefab4.SetActive(true);
                CostumerPrefab5.SetActive(true);
                CostumerPrefab6.SetActive(true);
                PolicePrefab2.SetActive(true);

                Timer = 0.00f;


            }


        }
        else if (Curr.GamePopularity > 100 && Curr.GamePopularity < 200)
        {

            if (Timer > 5)
            {


                CostumerPrefab7.SetActive(true);
                CostumerPrefab8.SetActive(true);
                CostumerPrefab9.SetActive(true);
                CostumerPrefab10.SetActive(true);
                PolicePrefab3.SetActive(true);


                Timer = 0.00f;


            }



        }
     
    }



    //public GameObject ReturnPref()
    //{

    //    GameObject Aux=null;
    //    int i = Random.Range(0,7);

    //    switch (i){

    //        case 0:
    //            Aux= CostumerPrefab;
    //            break;
    //        case 1:
    //            Aux = CostumerPrefab2;
    //            break;

    //        case 2:
    //            Aux = CostumerPrefab3;
    //            break;
    //        case 3:
    //            Aux = CostumerPrefab4;
    //            break;
    //        case 4:
    //            Aux = CostumerPrefab5;
    //            break;
    //        case 5:
    //            Aux = CostumerPrefab6;
    //            break;
    //        case 6:
    //            Aux = CostumerPrefab7;
    //            break;
    //    }


    //  return Aux;

    //}


    //public void instantiateXnum(GameObject obj,int x)
    //{

    //    for (int i=0;i<x;++i)
    //    {

    //        int y = Random.Range(0,3);

    //        switch (y)
    //        {
    //            case 0:
    //                Instantiate(obj,Point0.transform.position,Quaternion.identity);
    //                break;
    //            case 1:
    //                Instantiate(obj, Point1.transform.position, Quaternion.identity);
    //                break;
    //            case 2:
    //                Instantiate(obj, Point2.transform.position, Quaternion.identity);
    //                break;
    //            case 3:
    //                Instantiate(obj, Point3.transform.position, Quaternion.identity);
    //                break;

    //        }
            
          


    //    }



    //}
}
