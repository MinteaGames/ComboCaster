using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverStats : MonoBehaviour
{

    private string name;

    public GameObject description;

    private Text descText;

    // Start is called before the first frame update
    private void Start()
    {
        name = gameObject.name;
        description = GameObject.Find("Desc");
        descText = description.GetComponent<Text>();
    }

    

    private void OnMouseEnter()
    {
        print("hit");

        descText.text = StatMenu.inteM.ToString() + " Ranged Damage";

        if (name == "Int")
        {

            print("hit");

            descText.text = StatMenu.inteM.ToString() + " Ranged Damage";

        }



    }

    private void OnMouseExit()
    {
        
    }



}
