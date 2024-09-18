using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuPanel : AbstractPanel
{
    private SceneLoadHandler _sceneLoadHandler;

    [SerializeField] private List<MenuButton> _buttons;

    [Inject]
    private void Construct(SceneLoadHandler sceneLoadHandler) => _sceneLoadHandler = sceneLoadHandler;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            switch (button.tag)
            {
                case "PlayButton":
                    button.ButtonClick += LoadGamePlayScene;
                    break;
                case "ExitButton":
                    button.ButtonClick += Quit;
                    break;
                case "GameButton":
                    button.ButtonClick += LoadGame;
                    break;

            }
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            switch (button.tag)
            {
                case "PlayButton":
                    button.ButtonClick -= LoadGamePlayScene;
                    break;
                case "ExitButton":
                    button.ButtonClick -= Quit;
                    break;
                case "GameButton":
                    button.ButtonClick -= LoadGame;
                    break;
            }
        }
    }

    public void LoadGamePlayScene() => _sceneLoadHandler.LoadGamePlayScene();
    public void LoadGame() =>_sceneLoadHandler.LoadGame();
    public void Quit() => Application.Quit();
}