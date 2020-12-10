using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToOverworld : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colliding");

        // If the thing colliding is the player
        if (collision.CompareTag("Player"))
        {
            sceneSwitcher.LoadOverworld();
        }
    }
}
