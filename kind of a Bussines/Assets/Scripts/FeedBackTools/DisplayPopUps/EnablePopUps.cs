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



    // Start is called before the first frame update
    void Start()
    {
        AuxPrefab = PopPrefab;
        offset = new Vector3(0, 4, 0);
        mainCam = GameObject.Find("Main Camera");
        AuxPopUp = PopPrefab.GetComponent<DisplayPopUps>();

    }

    // Update is called once per frame
    void Update()
    {


        if (PopPrefab == null)
            PopPrefab = AuxPrefab;


        if (Input.GetKey("e")){

            Debug.Log("Instantiate");
            //this enums depend on the status of the agent
            AuxPopUp.current = PopUp_Type.Money;
            Instantiate(PopPrefab,transform.position+offset,Quaternion.identity,transform);

 
        }


        if (PopPrefab != null)
        {

            PopPrefab.transform.LookAt(mainCam.transform);

        }




    }




}
