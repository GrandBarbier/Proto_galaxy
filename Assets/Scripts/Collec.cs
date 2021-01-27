using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collec : MonoBehaviour
{
   public ScoreManager scoreManager;

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         scoreManager.score++;
         
         Destroy(gameObject);
      }
   }
}
