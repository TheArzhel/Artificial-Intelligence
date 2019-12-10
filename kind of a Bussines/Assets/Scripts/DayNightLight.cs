using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightLight : MonoBehaviour
{
    
    private float Timer = 0.0f;
    private int timeofday;
    public Light lt;
    Color color0 = new Color(255/255f,190/255f,13/255f);
    Color color1 = new Color(0/255f,32/255f,255/255f);

    private GameObject scene;
    public bool dayornight = true;
    


    // Start is called before the first frame update
    void Start()
    {
       
        lt = GetComponent<Light>();


        scene = GameObject.FindGameObjectWithTag("Day");
        
        timeofday = scene.GetComponent<DayNight>().getDaySec();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.GetComponent<DayNight>().dayorNight != dayornight)
        {
            dayornight = scene.GetComponent<DayNight>().dayorNight;

            if (dayornight)
              lt.color = color0;
            else
                lt.color = color1;

        }

        
    }

   
}