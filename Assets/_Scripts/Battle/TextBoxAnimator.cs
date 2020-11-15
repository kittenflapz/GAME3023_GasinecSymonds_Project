using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxAnimator : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    float textSpeedCharactersPerSecond = 10;
    public void AnimateTextCharacterTurn(ICharacter activeCharacter)
    {
        AnimateText(activeCharacter.name);
    }

    public void AnimateText(string message)
    {
        StartCoroutine(AnimateTextRoutine(message));
    }

    IEnumerator AnimateTextRoutine(string message)
    {
        string currentMessage = "";

        for(int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            currentMessage += message[currentChar];
            text.text = currentMessage;
            yield return new WaitForSeconds(1/textSpeedCharactersPerSecond);
        }
    }

}
