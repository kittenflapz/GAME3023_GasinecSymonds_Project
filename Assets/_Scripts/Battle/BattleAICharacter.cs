using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAICharacter : ICharacter
{
    int randAbility;
    public BattlePlayerCharacter player;
    public List<ParticleSystem> abilityEffects;
    public List<AudioSource> abilitySounds;

    private void Start()
    {
        randAbility = Random.Range(0, 3);
    }
    public override void TakeTurn()
    {
        if (hp <= 0)
        {
            hasLost = true;
            player.hasWon = true;
            player.TakeTurn();
        }
        else
        {
            base.TakeTurn();

            randAbility = Random.Range(0, 3);
            StartCoroutine(TakeTurnCoro());
        }
    }

    IEnumerator TakeTurnCoro()
    {
        yield return new WaitForSeconds(3);

        // if hp >= 50%, use random ability
        if (hp > hpMax / 2)
        {
            UseAbility(randAbility);
            abilityEffects[randAbility].Play();
            abilitySounds[randAbility].Play();
        }
        else        // if hp < 50%, use charge unless charge has been used, in which case use Scratch
        {
            if (abilities[2].usedThisBattle == false)
            {
                UseAbility(2);
                abilityEffects[2].Play();
                abilitySounds[2].Play();
            }
            else
            {
                UseAbility(0);
                abilityEffects[0].Play();
                abilitySounds[0].Play();
            }
        }
    }
}
