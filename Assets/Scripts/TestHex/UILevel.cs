using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    private int _levelScene;

    public void SetLevel(int level)
    {
        _levelScene = level;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _levelScene.ToString();
    }
    public void DownloadLevel()
    {
        SceneManager.LoadScene(_levelScene);
    }
}
