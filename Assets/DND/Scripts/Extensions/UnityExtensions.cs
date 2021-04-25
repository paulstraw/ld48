using System;
using System.Collections;
using UnityEngine;

public static class UnityExtensions
{

  /// <summary>
  /// Extension method to check if a layer is in a layermask
  /// </summary>
  /// <param name="mask"></param>
  /// <param name="layer"></param>
  /// <returns></returns>
  public static bool Contains(this LayerMask mask, int layer)
  {
    return mask == (mask | (1 << layer));
  }

  public static void Invoke(this MonoBehaviour me, Action theDelegate, float time)
  {
    me.StartCoroutine(ExecuteAfterTime(theDelegate, time));
  }

  private static IEnumerator ExecuteAfterTime(Action theDelegate, float delay)
  {
    yield return new WaitForSeconds(delay);
    theDelegate();
  }
}
