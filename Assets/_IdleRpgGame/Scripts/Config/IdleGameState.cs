using UnityEngine;

[CreateAssetMenu(fileName = "IdleGameConfiguration", menuName = "Scriptable Object/GameConfiguration")]
public class IdleGameConfiguration : ScriptableObject
{
    public GameState CurrentState { get; set; }
}
public enum GameState
{
    EntryState,
    FightState,
    MainMenuState
}