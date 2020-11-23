using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Effect", menuName = "Effects/Damage")]
public class Damage : Effect
{
    [SerializeField]
    int power;

    [SerializeField]
    TargetType targType;

    public override void Apply(ICharacter caster, ICharacter target)
    {

        if ((int)targType == 1)
        {
            target.TakeDamage(power); 
        }
        else if ((int)targType == 0)
        {
            caster.TakeDamage(power); 
        }
    }
}
