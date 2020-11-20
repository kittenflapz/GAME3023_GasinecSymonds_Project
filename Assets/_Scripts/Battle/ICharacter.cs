using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ICharacter : MonoBehaviour
{
    public int hp;
    public int armor;

    [SerializeField]
    private int hpMax = 10;

    [SerializeField]
    protected Ability[] abilities = new Ability[4];

    public UnityEvent<ICharacter, int> onDamageTaken;
    public UnityEvent<ICharacter, Ability> onAbilityUsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility(int id)
    {
        onAbilityUsed.Invoke(this, abilities[id]);
    }

    public virtual void TakeTurn()
    {

    }

    private void OnDestroy()
    {
        onDamageTaken.RemoveAllListeners();
        onAbilityUsed.RemoveAllListeners();
    }

    public void TakeDamage(int baseDamage)
    {
        int damageTaken = baseDamage;

        hp -= damageTaken;
        onDamageTaken.Invoke(this, damageTaken);
    }
}
