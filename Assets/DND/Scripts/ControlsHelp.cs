using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsHelp : MonoBehaviour
{
  [SerializeField]
  GameObject gamepadControlsHelp;

  [SerializeField]
  GameObject keyboardControlsHelp;

  void Update()
  {
    if (Gamepad.current == null && Joystick.current == null)
    {
      keyboardControlsHelp.SetActive(true);
      gamepadControlsHelp.SetActive(false);
    }
    else
    {
      keyboardControlsHelp.SetActive(false);
      gamepadControlsHelp.SetActive(true);
    }
  }
}
