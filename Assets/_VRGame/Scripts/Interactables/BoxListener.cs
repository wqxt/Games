using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BoxListener : MonoBehaviour
{
    [SerializeField] private List<Box> _boxList;
    private PlayerController _playerController;
    private GameplayPanel _gameplayPanel;

    [Inject]
    public void Construct(GameplayPanel gameplayPanel, PlayerController playerController)
    {
        _gameplayPanel = gameplayPanel;
        _playerController = playerController;
    }

    private void OnEnable()
    {
        foreach (Box box in _boxList)
        {
            box.SetUIText += _gameplayPanel.SetText;
            box.ObjectDropped += _gameplayPanel.ShowPanel;
            box.RemoveDroppedObject += _gameplayPanel.HidePanel;
            box.TeleportPlayer += _playerController.Teleport;
            box.HideDroppedObject+= _playerController.HideObject;
        }
    }

    private void OnDisable()
    {
        foreach (Box box in _boxList)
        {
            box.SetUIText -= _gameplayPanel.SetText;
            box.ObjectDropped -= _gameplayPanel.ShowPanel;
            box.RemoveDroppedObject -= _gameplayPanel.HidePanel;
            box.TeleportPlayer -= _playerController.Teleport;
            box.HideDroppedObject -= _playerController.HideObject;
        }
    }
}