using System;
using UnityEngine;

public class PawnHealth
{
    [SerializeField] private Pawn _pawn;
    public event Action<int, Pawn> ChangeHealth;
    public event Action<Pawn> PawnDeath;

    public PawnHealth(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void TakeDamage(int damage, Pawn pawn)
    {
        if (_pawn.PawnConfiguration.Type != pawn.PawnConfiguration.Type)
        {
            _pawn.PawnConfiguration.CurrentHealthValue -= damage;
            ChangeHealth?.Invoke(_pawn.PawnConfiguration.CurrentHealthValue, _pawn);
            if(_pawn.PawnConfiguration.CurrentHealthValue <= 0)
            {
                PawnDeath?.Invoke(_pawn);
            }
        }

    }

    public void Death()
    {
        IdleGameState.CurrentState = GameState.EntryState;
    }

}

