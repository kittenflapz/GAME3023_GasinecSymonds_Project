using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void ExitEncounter()
    {
        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().OnEncounterExitHandler();
        LoadOverworld();
    }

    public void LoadStartScene()
    {
        StartCoroutine(WaitAndLoadScene("StartLevel"));
    }

    public void LoadOverworld()
    {
        StartCoroutine(WaitAndLoadScene("Overworld"));
    }

    public void LoadBattleScene()
    {
        StartCoroutine(WaitAndLoadScene("BattleScene"));
    }


    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
   }
}
