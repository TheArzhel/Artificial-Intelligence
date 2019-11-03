using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum StateWork
{
    WAIT, 
    WALK,
    CARGO
}

public class CharacterWork : MonoBehaviour
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


    public List<GameObject> WalkList;
    public List<GameObject> CargoList;

    StateWork action = StateWork.WAIT;
    private GameObject Objective;

    private bool taskDone = false;
    Vector3 nextPoint;

    private int iteratorWalk = 0;
    //Contol bools

    private bool nextMoveWlak = true;
    private bool nextMoveCargo = false;

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
        action = StateWork.WAIT;
        ListWalk("Walk Work");
        ListCargo("Cargo Work");
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
                if (action == StateWork.WAIT)
                {
                    
                    if (nextMoveWlak)
                    {
                        while (iteratorWalk < WalkList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = WalkList[iteratorWalk];
                            Debug.Log("last!!!");

                            CalculatePath(Objective);
                            action = StateWork.WALK;
                            if (iteratorWalk == WalkList.Count - 1)
                            {
                                
                                nextMoveWlak = false;
                                nextMoveCargo = true;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = StateWork.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                    if (nextMoveCargo)
                    {
                        while (iteratorWalk < CargoList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = CargoList[iteratorWalk];


                            CalculatePath(Objective);
                            action = StateWork.CARGO;
                            if (iteratorWalk == CargoList.Count - 1)
                            {

                                nextMoveWlak = true;
                                nextMoveCargo = false ;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = StateWork.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                }
                
                else if (action == StateWork.WALK)
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
                        action = StateWork.WAIT;
                        nextMoveCargo = false;
                        nextMoveWlak = true;
                        taskDone = false;
                        Debug.Log("last!");
                    }
                }

                else if (action == StateWork.CARGO)
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
                        action = StateWork.WAIT;
                        Debug.Log("last");
                        nextMoveCargo = true;
                        nextMoveWlak = false;
                        taskDone = false;
                    }
                }
            }

            else
            {
                if (action == StateWork.WAIT)
                {

                    
                    if (nextMoveCargo)
                    {
                        while (iteratorWalk < CargoList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = CargoList[iteratorWalk];


                            CalculatePath(Objective);
                            action = StateWork.CARGO;
                            if (iteratorWalk == CargoList.Count - 1)
                            {

                                //nextMoveWlak = true;
                                 nextMoveCargo = true ;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = StateWork.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                }

                
                else if (action == StateWork.CARGO)
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
                        action = StateWork.WAIT;
                        Debug.Log("last");
                        nextMoveCargo = true;
                        //nextMoveWlak = true;
                        taskDone = false;
                    }
                }
            }

        }
        if (timerON)
        {
            Timer += Time.deltaTime;

            if (Timer % 60 >= 1)//timetostop)
            {
                    Timer = 0.0f;
                    timerON = false;

                
            }
        }

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

    void ListCargo(string tag)
    {

        CargoList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            CargoList.Add(ObjectF);
        }

        Objective = CargoList[0];
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
  

