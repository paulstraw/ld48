using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
  public void TryAgain()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
