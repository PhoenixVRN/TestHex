using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player: MonoBehaviour
{
    public string name;
    public int side;
    public int hp;
    public float distanceAttac;
    public int damage;
    
    private ObjectNameView _playerGUI;
    private GameManagerBattle _gameManager;
    private GameObject _enamyTarget;
    private  Vector3 _targetLastPos;
    private Tweener _tween;
    private float _timeDamag;
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManagerBattle").GetComponent<GameManagerBattle>();
        _playerGUI = GetComponent<ObjectNameView>();
        _playerGUI.text = "HP " + hp;
        WhoIsCloser();
    }

  void Update()
  {
      _timeDamag -= Time.deltaTime;
        if (_enamyTarget.transform != null)
        {
            if (_targetLastPos == _enamyTarget.transform.position && Distance(_enamyTarget) < distanceAttac) return;
            _tween.ChangeEndValue(_enamyTarget.transform.position, true).Restart();
            _targetLastPos = _enamyTarget.transform.position;
        }
        Hit();
    }
// бъем кто ближе
  public void WhoIsCloser()
  {
      var minDist = 100f;
      if (side == 1)
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

     _tween = transform.DOMove(_enamyTarget.transform.position, 3).SetAutoKill(false);
     _targetLastPos = _enamyTarget.transform.position;
  }

  private void Hit()
  {
      if (_enamyTarget != null)
      {
          if (Distance(_enamyTarget) < distanceAttac && _timeDamag < 0f)
          {
//          Debug.Log("_timeDamag.ToString())");
              _timeDamag = 1;
              var r = _enamyTarget.transform.GetComponent<Player>().hp - damage;
              _enamyTarget.transform.GetComponent<Player>().hp = r;
              if (r <= 0) Destroy(_enamyTarget);
              _playerGUI.text = "HP " + r;
          }
      }
  }

  public float Distance(GameObject enamy)
  {
      var    dist = Vector3.Distance(transform.position, enamy.transform.position);
      return dist;
  }
}
