using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
   public void GameEnd()
   {
      GameManager.instance.FadeOutEnd(10f);
   }
}
