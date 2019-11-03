using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum StatePolice
{
    WAIT, 
    WALK,
    CARGO
}

public class CharacterPolice : MonoBehaviour
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

    StatePolice action = StatePolice.WAIT;
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
        action = StatePolice.WAIT;
        ListWalk("Walk police");
        ListCargo("Cargo");
        //Debug.Log("init ");
    }

    // Update is called once per frame
    void Update()
    {
        if (day != Day.getdate())
        {
            Debug.Log("Change day night");
           day = Day.getdate();

            if (day)
            {
                nextMoveWlak = true;
                nextMoveCargo = false;

            }
            else {
                nextMoveWlak = false;
                nextMoveCargo = true;
            }

            //time
             Timer = 0.0f;
             timerON = false;
             TimeToStop = 0;
            action = StatePolice.WAIT;
            iteratorWalk = 0;
            Objective = null;
            path = null;
        }

        //Debug.Log("Update: charactes behaviour");
        if (!timerON)
        {


            if (day)
            {
                if (action == StatePolice.WAIT)
                {
                    
                    if (nextMoveWlak)
                    {
                        while (iteratorWalk < WalkList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = WalkList[iteratorWalk];
                            

                            CalculatePath(Objective);
                            action = StatePolice.WALK;
                            if (iteratorWalk == WalkList.Count - 1)
                            {
                                
                                nextMoveWlak = true;
                                //nextMoveCargo = true;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = StatePolice.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                    
                }
                
                else if (action == StatePolice.WALK)
                {
                    if (!taskDone)
                    {
                        if (path != null)
                            taskDone = FollowPath.Steer(path);
                        Debug.Log("peta1");
                    }
                    else if (taskDone)
                    {

                        //Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 2;
                        move.Stop();
                        action = StatePolice.WAIT;
                        //nextMoveCargo = false;
                        nextMoveWlak = true;
                        taskDone = false;
                        Debug.Log("last!");
                    }
                }

                
            }

            else
            {
                if (action == StatePolice.WAIT)
                {

                    
                    if (nextMoveCargo)
                    {
                        while (iteratorWalk < CargoList.Count)
                        {
                            //Debug.Log("1 this ");
                            Objective = CargoList[iteratorWalk];


                            CalculatePath(Objective);
                            action = StatePolice.CARGO;
                            if (iteratorWalk == CargoList.Count - 1)
                            {

                                //nextMoveWlak = true;
                                 nextMoveCargo = true ;
                                //taskDone = false;
                                iteratorWalk = 0;
                                action = StatePolice.WAIT;
                                break;
                            }
                            ++iteratorWalk;
                            break;
                        }

                    }
                }

                
                else if (action == StatePolice.CARGO)
                {
                    if (!taskDone)
                    {
                        if (path!=null)
                        taskDone = FollowPath.Steer(path);
                        Debug.Log("peta2");
                    }
                    else if (taskDone)
                    {

                        //Objective.GetComponent<Table>().ocupy = true;
                        //timer and wait, when timer finish deactive table
                        timerON = true;
                        TimeToStop = 2;
                        move.Stop();
                        action = StatePolice.WAIT;
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

            if (Timer % 60 >= TimeToStop)//timetostop)
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
        

         Debug.Log("Walk Police list size" + WalkList.Count);
        

    }

    void ListCargo(string tag)
    {

        CargoList = new List<GameObject>();


        foreach (GameObject ObjectF in GameObject.FindGameObjectsWithTag(tag))
        {
            CargoList.Add(ObjectF);
        }

        Objective = CargoList[0];
        

         Debug.Log("Cargo Police list size" + CargoList.Count);
        

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
  

