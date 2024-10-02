using UnityEngine;

public class HealthObserver : MonoBehaviour
{
    [SerializeField] private HealthView[] _healthview;
    [SerializeField] private PawnPool _pawnPool;

    public void OnEnable()
    {
        foreach (Pawn pawn in _pawnPool.ScenePawnList)
        {
            pawn._attackState.Attacked += TakeDamage;
        }

        foreach (var healthModel in _pawnPool.HealthModelList)
        {
            healthModel.PawnDeath += Death;
            healthModel.ChangeHealth += ChangeHealth;
        }

    }

    public void OnDisable()
    {
        foreach (Pawn pawn in _pawnPool.ScenePawnList)
        {
            pawn._attackState.Attacked -= TakeDamage;
        }

        foreach (var healthModel in _pawnPool.HealthModelList)
        {
            healthModel.ChangeHealth -= ChangeHealth;
            healthModel.PawnDeath -= Death;
        }
    }

    private void Death(Pawn pawn)
    {
        foreach (var healthModel in _pawnPool.HealthModelList)
        {
            healthModel.Death();
        }
    }

    private void TakeDamage(int damage, Pawn pawn)
    {
        foreach (var healthModel in _pawnPool.HealthModelList)
        {
            healthModel.TakeDamage(damage, pawn);
        }
    }

    private void ChangeHealth(int currentHealth, Pawn pawn)
    {
        foreach (var healthView in _healthview)
        {
            if (pawn.PawnConfiguration.Type == healthView.tag)
            {
                healthView.ChangeHealth(currentHealth);
            }
        }
    }
}