using UnityEngine;
using Cinemachine;

public class GameplayVCam : MonoBehaviour
{
  [SerializeField]
  Vector2 panSpeed;

  CinemachineInputProvider inputProvider;
  CinemachineVirtualCamera vCam;
  Transform vCamTransform;

  void Awake()
  {
    inputProvider = GetComponent<CinemachineInputProvider>();
    vCam = GetComponent<CinemachineVirtualCamera>();
    vCamTransform = vCam.VirtualCameraGameObject.transform;
  }

  void Update()
  {
    float x = inputProvider.GetAxisValue(0);
    float y = inputProvider.GetAxisValue(1);

    if (x != 0 || y != 0)
    {
      Vector2 panDirection = new Vector2(x, y);
      Pan(panDirection);
    }

    // TODO: zoom?
    // float z = inputProvider.GetAxisValue(2);
  }

  void Pan(Vector2 panDirection)
  {
    // Vector3 camRotationAngles = vCamTransform.rotation.eulerAngles;

    Vector3 forward = new Vector3(vCamTransform.forward.x, 0, vCamTransform.forward.z);
    Vector3 pan = forward * panDirection.y * panSpeed.y + vCamTransform.right * panDirection.x * panSpeed.x;

    transform.position += pan * Time.deltaTime;
  }
}
