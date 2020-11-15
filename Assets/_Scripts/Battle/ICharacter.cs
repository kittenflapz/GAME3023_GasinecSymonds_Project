using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacter : MonoBehaviour
{
    public int hp;

    [SerializeField]
    private int hpMax = 10;

    [SerializeField]
    Ability[] abilities = new Ability[4];

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
       // abilities[id].whatever
    }

    public void TakeTurn()
    {

    }
}
