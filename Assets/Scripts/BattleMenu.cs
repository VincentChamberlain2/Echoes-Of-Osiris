using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    [SerializeField]
     private GameObject _attackButton, _spellButton, _surrenderButton;
    [SerializeField]
    TextMeshProUGUI _stateText;

    /*void Awake()
    {
        GameManager.OnChangedGameState += GameManagerChangedGameState;
    }
    void ODestroy()
    {
        GameManager.OnChangedGameState -= GameManagerChangedGameState;    
    }

    private void GameManagerChangedGameState;
    */
}
