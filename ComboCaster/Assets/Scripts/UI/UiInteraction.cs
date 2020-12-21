using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInteraction : MonoBehaviour
{

    public GameObject description;
    private Transform descTransform;
    private Text descText;
    public Camera camera;

    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;



    // Start is called before the first frame update
    void Start()
    {
        descTransform = description.transform;
        camera = Camera.main;
        descText = description.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = camera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y));

        descTransform.position = mouseScreenPosition;


        RaycastHit2D hit = Physics2D.Raycast(mouseScreenPosition, Vector2.zero);


        if (hit.collider != null)
        {

            descText.enabled = true;

            print("hit");

            if (hit.transform.name == "Int")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.inteM.ToString() + "x Ranged Damage";

            }
            else if (hit.transform.name == "Wis")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.wisM.ToString() + "x Attack Speed";

            }
            else if (hit.transform.name == "Dex")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.dexM.ToString() + "x Movement Speed";

            }
            else if (hit.transform.name == "Con")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.conM.ToString() + "x Life Drop Chance";

            }
            else if (hit.transform.name == "Cha")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.chaM.ToString() + "x Ability Cost Reduction";

            }
            else if (hit.transform.name == "Str")
            {

                descText.alignment = TextAnchor.LowerRight;

                descText.text = StatMenu.strM.ToString() + "x Melee/Dodge Damage";

            }
            if (hit.transform.name == "EInt")
            {

                descText.alignment = TextAnchor.LowerLeft;

                descText.text = StatMenu.EinteM.ToString() + "x Enemy Ranged Attack Velocity";

            }
            else if (hit.transform.name == "EWis")
            {

                descText.alignment = TextAnchor.LowerLeft;

                descText.text = StatMenu.EwisM.ToString() + "x Enemy Attack Speed";

            }
            else if (hit.transform.name == "EDex")
            {

                descText.alignment = TextAnchor.LowerLeft;

                descText.text = StatMenu.EdexM.ToString() + "x Enemy Movement Speed";

            }
            else if (hit.transform.name == "ECon")
            {

                descText.alignment = TextAnchor.LowerLeft;

                descText.text = StatMenu.EconM.ToString() + "x Enemy Max Health";

            }
            else if (hit.transform.name == "ECha")
            {

                descText.alignment = TextAnchor.LowerLeft;

                descText.text = StatMenu.EchaM.ToString() + "x Special Ability Frequency";

            }
            else if (hit.transform.name == "EStr")
            {

                descText.alignment = TextAnchor.UpperLeft;

                descText.text = StatMenu.EstrM.ToString() + "x Enemy Melee Speed";

            }
            else if (hit.transform.name == "combo counter HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "0 = 1 Die \n50 = 2 Dice \n100 = 3 Dice";

            }
            else if (hit.transform.name == "magic missile HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Magic Missle-" + "\nCOST: 0"  + "\nDAMAGE: " + (1 * StatMenu.inteM).ToString();

            }
            else if (hit.transform.name == "dodge HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Dodge-" + "\nCOST: 0"  + "\nDAMAGE: " + (2 * StatMenu.strM).ToString();

            }
            else if (hit.transform.name == "melee HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Melee-" + "\nCOST: 0" + "\nDAMAGE: " + (2 * StatMenu.strM).ToString();

            }
            else if (hit.transform.name == "railgun HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Railgun-" + "\nCOST: 3" + "\nDAMAGE: " + (2 * StatMenu.inteM).ToString();

            }
            else if (hit.transform.name == "shockwave HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Shockwave-" + "\nCOST: 15" + "\nDAMAGE: " + (1 * StatMenu.inteM).ToString();

            }
            else if (hit.transform.name == "bounceball HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Bounce Shot-" + "\nCOST: 6" + "\nDAMAGE: " + (3 * StatMenu.inteM).ToString();

            }
            else if (hit.transform.name == "fireball HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Fireball-" + "\nCOST: 5+" + "\nDAMAGE: " + (2 * StatMenu.inteM).ToString() + "+";

            }
            else if (hit.transform.name == "wish HUD")
            {

                descText.alignment = TextAnchor.UpperCenter;

                descText.text = "-Wish-" + "\nCOST: 50" + "\n'Re-Rolls All Player Stats'";

            }








        }


        if (hit.collider == null)
        {
            descText.enabled = false;
        }

            

    }
}
