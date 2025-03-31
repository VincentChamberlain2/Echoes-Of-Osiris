using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void UpdateGameState(GameState newState)
    {
        //State = newState;

        switch(newState){
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState,null);
        }
        // OnChangedGameState
    }
}

public enum GameState{
    BattleState,
    BattleMenu,
    PlayerTurn,
    EnemyTurn,
    Lose,
    Win
}
public enum BattleState{
    PlayerTurn,
    EnemyTurn,
    Lose,
    Win 
}
