using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public static bool dayorNight = true;
    private float Timer = 0.0f;

    CharacterObj characters;

    // Start is called before the first frame update
    void Start()
    {
        characters = GetComponent<CharacterObj>();  
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer % 60 >= 10)
        {
            Timer = 0.0f;
            dayorNight = !dayorNight;
            
        }
    }

    public bool getdate() { return dayorNight; }
}
