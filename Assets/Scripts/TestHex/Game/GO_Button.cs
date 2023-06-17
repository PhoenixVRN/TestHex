using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GO_Button : MonoBehaviour
{
    [SerializeField] private Image stateImage;
    [SerializeField] private Sprite soundGo;
    [SerializeField] private Sprite soundReboot;
    private bool _state;
    private StartHexManager _truckManager;

    private void Start()
    {
        _truckManager = StartHexManager.Instance;
    }

    public void Go()
    {
        if (!_state) 
            _truckManager.GoTruck();
        else 
            _truckManager.RestartTruck();
        SwitchingImage();
        _state = !_state;
    }
    
        private void SwitchingImage() => stateImage.sprite = _state ? soundGo : soundReboot;
        
        private void Restart()
        {
            //yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
}
