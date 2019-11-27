using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class PerceptionEvent
{

    public enum sense {VISION};
    public enum types {NEW,LOST};


    public GameObject GO;
    public sense Sense;
    public types Type;



}
public class PerceptionManager : MonoBehaviour
{
     void EventPercieved(PerceptionEvent Event)
    {


        // if GO detected 
        if (Event.Type == global::PerceptionEvent.types.NEW)
        {
            Debug.Log("GO Detected");




        }
        // if GO lost with any means of detection
        else if (Event.Type == global::PerceptionEvent.types.LOST)
        {

            Debug.Log("GO Lost");




        }

    }
}
