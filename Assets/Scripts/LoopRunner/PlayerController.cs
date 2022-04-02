using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeedPlayer;
   
    
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += transform.right * _joystick.Horizontal * _moveSpeedPlayer * Time.deltaTime;
    }
}
