﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State
{
    WAIT, 
    LOOKTABLE,
    ASKTABLE,
    KITCHEN,
    WALK,
    PAY,
    BAR
}

public class CharacterObj : MonoBehaviour
{
    //main cycle
    public static bool day = false;

    NavMeshPath path;
    Move move;
    SteeringSeek seek;
    SteeringFollowPath FollowPath;
    SteeringArrive Arrive;

    GameObject scene;
    DayNight Day;

    public LayerMask mask;


    public float min_Distance = 0.1f;
    public float slow_Distance = 0.5f;

    public List<GameObject> TableList;
    public List<GameObject> KitchenList;
    public List<GameObject> PayList;
    public List<GameObject> WalkList;
    public List<GameObject> BarList;

    Table tableScript;
    State action = State.WAIT;
    private GameObject Objective;

    private bool taskDone = false;
    Vector3 nextPoint;

    private int iteratorWalk = 0;
    //Contol bools

    private bool nextMovePay = true;
    private bool nextMoveWlak = false;
    private bool nextMoveKitchen = false;
    private bool nextMoveTable = false;

    //time
    private float Timer = 0.0f;
    private bool timerON = false;
    private int TimeToStop = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!move)
        move = GetComponent<Move>();
        if(!seek)
            seek = GetComponent<SteeringSeek>();
        if (!Arrive)
        Arrive = GetComponent<SteeringArrive>();

        scene = GameObject.FindGameObjectWithTag("Day");

        if (!day)
            Day = scene.GetComponent<DayNight>();

        path = new NavMeshPath();
        FollowPath = GetComponent<SteeringFollowPath>();
        //NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);
        action = State.WAIT;
        ListTable("Table");
        ListKitchen("Kitchen");
        ListPay("Pay");
        ListWalk("Walk Customer");
        ListBar("Bar");
        //Debug.Log("init ");
    }

    // Update is called once per frame
    void Update()
    {
        day = Day.getdate();

        //Debug.Log("Update: charactes behaviour");
        if (!timerON)
        {


            if (day)
            {
                if (action == State.WAIT)
                {
                    if (nextMovePay)
                    {
                        move.Stop();
                        Objective = PayList[0];
                        tableScript = Objective.GetComponent<Table>();

                        if (tableScript.GetOcupy() == false && timerON == false)
                        {
                            CalculatePath(Objective);
                            action = State.PAY;
                            nextMoveKitchen = true;
                            nextMovePay = false;
                            taskDone = false;

                        }
                        else
                        {
                            timerON = true;
                            TimeToStop = 10;
                            // timer wait start
                            move.Stop();
                            //stop();
                        }

                    }
                    else if (nextMoveTable)
                    {
                        for (int i = 0; i < TableList.Count; ++i)
                        {
                            //Debug.Log("1 this ");
                            Objective = TableList[i];
                            tableScript = Objective.GetComponent<Table>();

                            if (tableScript.GetOcupy() == false && timerON == false)
                            {
                                //Debug.Log("2 this");

                                CalculatePath(Objective);
                                action = State.LOOKTABLE;
                                nextMoveWlak = true;
                                nextMoveTable = false;
                                taskDone = false;
                                break;
                            }
                            else
                            {
                                timerON = true;
                                TimeToStop = 5;
                                // timer wait start
                                move.Stop();
                                //stop();
                            }
                        }

                    }
                    else if (nextMoveKitchen)
                    {
                        for (int i = 0; i < KitchenList.Count; ++i)
                        {
                            //Debug.Log("1 this ");
                            Objective = KitchenList[i];
                            tableScript = Objective.GetComponent<Table>();
                            if (tableScript.GetOcupy() == false && timerON == false)
                            {
                                //Debug.Log("2 this");

                                CalculatePath(Objective);
                                action = State.KITCHEN;
                                nextMoveTable = true;
                                nextMoveKitchen = false;
                                taskDone = false;
                                break;
                            }
                            else
                            {
                                timerON = true;
                                // timer wait start
                                TimeToStop = 15;
                                move.Stop();
                                //stop();
                            }
                        }

                    }
                    else if (nextMoveWlak)
                    {
                        while (iteratorWalk < WalkList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = WalkList[iteratorWalk];
                            tableScript = Objective.GetComponent<Table>();

                            CalculatePath(Objective);
                            action = State.WALK;
                            if (iteratorWalk == WalkList.Count - 1)
                            {
                                nextMovePay = true;
                                nextMoveWlak = false;
                                nextMoveTable = false;
                                nextMoveKitchen = false;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = State.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                }
                else if (action == State.LOOKTABLE)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;

                        timerON = true;
                        TimeToStop = 5;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }

                }
                else if (action == State.KITCHEN)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 15;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }
                }
                else if (action == State.PAY)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 3;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }
                }
                else if (action == State.WALK)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        //Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 2;
                        move.Stop();
                        action = State.WAIT;
                        nextMoveWlak = true;
                        taskDone = false;
                    }
                }
            }
           else 
            {
                if (action == State.WAIT)
                {
                    if (nextMovePay)
                    {
                        move.Stop();
                        Objective = PayList[0];
                        tableScript = Objective.GetComponent<Table>();

                        if (tableScript.GetOcupy() == false && timerON == false)
                        {
                            CalculatePath(Objective);
                            action = State.PAY;
                            nextMoveKitchen = true;
                            nextMovePay = false;
                            taskDone = false;

                        }
                        else
                        {
                            timerON = true;
                            TimeToStop = 10;
                            // timer wait start
                            move.Stop();
                            //stop();
                        }

                    }
                    else if (nextMoveTable)
                    {
                        for (int i = 0; i < TableList.Count; ++i)
                        {
                            //Debug.Log("1 this ");
                            Objective = TableList[i];
                            tableScript = Objective.GetComponent<Table>();

                            if (tableScript.GetOcupy() == false && timerON == false)
                            {
                                //Debug.Log("2 this");

                                CalculatePath(Objective);
                                action = State.LOOKTABLE;
                                nextMoveWlak = true;
                                nextMoveTable = false;
                                taskDone = false;
                                break;
                            }
                            else
                            {
                                timerON = true;
                                TimeToStop = 5;
                                // timer wait start
                                move.Stop();
                                //stop();
                            }
                        }

                    }
                    else if (nextMoveKitchen)
                    {
                        for (int i = 0; i < KitchenList.Count; ++i)
                        {
                            //Debug.Log("1 this ");
                            Objective = KitchenList[i];
                            tableScript = Objective.GetComponent<Table>();
                            if (tableScript.GetOcupy() == false && timerON == false)
                            {
                                //Debug.Log("2 this");

                                CalculatePath(Objective);
                                action = State.KITCHEN;
                                nextMoveTable = true;
                                nextMoveKitchen = false;
                                taskDone = false;
                                break;
                            }
                            else
                            {
                                timerON = true;
                                // timer wait start
                                TimeToStop = 15;
                                move.Stop();
                                //stop();
                            }
                        }

                    }
                    else if (nextMoveWlak)
                    {
                        while (iteratorWalk < BarList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = BarList[iteratorWalk];
                            tableScript = Objective.GetComponent<Table>();

                            CalculatePath(Objective);
                            action = State.WALK;
                            if (iteratorWalk == BarList.Count - 1)
                            {
                                nextMovePay = true;
                                nextMoveWlak = false;
                                nextMoveTable = false;
                                nextMoveKitchen = false;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = State.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                }
                else if (action == State.LOOKTABLE)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;

                        timerON = true;
                        TimeToStop = 5;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }

                }
                else if (action == State.KITCHEN)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 15;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }
                }
                else if (action == State.PAY)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 3;
                        move.Stop();
                        action = State.WAIT;
                        taskDone = false;
                    }
                }
                else if (action == State.WALK)
                {
                    if (!taskDone)
                    {
                        taskDone = FollowPath.Steer(path);
                    }
                    else if (taskDone)
                    {

                        //Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 2;
                        move.Stop();
                        action = State.WAIT;
                        nextMoveWlak = true;
                        taskDone = false;
                    }
                }
            }
        }
        if (timerON)
        {
            Timer += Time.deltaTime;

            if (Timer % 60 >= TimeToStop)//timetostop)
            {
                    Timer = 0.0f;
                    timerON = false;

                if (Objective.GetComponent<Table>() != null)
                    Objective.GetComponent<Table>().OnInteract();
            }
        }

    }



    void ListTable(string tag)
        {
        
           TableList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            TableList.Add(ObjectF);
        }

        Objective = TableList[0];
        tableScript = Objective.GetComponent<Table>();

       // Debug.Log("Table list size" + TableList.Count);
       // Debug.Log("Table" + tableScript.GetOcupy());

    }

    void ListKitchen(string tag)
    {

        KitchenList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            KitchenList.Add(ObjectF);
        }

        Objective = KitchenList[0];
        //KitchenList = Objective.GetComponent<Table>();

        // Debug.Log("Table list size" + TableList.Count);
        // Debug.Log("Table" + tableScript.GetOcupy());

    }

    void ListPay(string tag)
    {

        PayList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            PayList.Add(ObjectF);
        }

        Objective = PayList[0];
        //KitchenList = Objective.GetComponent<Table>();

        // Debug.Log("Table list size" + TableList.Count);
        // Debug.Log("Table" + tableScript.GetOcupy());

    }

    void ListWalk(string tag)
    {

        WalkList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            WalkList.Add(ObjectF);
        }

        Objective = WalkList[0];
        //KitchenList = Objective.GetComponent<Table>();

        // Debug.Log("Table list size" + TableList.Count);
        // Debug.Log("Table" + tableScript.GetOcupy());

    }

    void ListBar(string tag)
    {

        BarList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            BarList.Add(ObjectF);
        }

        Objective = BarList[0];
        //KitchenList = Objective.GetComponent<Table>();

        // Debug.Log("Table list size" + TableList.Count);
        // Debug.Log("Table" + tableScript.GetOcupy());

    }


    void CalculatePath(GameObject objevit)
    {
        //Debug.Log(move.target.name);
        move.target = objevit;
        //Debug.Log(objevit.name);
        //Debug.Log(move.target.name);
        if (path != null)
        {
            path.ClearCorners();
            path = null;

        }

        path = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, objevit.transform.position, NavMesh.AllAreas, path);
        Debug.Log("newPath");
    }
}
  

