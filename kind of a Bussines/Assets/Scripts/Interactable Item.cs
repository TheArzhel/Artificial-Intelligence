using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    // Start is called before the first frame update
   // public string name;
    public Sprite Image;
    public string Interactinfo = "eating";
    public bool InUse = false;
    public virtual void OnInteract()
    {

    }

}
