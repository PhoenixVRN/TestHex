using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    [SerializeField] private Transform _bttnAuto;
    [SerializeField] private Transform _bttnExit;
    [SerializeField] private Transform _bttnStart;
    
    [Header("Время для изменения размера кнопок")]
    [SerializeField] private float _timeSizeBttn;
    
    [Header("Время для движения иконок")]
    [SerializeField] private float _timeMoveIcon;
    
    [Header("Время для изменения размера иконок")]
    [SerializeField] private float _timeSizeIcon;

    
    [Header("Время задержки перед изменением размера кнопок")]
    [SerializeField] private float _timeDelaySizeBttn;

  
    void Start()
    {
 //       _bttnAuto.localScale = Vector2.zero;
        _bttnExit.localScale = Vector3.zero;
        _bttnStart.localScale = Vector3.zero;
        ShowBttn();
    }

   
    void Update()
    {
        
    }
    
    private void ShowBttn()
    {
        _bttnAuto.LeanMoveLocal(new Vector3(0f, 0f, 0f), _timeMoveIcon).setEaseInOutBack();
        _bttnAuto.LeanScale(Vector3.one, _timeSizeIcon).setEaseInBack();
        //LeanScale
//        _bttnAuto.LeanScale(Vector2.one, _timeSizeBttn).setEaseOutBack().delay = _timeDelaySizeBttn;
//        _bttnExit.LeanScale(Vector2.one, _timeSizeBttn).setEaseOutBack().delay = _timeDelaySizeBttn;
//        _bttnStart.LeanScale(Vector2.one, _timeSizeBttn).setEaseOutBack().delay = _timeDelaySizeBttn;
        _bttnExit.LeanScale(new Vector3(1f, 1, 1), _timeSizeBttn).setEaseInBack();
        _bttnStart.LeanScale(new Vector3(1f, 1, 1), _timeSizeBttn).setEaseInBack();
    }
}
