using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class NewBehaviourScript : MonoBehaviour
{
    public BGCcMath curve1;
    public BGCcMath curve2;
    public BGCcMath curve3;
    public BGCcMath curve4;
    public LayerMask layermask;

    public int eating = 0;

    private float radius = 1.3f;
    Activity state;
    

    // Start is called before the first frame update
    void Start()
    {
        //layermask = 0 <<10;
        //layermask = ~layermask;
    }

    // Update is called once per frame
    void Update()
    {
        Count();
    }

    bool askDisponibility()
    {
        if (eating < 4)
            return true;
        else
            return false;
    }

    BGCcMath askPath()
    {
        if (eating == 0)
        {
            return curve1;
        }
        else if (eating == 1)
        {
            return curve2;
        }
        else if (eating == 2)
        {
            return curve3;
        }
        else if (eating == 3)
        {
            return curve4;
        }
        else 
            return curve4;

    }

    
    void Count()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius , layermask);
        eating = 0;
        foreach (Collider cols in hitColliders)
        {
            state = null;
            state = cols.gameObject.GetComponent<Activity>();
            if (state != null)
            {
                if (state.action == 0)
                { 
                    eating++;
                }
            }
        }
     }

}
