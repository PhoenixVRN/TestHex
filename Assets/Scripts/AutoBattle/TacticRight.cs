using UnityEngine;

public class TacticRight : MonoBehaviour
{
    [SerializeField] private GameObject _panelTacticRight;
    [SerializeField] private GameObject _buttonTacticRight;
    
    private GameManagerBattle _gameManager;
   
    void Start()
    {
        _gameManager = GameObject.Find("GameManagerBattle").GetComponent<GameManagerBattle>();
    }

    public void ChangeTacticRight()
    {
        _panelTacticRight.SetActive(true);
        _buttonTacticRight.SetActive(false);
        Time.timeScale = 0f;
    }

    public void AtWhoIsCloserRight()
    {
        foreach (var entiti in _gameManager.player_2)
        {
            entiti.GetComponent<Player>().ChangeStrategyWhoIsCloser();
        }
        _panelTacticRight.SetActive(false);
        _buttonTacticRight.SetActive(true);
        Time.timeScale = 1f;
    }
    
    public void AtAllForTheWeakRight()
    {
        foreach (var entiti in _gameManager.player_2)
        {
            entiti.GetComponent<Player>().ChangeStrategyAllForTheWeak();
        }
        _panelTacticRight.SetActive(false);
        _buttonTacticRight.SetActive(true);
        Time.timeScale = 1f;
    }
}
