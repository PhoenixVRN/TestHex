using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player: MonoBehaviour
{
    [SerializeField] private Material _grey;
    [HideInInspector] public bool isDead;
    
    public string name;
    public int side;
    public int hp;
    public float distanceAttac;
    public int damage;
    public float speedMovePlayer;
    public float rof;
    public AudioSource attacAudio;
    public AudioSource deadAudio;
    public AudioSource musicAudio;
    public GameObject timerText;
    public Timer _timer;
    public GameObject restartgame;

    private ObjectNameView _playerGUI;
    private GameManagerBattle _gameManager;
    private GameObject _enamyTarget;
    private  Vector3 _targetLastPos;
    private float _timeDamag;
    private Player _enamyPlayer;
    private bool _move;
    
    public enum typeStrategy {WhoIsCloser, AllForTheWeak}
    public typeStrategy typeStrategyPlayer;

    void Start()
    {
        _gameManager = GameObject.Find("GameManagerBattle").GetComponent<GameManagerBattle>();
        _playerGUI = GetComponent<ObjectNameView>();
        _playerGUI.text = "HP " + hp;
    }

  void Update()
  {
      _timeDamag -= Time.deltaTime;
       MoveInEnamy();
  }

  public delegate void Dead(GameObject gameObject);
  public event Dead deadEnamy;
  
  private void MoveInEnamy()
  {
      if (_move)
      {
          if (Distance(_enamyTarget) < distanceAttac)
          {
              Hit();
              return;
          }
          transform.position = Vector3.MoveTowards(transform.position, _enamyTarget.transform.position, 
              speedMovePlayer * Time.deltaTime);
      }
  }
  
// бьем кто ближе
  private void WhoIsCloser()
  {
      if (side == 1)
      {
          if (_gameManager.player_2.Count != 0)
          {
              DistanceSearchEnamy(_gameManager.player_2);
          }
          else
          {
              GameOver();
          }
      }
      else
      {
          if (_gameManager.player_1.Count != 0)
          {
              DistanceSearchEnamy(_gameManager.player_1);
          }
          else
          {
              GameOver();
          }
      }

      _enamyPlayer = _enamyTarget.transform.GetComponent<Player>();
      
      _enamyTarget.GetComponent<Player>().deadEnamy += deadEnamyq;
  }
// Бьем самого слабог
  private void AllForTheWeak()
  {
      if (side == 1)
      {
          if (_gameManager.player_2.Count != 0)
          {
             LookingForTheWeakest(_gameManager.player_2);
          }
          else
          {
              GameOver();
          }
      }
      else
      {
          if (_gameManager.player_1.Count != 0)
          {
              LookingForTheWeakest(_gameManager.player_1);
          }
          else
          {
             GameOver();
          }
      }

      _enamyPlayer = _enamyTarget.transform.GetComponent<Player>();
  }

  private void deadEnamyq (GameObject enamy)
  {
      _enamyTarget = null;
      GoStrategy();
  }
  private void Hit()
  {
      if (_timeDamag < 0 && isDead == false)
      {
          attacAudio.Play();
          _timeDamag = rof;
          _enamyPlayer.Damage(damage);
          if (_enamyPlayer.isDead)
          {
              GoStrategy();
          }
      }
  }
  public float Distance(GameObject enamy)
  {
      var    dist = Vector3.Distance(transform.position, enamy.transform.position);
      return dist;
  }

  public void Damage(int damageIn)
  {
      hp = hp - damageIn;
      if (hp <= 0)
      {
          deadAudio.Play();
          deadEnamy?.Invoke(gameObject);
          RemoveListPlayer();
          gameObject.GetComponent<MeshRenderer>().material = _grey;
          isDead = true;
          _playerGUI.enabled = false;
      }
      _playerGUI.text = "HP " + hp;
  }

  private void RemoveListPlayer()
  {
      if (side == 1)
      {
          RemoveList(_gameManager.player_1);
      }else
      {
          RemoveList(_gameManager.player_2);
      }
      
  }

  public void GoStrategy()
  {
      _move = true;
      switch (typeStrategyPlayer)
      {
          case typeStrategy.WhoIsCloser:
              WhoIsCloser();
              break;
          case typeStrategy.AllForTheWeak:
              AllForTheWeak();
              break;
      }
  }

  public void ChangeStrategyWhoIsCloser()
  {
      typeStrategyPlayer = typeStrategy.WhoIsCloser;
      GoStrategy();
  }
  
  public void ChangeStrategyAllForTheWeak()
  {
      typeStrategyPlayer = typeStrategy.AllForTheWeak;
      GoStrategy();
  }

  public void GameOver()
  {
      musicAudio.Stop();
      Time.timeScale = 0f;
      timerText.SetActive(true);
      timerText.GetComponent<Text>().text = _timer.TimerText();
      restartgame.SetActive(true);
  }

  private void RemoveList(List<GameObject> list)
  {
      for (int i = 0; i < list.Count; i++)
      {
          if (list[i] == gameObject)
          {
              list.RemoveAt(i);
          }
      }
  }

  private void DistanceSearchEnamy(List<GameObject> list)
  {
      var minDist = 100f;
      foreach (var enamy in list)
      {
          var dist = Distance(enamy);
          if (minDist > dist)
          {
              minDist = dist;
              _enamyTarget = enamy;
          }
      }
  }

  private void LookingForTheWeakest(List<GameObject> list)
  {
      var minHp = 1000f;
      foreach (var enamy in list)
      {
          var hpEn = enamy.transform.GetComponent<Player>().hp;
          if (minHp > hpEn)
          {
              minHp = hpEn;
              _enamyTarget = enamy;
          }
      }
  }
}
