using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _palyerPrefab;
    [SerializeField] private Transform _playerTransform;
    public override void InstallBindings()
    {
        CharacterPrefabInstall();
    }

    private void CharacterPrefabInstall()
    {
        PlayerController characterPrefab = Container.InstantiatePrefabForComponent<PlayerController>(_palyerPrefab, _playerTransform.position, Quaternion.Euler(0, 90, 0), null);

        Container.Bind<PlayerController>().
        FromInstance(characterPrefab).
        AsSingle();
    }
}