using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : InteractableItem
{
    public bool ocupy = false;

    void Start()
    {
        ocupy = new bool() ;
        ocupy = false;
        Debug.Log("new bool");
    }
    public override void OnInteract()
    {
        if (ocupy)
        {
            Interactinfo = "not eating";
            ocupy = false;

        }
        else {
            Interactinfo = "no eating";
            ocupy = true;
        }
    }

    public bool GetOcupy()
    { return ocupy; }
}
