using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class ICharacter : MonoBehaviour
{
    public float hp;
    public float armor;
    public bool isDodging;
    public bool hasLost;
    public bool hasWon;

    [SerializeField]
    protected int hpMax = 100;

    [SerializeField]
    protected Ability[] abilities = new Ability[4];


    public Image healthBar;
    public GameObject winnerUI;
    public TextMeshProUGUI battleOverText;
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
        UpdateHealthBar();
        if (isDodging)
        {
            isDodging = false;
        }
    }

    private void OnDestroy()
    {
        onDamageTaken.RemoveAllListeners();
        onAbilityUsed.RemoveAllListeners();
    }

    public void TakeDamage(int baseDamage)
    {
        int damageTaken = baseDamage;

        if (baseDamage > 0 && isDodging) // if this is an attack and we're dodging
        {
            damageTaken = 0; // it doesn't do anything
            Debug.Log("attack dodged!");
            
        }
        Debug.Log("changing hp of " + this.name + " by " + -baseDamage);
        hp -= damageTaken;
        onDamageTaken.Invoke(this, damageTaken);
        UpdateHealthBar();
    }

    public void RaiseDefense(int armorPointsToRaiseBy)
    {
        armor += armorPointsToRaiseBy;
    }

    public void UpdateHealthBar()
    {
        //Debug.Log("my health is " + hp + " and my max health is " + hpMax + " so my current health bar is " + hp / hpMax);
        healthBar.fillAmount = hp / hpMax;
    }
}
