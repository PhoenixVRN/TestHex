using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;

namespace Core.UI
{
    public class OpeningWindowUI : MonoBehaviour
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
}
