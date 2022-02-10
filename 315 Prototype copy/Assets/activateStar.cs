using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateStar : MonoBehaviour
{
  bool collected = false;
  bool endScene = false;
  int starCount = 0;

  void Start()
  {

  }

  void FixedUpdate()
  {
    if (collected == true)
    {
      transform.Translate(0, Time.deltaTime, 0, Space.World);
      float posY = gameObject.transform.position.y;
      if (posY >= 5.5){
        collected = false;
        starCount++;
      }
    }

    if(starCount == 10 && !endScene)
    {
      transform.Translate(0, Time.deltaTime, 0, Space.World);
      float posY = gameObject.transform.position.y;
      if (posY >= 15){
        endScene = true;
      }
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
      Debug.Log("Picked up star");
      //activate Halo around star
      Component halo = GetComponent("Halo");
      halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
      //enable light to help guide the user
      Component light = GetComponent("Light");
      light.GetType().GetProperty("enabled").SetValue(light, true, null);
      //raise the star
      collected = true;
    }
  }
}
