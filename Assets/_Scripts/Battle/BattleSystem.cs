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

        // subscribe to onabilityused events
        foreach(ICharacter character in combatants)
        {
            character.onAbilityUsed.AddListener(CharacterUsedAbilityHandler);
        }
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
        activeCharacter.TakeTurn();
        onCharacterTurnBegin.Invoke(activeCharacter);
    }


    private void OnDestroy()
    {
        foreach (ICharacter character in combatants)
        {
            character.onAbilityUsed.RemoveListener(CharacterUsedAbilityHandler);
        }
    }

    // respnd to onabilityused

    public void CharacterUsedAbilityHandler(ICharacter caster, Ability ability)
    {
        //target is whoever's turn it isn't
        ICharacter target = combatants[((int)phase + 1) % (int)BattlePhase.COUNT];
      
        ability.ApplyEffects(caster, target);
        StartCoroutine(SwapTurnDelay(1.0f));
    }

    IEnumerator SwapTurnDelay(float time)
    {
        yield return new WaitForSeconds(time);
        AdvanceTurns();
    }
}
