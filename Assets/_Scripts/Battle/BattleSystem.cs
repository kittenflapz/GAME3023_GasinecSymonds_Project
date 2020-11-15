using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        if(phase > BattlePhase.COUNT)
        {
            phase = 0;
        }
        Debug.Log("It is " + combatants[(int)phase].name + "'s turn");
        combatants[(int)phase].TakeTurn();
    }
}
