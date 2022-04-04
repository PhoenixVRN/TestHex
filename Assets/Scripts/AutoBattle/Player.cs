using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player: MonoBehaviour
{
    [SerializeField] private Material _grey;
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
    
    public enum typeStrategy {WhoIsCloser, AllForTheWeak}

    public typeStrategy typeStrategyPlayer;
    

        [HideInInspector] public bool isDead;
    
    private ObjectNameView _playerGUI;
    private GameManagerBattle _gameManager;
    private GameObject _enamyTarget;
    private  Vector3 _targetLastPos;
    private Tweener _tween;
    private float _timeDamag;
    private Player _enamyPlayer;
    private bool _move;

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
  
// бъем кто ближе
  private void WhoIsCloser()
  {
      var minDist = 100f;
      
      if (side == 1)
      {
          if (_gameManager.player_2.Count != 0)
          {
              foreach (var enamy in _gameManager.player_2)
              {
                  var dist = Distance(enamy);
                  if (minDist > dist)
                  {
                      minDist = dist;
                      _enamyTarget = enamy;
                  }
              }
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
              foreach (var enamy in _gameManager.player_1)
              {
                  var dist = Distance(enamy);
                  if (minDist > dist)
                  {
                      minDist = dist;
                      _enamyTarget = enamy;
                  }
              }
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
      var minHp = 1000f;
      
      if (side == 1)
      {
          if (_gameManager.player_2.Count != 0)
          {
              foreach (var enamy in _gameManager.player_2)
              {
                  var hpEn = enamy.transform.GetComponent<Player>().hp;
                  if (minHp > hpEn)
                  {
                      minHp = hpEn;
                      _enamyTarget = enamy;
                  }
              }
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
              foreach (var enamy in _gameManager.player_1)
              {
                  var hpEn = enamy.transform.GetComponent<Player>().hp;
                  if (minHp > hpEn)
                  {
                      minHp = hpEn;
                      _enamyTarget = enamy;
                  }
              }
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
          for (int i = 0; i < _gameManager.player_1.Count; i++)
          {
              if (_gameManager.player_1[i] == gameObject)
              {
                  _gameManager.player_1.RemoveAt(i);
              }
          }
      }
      else
      {
          for (int i = 0; i < _gameManager.player_2.Count; i++)
          {
              if (_gameManager.player_2[i] == gameObject)
              {
                  _gameManager.player_2.RemoveAt(i);
              }
          }
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
}
