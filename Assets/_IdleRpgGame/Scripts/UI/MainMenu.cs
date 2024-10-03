using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    //Unity event
    public void LoadGameplayScene()
    {
        IdleGameState.CurrentState = GameState.EntryState;
        SceneManager.LoadScene("Gameplay");
    }
    public void QuitApplication() => Application.Quit();
}
