using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


enum BattlePhase
{
    PLAYER,
    ENEMY,
    COUNT
}


public class BattleSystem : MonoBehaviour
{

    [SerializeField]
    BattlePhase phase;
    
    [SerializeField]
    ICharacter[] combatants;

    public UnityEvent<ICharacter> onCharacterTurnBegin;


    // Start is called before the first frame update
    void Start()
    {
        AdvanceTurns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceTurns()
    {
        phase++;
        if(phase >= BattlePhase.COUNT)
        {
            phase = 0;
        }
        ICharacter activeCharacter = combatants[(int)phase];
        Debug.Log("It is " + activeCharacter.name + "'s turn");
        activeCharacter.TakeTurn();
        onCharacterTurnBegin.Invoke(activeCharacter);
    }
}
