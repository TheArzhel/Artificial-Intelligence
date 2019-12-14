using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePopUps : MonoBehaviour
{


    public GameObject PopPrefab;
    GameObject AuxPrefab;//everytime the instance is destroy this one assigns it again to the serialized field

    Vector3 offset;

    GameObject mainCam;
    DisplayPopUps AuxPopUp;//to change the sprite displaying
    Status AgentState;


    // Start is called before the first frame update
    void Start()
    {
        AuxPrefab = PopPrefab;
        offset = new Vector3(0, 4, 0);
        mainCam = GameObject.Find("Main Camera");
        AuxPopUp = PopPrefab.GetComponent<DisplayPopUps>();
        AgentState = GetComponent<Status>();

    }

    // Update is called once per frame
    void Update()
    {


        if (PopPrefab == null)
            PopPrefab = AuxPrefab;


        if (PopPrefab != null)
        {

            PopPrefab.transform.LookAt(mainCam.transform);

        }



        if (Input.GetKey("e"))
            ShowPopUp();


    }

    public void ShowPopUp()
    {
       

        //this enums depend on the status of the agent

        if (AgentState != null) {
            switch (AgentState.AgentMood)
            {

                case Mood.HUNGRY:
                    AuxPopUp.current = PopUp_Type.Food;

                    break;
                case Mood.THIRSTY:
                    AuxPopUp.current = PopUp_Type.Alcohol;
                    break;

                case Mood.ANGRY:
                    AuxPopUp.current = PopUp_Type.Angry;
                    break;

                case Mood.FOCUSED:
                    AuxPopUp.current = PopUp_Type.Detected;
                    break;
                case Mood.CONFUSE:
                    AuxPopUp.current = PopUp_Type.Inspect;
                    break;
                case Mood.PAYING:
                    AuxPopUp.current = PopUp_Type.Money;
                    break;

                case Mood.NONE:
                    AuxPopUp.current = PopUp_Type.Waiting;
                    break;

            }
            
          
           // Debug.Log("Instantiate");
            Instantiate(PopPrefab, transform.position + offset, Quaternion.identity, transform);

        }
        else
        {

           // Debug.Log("No status component detected");



        }
    }




}
