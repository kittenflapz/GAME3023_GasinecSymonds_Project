using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAICharacter : ICharacter
{
    public override void TakeTurn()
    {
        // use random ability
        int randAbility = Random.Range(0, 3);

        if(abilities[randAbility] != null)
        {
            // do thing
            UseAbility(randAbility);
        }
        else
        {
            // cycle through until a valid ability...
        }
    }
}
