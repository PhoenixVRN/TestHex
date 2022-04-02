using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeedPlayer;
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private TextMeshProUGUI _textLife;
    [SerializeField] private TextMeshProUGUI _textSpeed;
    [SerializeField] private AudioSource _mony;
    [SerializeField] private AudioSource _fail;

    private int _score;
    private int _life;

    private void Start()
    {
        _score = 0;
        _life = 5;
        _textLife.text = "Life " + _life;
        _textScore.text = "Score " + _score;
        _textSpeed.text = "Speed 2" ;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += transform.right * _joystick.Horizontal * _moveSpeedPlayer * Time.deltaTime;
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Enamy")
        {
            Destroy(other.gameObject);
            Hit();
        }

        if (other.gameObject.tag == "Wall")
        {
            Hit();
        }

        if (other.gameObject.tag == "Experience")
        {
            _mony.Play();
            Destroy(other.gameObject);
            _score++;
            _textScore.text = "Score " + _score;
            AccelerationCube();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Hit();
        }
    }

    private void Hit()
    {
        _fail.Play();
        _life--;
        _textLife.text = "Life " + _life;
        if (_life <= 0 ) Application.LoadLevel (0);
    }

    private void AccelerationCube()
    {
        switch (_score)
        {
            case  10:
                StartCoroutine(Accelerator(1.5f));
                break;
                
            case  25:
                StartCoroutine(Accelerator(1.5f));
                break;
            
            case  50:
                StartCoroutine(Accelerator(2));
                break;
            
            case  100:
                StartCoroutine(Accelerator(2));
                break;
        }
    }

    IEnumerator Accelerator(float accs)
    {
        var speed = SpawnCube.Speed * accs;
        var g = (speed - SpawnCube.Speed) / 10;
        for (int i = 0; i < 10; i++)
        {
            SpawnCube.Speed = SpawnCube.Speed + g;
            yield return new WaitForSeconds(0.2f);
            SpawnCube.Speed = (float)System.Math.Round(SpawnCube.Speed,2);
        }
        _textSpeed.text = "Speed " + SpawnCube.Speed;
    }
}
