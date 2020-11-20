using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Effect", menuName = "Effects/Damage")]
public class Damage : Effect
{
    [SerializeField]
    int power;

    [SerializeField]
    TargetType target;

    public override void Apply(ICharacter caster, ICharacter target)
    {
        target.TakeDamage(power);
    }
}
