using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : InteractableItem
{
    public bool ocupy =false;

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
