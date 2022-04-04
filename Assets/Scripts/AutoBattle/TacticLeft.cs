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
        foreach (var entiti in _gameManager.player_1)
        {
        entiti.GetComponent<Player>().ChangeStrategyWhoIsCloser();
        }
        _panelTacticLeft.SetActive(false);
        _buttonTacticLeft.SetActive(true);
        Time.timeScale = 1f;
    }
    
    public void AtAllForTheWeak()
    {
        foreach (var entiti in _gameManager.player_1)
        {
            entiti.GetComponent<Player>().ChangeStrategyAllForTheWeak();
        }
        _panelTacticLeft.SetActive(false);
        _buttonTacticLeft.SetActive(true);
        Time.timeScale = 1f;
    }
    
}
