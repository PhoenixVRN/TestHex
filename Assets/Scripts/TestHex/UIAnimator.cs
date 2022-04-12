using System.Collections;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    [SerializeField] private Transform _bttnAuto;
    [SerializeField] private Transform _bttnExit;
    [SerializeField] private Transform _bttnStart;
    [SerializeField] private Transform _gameName;
    
    [SerializeField] private AudioSource _audioGameNameStart;
    [SerializeField] private AudioSource _audioMenuPoint;
    [SerializeField] private AudioSource _audioStartButtonGo;
    
    [Header("Время для изменения размера кнопок")]
    [SerializeField] private float _timeSizeBttn;
    
    [Header("Время для движения иконок")]
    [SerializeField] private float _timeMoveIcon;
    
    [Header("Время для движения Game Name")]
    [SerializeField] private float _timeMoveGameName;
    
    [Header("Время для изменения размера иконок")]
    [SerializeField] private float _timeSizeIcon;

    
    [Header("Время задержки перед изменением размера кнопок")]
    [SerializeField] private float _timeDelaySizeBttn;

  
    void Start()
    {
        _bttnExit.localScale = Vector3.zero;
        _bttnStart.localScale = Vector3.zero;
        
        StartCoroutine(AnimUI());
    }

    

    private IEnumerator AnimUI()
    {
        _gameName.LeanMoveLocal(new Vector3(16f, 0f, 0f), _timeMoveGameName).setEaseInOutBack();
        _bttnAuto.LeanScale(Vector3.one, _timeSizeIcon).setEaseInBack();
        yield return new WaitForSeconds(0.1f);
        _audioGameNameStart.Play();

        
        yield return new WaitForSeconds(3f);
        _bttnExit.LeanScale(new Vector3(1f, 1, 1), _timeSizeBttn).setEaseInBack();
        _audioMenuPoint.Play();
        yield return new WaitForSeconds(0.5f);
        _bttnStart.LeanScale(new Vector3(1f, 1, 1), _timeSizeBttn).setEaseInBack();
        _audioMenuPoint.Play();
        
        yield return new WaitForSeconds(1f);
        _bttnAuto.LeanMoveLocal(new Vector3(0f, 0f, 0f), _timeMoveIcon).setEaseInOutBack();
        _bttnAuto.LeanScale(Vector3.one, _timeSizeIcon).setEaseInBack();
        _audioStartButtonGo.Play();
    }
}
