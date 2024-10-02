using UnityEngine;

namespace IdleGame.StateMachine
{
    public class EntryState : State
    {
        public EntryState(Pawn pawn, StateMachine stateMachine) : base(pawn, stateMachine) { }

        public override void Enter()
        {
            _pawn._fightIndicatorAnimator.speed = 0;
            _pawn._pawnAnimator.speed = 0;
        }

        public override void LateUpdate()
        {
            if (_pawn.GameConfiguration.CurrentState == GameState.EntryState)
            {
                _pawn._fightIndicatorAnimator.speed = 0;
                _pawn._pawnAnimator.speed = 0;
                _pawn._fightIndicatorAnimator.Play("Indicator", 0, 0f);
                _pawn._fightIndicatorAnimator.Play("RangeAttack", 0, 0f);
                _pawn._fightIndicatorAnimator.Play("MeleeAttack", 0, 0f);
            }
            else
            {


                if (_pawn.PawnConfiguration.Type == "Character")
                {
                    _stateMachine.ChangeState(_pawn._prepareAttackState);

                }
                else
                {
                    return;
                }
            }
        }

        public override void Exit() { }
    }
}