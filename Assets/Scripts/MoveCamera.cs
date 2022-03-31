using UnityEngine;

public class MoveCamera : MonoBehaviour
{
//    [SerializeField] private Camera _camera;
    [SerializeField] private DynamicJoystick _joystickLeft;
    [SerializeField] private DynamicJoystick _joystickRight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sensetiv;
    private float _vertical;
    private float _horizontal;
    private float _rotate;
    private float _up;
    void Start()
    {
        
    }
    
    void Update()
    {
        GetMobileInputLeft();
        GetMobileInputUp();
    }

    private void GetMobileInputLeft()
    {
        _vertical = _joystickLeft.Vertical;
        _horizontal = _joystickLeft.Horizontal;
        
        if (Input.GetKey(KeyCode.W) || _vertical > 0.2f)
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.S) || _vertical < -0.2f)
            transform.position += -transform.forward * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D) || _horizontal > 0.2f)
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A) || _horizontal < -0.2f)
            transform.position += -transform.right * _moveSpeed * Time.deltaTime;
    }
    
    private void GetMobileInputUp()
    {
        _up = _joystickRight.Vertical;
        _rotate = _joystickRight.Horizontal * _sensetiv * Time.deltaTime;
        
        gameObject.transform.Rotate(_rotate * new Vector3(0, 1, 0));
        
        // проверка на вылет за границы дозволенного камеры
        if (transform.position.y < 7)
        {
            if (Input.GetKey(KeyCode.R) || _up > 0.2f)
                transform.position += transform.up * _moveSpeed * Time.deltaTime;
        }
        
        if (transform.position.y > 2)
        {
            if (Input.GetKey(KeyCode.F) || _up < -0.2f)
                transform.position += -transform.up * _moveSpeed * Time.deltaTime;
        }
    }
}
