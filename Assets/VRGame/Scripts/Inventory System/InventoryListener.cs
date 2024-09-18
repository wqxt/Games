using UnityEngine;
using Zenject;
public class InventoryListener : MonoBehaviour
{
    [SerializeField] private MainInventoryPanel _mainInventoryPanel;
    [SerializeField] private Inventory _inventory;
    private PlayerController _playerController;

    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Awake()
    {
        _inventory._playerItemList.Clear();
        _inventory.ScoreValue = 0;
    }
    private void OnEnable()
    {
        _playerController.GripObject += _inventory.AddItem;
        _playerController.OpenInventoryPanel += _mainInventoryPanel.ShowPanel;
    }

    private void OnDestroy()
    {
        _playerController.GripObject -= _inventory.AddItem;
        _playerController.OpenInventoryPanel -= _mainInventoryPanel.ShowPanel;
    }
}