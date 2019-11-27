using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{

    public enum ACTIVITY
    {
        Eat
    };

    public ACTIVITY action;

    // Start is called before the first frame update
    void Start()
    {
        
      action = ACTIVITY.Eat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
