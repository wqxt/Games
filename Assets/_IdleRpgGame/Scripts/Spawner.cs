using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private PawnPool _pawnPool;
    [SerializeField] private GameObject _pawnParentTransform;
    [SerializeField] private GameObject _healthPresenter;

    private void Awake()
    {
        _pawnPool.ScenePawnList = new();
        _pawnPool.HealthModelList = new();
        SpawnCharacter();
        SpawnEnemy();
        SpawnHealthObserver();
    }

    public void SpawnHealthObserver()
    {
        var healthObserver = Instantiate(_healthPresenter,transform.position,Quaternion.identity, _pawnParentTransform.transform);
    }

    private void SpawnCharacter()
    {
        Pawn characterPawn = Instantiate(_pawnPool.Character, _characterTransform.transform.position, Quaternion.identity, _pawnParentTransform.transform);
        characterPawn.transform.rotation = new Quaternion(0, 0, 0, 0);
        _pawnPool.ScenePawnList.Add(characterPawn);


        PawnHealth healthModel = new PawnHealth(characterPawn);
        _pawnPool.HealthModelList.Add(healthModel);

    }

    private void SpawnEnemy()
    {
        float cumulativeChance = 0f;
        float randomValue = Random.Range(1f, 100f);

        for (int i = 0; i < _pawnPool.EnemyPool.Length; i++)
        {
            cumulativeChance += _pawnPool.EnemyPool[i].PawnConfiguration.SpawnChance;
            if (randomValue <= cumulativeChance)
            {
                Pawn enemyPawn = Instantiate(_pawnPool.EnemyPool[i], _enemyTransform.transform.position, Quaternion.identity, _pawnParentTransform.transform);
                enemyPawn.transform.rotation = new Quaternion(0, 0, 0, 0);
                _pawnPool.ScenePawnList.Add(enemyPawn);


                PawnHealth healthModel = new PawnHealth(enemyPawn);
                _pawnPool.HealthModelList.Add(healthModel);
                break;
            }
        }
    }

    public void RemovePawn(Pawn pawn)
    {
        for (int i = 0; i < _pawnPool.ScenePawnList.Count; i++)
        {
            if (_pawnPool.ScenePawnList[i].PawnConfiguration.Type == pawn.PawnConfiguration.Type)
            {
                _pawnPool.ScenePawnList[i].gameObject.SetActive(false);
                Destroy(_pawnPool.ScenePawnList[i].gameObject);
                _pawnPool.ScenePawnList.RemoveAt(i);
                SpawnEnemy();

            }
        }
    }
}