using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private EWindowType _window;
    
    public void ShowOptionsWindow()
    {
        CanvasView.Instance.ShowWindow(_window);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    
}
