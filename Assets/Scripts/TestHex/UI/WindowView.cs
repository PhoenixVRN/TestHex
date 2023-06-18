using Core.AudioSystem;
using DG.Tweening;
using UnityEngine;

namespace Core.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowView: MonoBehaviour
    {
        [SerializeField] private EWindowType windowType;

        private CanvasGroup _canvas;
        private Tween _tween;

        public WindowView _progenitor;
        
        public EWindowType GetWindowType => windowType;
        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
            _canvas.alpha = 0;
        }
        private void OnEnable() => _tween = _canvas.DOFade(1, 0.25f);
        public void HideWindow()
        {
            _tween = _canvas.DOFade(0, 0.25f);
            _tween.onComplete += () => { Destroy(gameObject);};
        }
        private void OnDisable() => _tween.Kill();
    }
}