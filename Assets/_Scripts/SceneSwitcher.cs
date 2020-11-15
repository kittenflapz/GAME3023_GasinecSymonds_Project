using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartLevel");
    }

    public void LoadOverworld()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
