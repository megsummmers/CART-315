using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateStar : MonoBehaviour
{
  int posY;
  bool collected = false;

  void Start()
  {
    posY = 4;
  }

  void FixedUpdate()
  {
    // if(collected){
    //   transform.Translate(0, posY, 0)
    // }
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
      Debug.Log("Picked up star");
      collected = true;
      //activate Halo around star
      Component halo = GetComponent("Halo");
      halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
      //enable light to help guide the user
      Component light = GetComponent("Light");
      light.GetType().GetProperty("enabled").SetValue(light, true, null);
    }
  }
}
