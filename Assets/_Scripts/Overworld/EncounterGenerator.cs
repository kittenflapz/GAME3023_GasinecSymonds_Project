/* Adapted from anwers in this reddit thread:
 * https://www.reddit.com/r/Unity3D/comments/dbczm0/random_encounters/
 * especially /u/rekabmot */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EncounterGenerator : MonoBehaviour
{
    // This is the starting probability of an encounter
    const int DEFAULT_ENCOUNTER_THRESHOLD = 90;

    // Set the current probability to the default value
    private int currentEncounterThreshold = DEFAULT_ENCOUNTER_THRESHOLD;

    // So that we only check encounters every few seconds
    [SerializeField]
    private float rerollTime;

    [SerializeField]
    private float rerollTimer;

    private bool playerIsMoving;

    [SerializeField]
    private Rigidbody2D playerRB;

    [SerializeField]
    SceneSwitcher sceneSwitcher;

    [SerializeField]
    public bool playerInEncounterZone;

    public UnityEvent onEnterEncounter;


    public void Start()
    {
        rerollTimer = 0;
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    public void Update()
    {
        // Check whether player is moving
        playerIsMoving = playerRB.velocity.magnitude > 0 ? true : false;

        Debug.Log(rerollTimer > rerollTime);

        if (playerInEncounterZone && rerollTimer > rerollTime)
        {
     
            if (playerIsMoving) // You'll need some way of knowing whether the player moved on this frame.
                                // Alternatively, you can bundle this into your movement script and separate it out again later on
            {
                // Pick a number between 0 and 100
                int value = Random.Range(0, 100);


                // Check if the number is below the current threshold
                if (value < currentEncounterThreshold)
                {
                    // If it is, then start an encounter, and set the threshold back to the default value for next time.
                    StartCoroutine(DelayBattle());
                }
                else
                {
                    // We weren't below the threshold this time, so let's increase it and set the timer back to 0
                    currentEncounterThreshold += 1;
                    rerollTimer = 0;
                }

            }
        }
        // Increment the roll timer
        else
        {
            rerollTimer += 0.1f;
        }
    }

    IEnumerator DelayBattle()
    {
        onEnterEncounter.Invoke();
        yield return new WaitForSeconds(3.0f);
        sceneSwitcher.LoadBattleScene();
        currentEncounterThreshold = DEFAULT_ENCOUNTER_THRESHOLD;
    }
}


