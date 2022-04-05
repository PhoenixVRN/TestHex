using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hex
{
    public class Player : MonoBehaviour
    {
        private GameObject _player;
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

       
        void Update()
        {

        }
    }
}
