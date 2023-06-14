using Core.AudioSystem;
// using Core.Shop;
// using Core.UI.Window;
// using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class CanvasView : MonoBehaviour
    {
        public static CanvasView Instance;

        [SerializeField] private BgMusic prefabBGMusic;

        private CanvasManager _manager;
        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
        }

        private void Start()
        {
            _manager = CanvasManager.Instance;
            _manager.GameState = EGameState.Start;
            //_manager.ShowWindow(EWindowType.GameView, transform);
            _manager.ShowWindow(EWindowType.StartGameView, transform);
            //SwordShopView.Instance.ChoiseNewSword();
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            //Instantiate(prefabBGMusic, Vector3.zero, Quaternion.identity);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                if (QualitySettings.GetQualityLevel() == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && _manager.GameState == EGameState.Start)
                    StartGame();
                //else if (QualitySettings.GetQualityLevel() != 1 && CameraPath.Instance != null && EventSystem.current.IsPointerOverGameObject() == false && _manager.GameState == EGameState.Start) StartGame();
        }

        /// <summary>
        /// Начало игры
        /// </summary>
        public void StartGame()
        {
            //CameraPath.Instance.StartPath();
            _manager.GameState = EGameState.Play;
            //StartGameView.Instance.GetComponent<WindowView>().HideWindow();
        }

        /// <summary>
        /// Открытие попапа
        /// </summary>
        /// <param name="window"> указать название окна из приведенных типов перечисления</param>
        public void ShowWindow(EWindowType window) => _manager.ShowWindow(window, transform);
        public void ShowWindow(EWindowType window, EGameState state) => _manager.ShowWindow(window, state, transform);
    }
}
