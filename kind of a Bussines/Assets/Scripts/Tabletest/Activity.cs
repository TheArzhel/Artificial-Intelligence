using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class Activity : MonoBehaviour
{
    public GameObject[] tables;

    private GameObject Destiny;
    private BGCcMath curve;
    private bool ret = false;
    Move move;
    FollowCurve PathControl;
    TableManager tablemanager = null;

    public enum ACTIVITY
    {
        Eat
    };

    public ACTIVITY action;

    // Start is called before the first frame update
    void Start()
    {
        tables = GameObject.FindGameObjectsWithTag("Table");
      //  Debug.Log("Tables numbers  " + tables.Length);
        action = ACTIVITY.Eat;
        move = GetComponent<Move>();
        PathControl = GetComponent<FollowCurve>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (!ret)
        {
            ret = FindTable();
            //Debug.Log(ret);
            if (ret)
            {
                
                tablemanager = Destiny.GetComponent<TableManager>();
                curve = tablemanager.AskPath();
                PathControl.SetCurve(curve);
            }
        }
    }

    bool FindTable()
    {
        foreach (GameObject GO in tables)
        {
            tablemanager = null;
            tablemanager = GO.GetComponent<TableManager>();
            if (tablemanager != null )
            {
                if (tablemanager.AskDisponibility())
                {
                    Destiny = GO;
                   // Debug.Log("Found");
                    return true;

                }
            }
        }
        return false;
    }

}
