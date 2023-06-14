using System;
using System.Collections.Generic;
//using Core.UI.Window;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EGameState
{
    Start,
    Play,
    GameOver,
    Shop,
    Win
}

namespace Core.UI
{
    public class CanvasManager : MonoBehaviour
    {
        public static CanvasManager Instance;

        [SerializeField] private List<WindowView> windows;

        private EGameState _gameState;
        private EGameState _previousState;

        public EGameState GameState
        {
            get
            {
                return _gameState;
            }
            set
            {
                _previousState = _gameState;
                _gameState = value;
            }
        }

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
            _gameState = EGameState.Start;
        }

        //private void Update()
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        //if (CameraPath.Instance != null && EventSystem.current.IsPointerOverGameObject() == false && _gameState == EGameState.Start)
        //        //    StartGame();
        //        if (QualitySettings.GetQualityLevel() == 1)
        //        {
        //            if (CameraPath.Instance != null && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) == false && _gameState == EGameState.Start)
        //                StartGame();
        //        }
        //        else
        //            if (CameraPath.Instance != null && !EventSystem.current.IsPointerOverGameObject() && _gameState == EGameState.Start)
        //            StartGame();
        //    }
        //}
        public void ReturnState() => _gameState = _previousState;

        /// <summary>
        /// Метод открытия окна по типу
        /// </summary>
        /// <param name="windowType"> тип вызываемого окна</param>
        /// <param name="parent"> указать родителя на канвасе</param>
        public void ShowWindow(EWindowType windowType, Transform parent)
        {
            for (int i = 0; i < windows.Count; i++)
                if (windows[i].GetWindowType == windowType)
                {
                    InstantiateWindow(windows[i], parent);
                    return;
                }
        }

        public void ShowWindow(EWindowType windowType, EGameState state, Transform parent)
        {
            switch (state)
            {
                case EGameState.Win:
                    if(_gameState == EGameState.GameOver) return;
                    break;
                case EGameState.Start:
                    break;
                case EGameState.Play:
                    break;
                case EGameState.GameOver:
                    if(_gameState == EGameState.Win) return;
                    if(_gameState == EGameState.GameOver) return;
                    break;
                case EGameState.Shop:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }

            for (int i = 0; i < windows.Count; i++)
                if (windows[i].GetWindowType == windowType)
                {
                    InstantiateWindow(windows[i], parent);
                    _previousState = _gameState;
                    _gameState = state;
                    return;
                }
        }

        /// <summary>
        /// Старт игры, убирает UI элементы старта игры
        /// </summary>
        public void StartGame()
        {
            //CameraPath.Instance.StartPath();
            _gameState = EGameState.Play;
            //StartGameView.Instance.GetComponent<WindowView>().HideWindow();
        }

        private void InstantiateWindow(WindowView window, Transform parent)
        {
            WindowView newWindow = Instantiate(window, transform.position, Quaternion.identity);
            newWindow.transform.transform.SetParent(parent, false);
            newWindow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
