using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum PopUp_Type { Inspect, Detected,Money, Food, Alcohol }

public class DisplayPopUps : MonoBehaviour
{



    public Vector3 offset = new Vector3(0,2,0);
    public Vector3 SpriteScale = new Vector3(3, 3, 3);
    public float DestroyTimePopUp = 3.0f;

    [SerializeField]
    private PopUp_Type current;

    [SerializeField]
    private SpriteAtlas PopAtlas;

    private SpriteRenderer myrender;

    // Start is called before the first frame update
    void Start()
    {

        transform.localPosition += offset;
        transform.localScale = SpriteScale;

        myrender = GetComponent<SpriteRenderer>();

        current = PopUp_Type.Inspect;
        ChangeSprite();

        Destroy(gameObject, DestroyTimePopUp);

    }

    // Update is called once per frame
  

    void ChangeSprite()
    {


        //TODO:switch
        myrender.sprite = PopAtlas.GetSprite(current.ToString());



    }
}
