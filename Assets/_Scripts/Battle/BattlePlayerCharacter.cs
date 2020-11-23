using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerCharacter : ICharacter
{
    public override void TakeTurn()
    {
        if (hasWon)
        {
            battleOverText.SetText("You won!");
            winnerUI.SetActive(true);
        }
        if (hp <= 0)
        {
            battleOverText.SetText("You lost!");
            hasLost = true;
            winnerUI.SetActive(true);
        }

        base.TakeTurn();

    }
}
