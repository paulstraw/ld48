using UnityEngine;

public class GameTitle : MonoBehaviour
{
  [SerializeField]
  private float yAnimSpeed = 3;

  [SerializeField]
  private float yAnimAmplitude = 0.003f;

  void Update()
  {
    Vector3 tPos = transform.localPosition;
    tPos.y += yAnimAmplitude * Mathf.Sin(yAnimSpeed * Time.time);
    transform.localPosition = tPos;
  }
}
