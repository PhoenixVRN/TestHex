using UnityEngine;

public class TacticLeft : MonoBehaviour
{
    [SerializeField] private GameObject _panelTacticLeft;
    [SerializeField] private GameObject _buttonTacticLeft;
    private GameManagerBattle _gameManager;
   
    void Start()
    {
        _gameManager = GameObject.Find("GameManagerBattle").GetComponent<GameManagerBattle>();
    }

    public void ChangeTacticLeft()
    {
        _panelTacticLeft.SetActive(true);
        _buttonTacticLeft.SetActive(false);
        Time.timeScale = 0f;
    }

    public void AtWhoIsCloser()
    {
        foreach (var entini in _gameManager.player_1)
        {
        entini.GetComponent<Player>().ChangeStrategyWhoIsCloser();
        }
        _panelTacticLeft.SetActive(false);
        _buttonTacticLeft.SetActive(true);
        Time.timeScale = 1f;
    }
    
    public void AtAllForTheWeak()
    {
        foreach (var entini in _gameManager.player_1)
        {
            entini.GetComponent<Player>().ChangeStrategyAllForTheWeak();
        }
        _panelTacticLeft.SetActive(false);
        _buttonTacticLeft.SetActive(true);
        Time.timeScale = 1f;
    }
    
}
