using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class painter : MonoBehaviour
{
    public GameObject user_control;
    public int color_choice = 1;
    public Color[] colors = {Color.white, Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta, Color.gray, Color.black};
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q)){
        if (color_choice >= 1){
          color_choice-= 1;
        } else if(color_choice == 0){
          color_choice = 8;
        }
        user_control.GetComponent<Image>().color = colors[color_choice];
      }

      if (Input.GetKeyDown(KeyCode.E)){
        if (color_choice <= 7){
          color_choice+= 1;
        } else if(color_choice == 8){
          color_choice = 0;
        }
        user_control.GetComponent<Image>().color = colors[color_choice];
      }

      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log(":D");
        Ray theray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit rayHitInfo;
        if (Physics.Raycast( theray, out rayHitInfo ))
        {
          Debug.Log("Mouse hit");
          var objRenderer = rayHitInfo.collider.gameObject.GetComponent<Renderer>();
          objRenderer.material.SetColor("_Color", colors[color_choice]);
        }
      }
    }
}
