using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Ability", menuName = "Ability/Basic Ability")]
public class Ability : ScriptableObject
{
    [SerializeField]
    List<Effect> effects;

   public bool usedThisBattle;
    
    public void ApplyEffects(ICharacter caster, ICharacter target)
    {
        foreach(Effect effect in effects)
        {
            effect.Apply(caster, target);
        }
        Debug.Log(this.GetType() + " was used!");
    }
}
