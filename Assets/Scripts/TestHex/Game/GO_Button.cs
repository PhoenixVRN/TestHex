using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GO_Button : MonoBehaviour
{
    [SerializeField] private Image stateImage;
    [SerializeField] private Sprite soundGo;
    [SerializeField] private Sprite soundReboot;
    private bool _state;

    public void Go()
    {
        SwitchingImage();
    }
    
        private void SwitchingImage() => stateImage.sprite = _state ? soundGo : soundReboot;
    
}
