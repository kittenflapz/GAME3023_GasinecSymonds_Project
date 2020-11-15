using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterArea : MonoBehaviour
{
    bool colliding;

    private void Update()
    {
        transform.parent.GetComponentInParent<EncounterGenerator>().playerInEncounterZone = colliding;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       Debug.Log("colliding");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("colliding w player");
            colliding = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = false;
        }
    }

}
