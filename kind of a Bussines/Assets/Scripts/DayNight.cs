using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public bool dayorNight = true;
    public int DaySec=10;
    public float Timer = 0.0f;

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DaySec)
        {
            Timer = 0.0f;
            dayorNight = !dayorNight;
            
        }
    }

    public bool getdate() { return dayorNight; }

    public int getDaySec() { return DaySec; }
}
