using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryMenu : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevel;
    [SerializeField] private Image[] _star = new Image[3];
    [SerializeField] private Sprite _starLighted;
    [SerializeField] private Sprite _starExtinct;

    private void Start()
    {
        
    }

    private void ReceivedStars(int quantity)
    {
        if (quantity > 3 || quantity < 0)
            return;
        for (int i = 0; i < quantity-1; i++)
        {
            _star[i].sprite = _starLighted;
        }
    }
    
    public void Win(int quantityStars)
    {
        ReceivedStars(quantityStars);
        _nextLevel.SetActive(true);
    }

    public void Loss()
    {
        _nextLevel.SetActive(false);
    }

    private void Restart()
    {
        for (int i = 0; i < 2; i++)
        {
            _star[i].sprite = _starExtinct;
        }
    }
}
