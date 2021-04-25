using UnityEngine;

public class Headlamp : MonoBehaviour
{
  [SerializeField]
  Reticle reticle;

  void Update()
  {
    transform.up = reticle.transform.position - transform.position;
  }
}
