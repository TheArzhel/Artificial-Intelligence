using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightLight : MonoBehaviour
{
    public static bool dayorNight = true;
    private float Timer = 0.0f;
    public Light lt;
    Color color0 = new Color(255/255f,253/255f,207/255f);
    Color color1 = new Color(207/255f,235/255f,255/255f);

    CharacterObj characters;

    // Start is called before the first frame update
    void Start()
    {
        characters = GetComponent<CharacterObj>();
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer % 60 >= 10)
        {
            Timer = 0.0f;
            dayorNight = !dayorNight;

            if (dayorNight)
              lt.color = color0;
            else
                lt.color = color1;

        }
    }

    public bool getdate() { return dayorNight; }
}