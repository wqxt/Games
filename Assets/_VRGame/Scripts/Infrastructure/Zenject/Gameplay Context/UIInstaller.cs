using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private GameObject _inventoryGameObject;
    [SerializeField] private GameObject _gameplayPanelGameObject;
    public override void InstallBindings()
    {
        InventoryPrefabInstall();
        GameplayPrefabInstall();
    }

    private void InventoryPrefabInstall()
    {
        MainInventoryPanel mainInventoryPanel = Container.InstantiatePrefabForComponent<MainInventoryPanel>(_inventoryGameObject, _inventoryGameObject.transform.position, Quaternion.identity, null);

        Container.Bind<MainInventoryPanel>().
        FromInstance(mainInventoryPanel).
        AsSingle();
    }

    private void GameplayPrefabInstall()
    {
        GameplayPanel gameplayPanel= Container.InstantiatePrefabForComponent<GameplayPanel>(_gameplayPanelGameObject, _gameplayPanelGameObject.transform.position, Quaternion.identity, null);

        Container.Bind<GameplayPanel>().
        FromInstance(gameplayPanel).
        AsSingle();
    }
}
