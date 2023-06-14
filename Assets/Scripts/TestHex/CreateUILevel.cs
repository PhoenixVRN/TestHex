using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateUILevel : MonoBehaviour ///переделать нумерацию левлов для гибкой настройки
{
    [SerializeField] private GameObject _prefabUiLevel;
    
    void Start()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            InstantiateWindow(i);
        }
    }
    
    private void InstantiateWindow(int level)
    {
        GameObject newLevel = null;
        newLevel = Instantiate(_prefabUiLevel, transform.position, Quaternion.identity);
        newLevel.transform.transform.SetParent(this.transform, false);
        newLevel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        newLevel.GetComponent<UILevel>().SetLevel(level);
    }
}
