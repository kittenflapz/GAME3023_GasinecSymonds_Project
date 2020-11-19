using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAICharacter : ICharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
