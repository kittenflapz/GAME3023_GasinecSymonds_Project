using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dodge Effect", menuName = "Effects/Dodge")]
public class DodgeEffect : Effect
{
    public override void Apply(ICharacter caster, ICharacter target)
    {
        caster.isDodging = true;
    }
}
