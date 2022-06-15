using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerStart : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Auto")
    {
      SceneManager.LoadScene(1);
    }
  }
}
