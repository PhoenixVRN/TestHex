using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    
    public GameObject buttonStart;
    
    private GameManagerBattle _gameManager;
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManagerBattle").GetComponent<GameManagerBattle>();
    }

    public void StartGame()
    {
        _audio.Play();
        buttonStart.SetActive(false);
        foreach (var entini in _gameManager.player_1)
        {
            entini.GetComponent<Player>().GoStrategy();
        }
        foreach (var entini in _gameManager.player_2)
        {
            entini.GetComponent<Player>().GoStrategy();
        }
        
    }
}
