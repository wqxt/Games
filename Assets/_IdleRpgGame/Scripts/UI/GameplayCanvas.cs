using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayCanvas : MonoBehaviour
{

    [SerializeField] private PawnConfiguration _characterConfiguration;
    [SerializeField] private GameObject _healButton;

    private void LateUpdate()
    {
        if (IdleGameState.CurrentState == GameState.EntryState)
        {
            _healButton.SetActive(true);
        }

    }
    //Unity event
    public void MainMenu()
    {
        IdleGameState.CurrentState = GameState.MainMenuState;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartFight()
    {
        if (_characterConfiguration.CurrentHealthValue <= 0)
        {
            Debug.Log("Character health value = 0 or less, return");
            return;
        }
        else
        {
            _healButton.SetActive(false);
            IdleGameState.CurrentState = GameState.FightState;
        }

    }

    public void Escape() => IdleGameState.CurrentState = GameState.EntryState;
    public void Heal() => _characterConfiguration.CurrentHealthValue = _characterConfiguration.StartHealthValue;
}