using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    Rigidbody2D rigidBody;

    // Animation variables
    Animator animator;
    float fidgetTimer;


    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        { 
            speed = 5; 
        }
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement

        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;

        // Animation

        animator.SetFloat("moveX", rigidBody.velocity.x);
        animator.SetFloat("moveY", rigidBody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1  || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        // If (random 3-5 seconds) pass while idle, set the fidget chance to 1 and then set it back after a second
        if(Input.anyKeyDown) // input received, reset the fidget timer
        {
            fidgetTimer = 0;
        }
        else
        {
            fidgetTimer++;

            if (fidgetTimer >= Random.Range(400, 700))
            {
                StartCoroutine(setFidgetChance());
            }
        }
  
    }

    IEnumerator setFidgetChance()
    {
        animator.SetFloat("fidgetChance", 1); // make it 100% likely that the player will fidget
        yield return new WaitForSeconds(1f);
        animator.SetFloat("fidgetChance", 0); // make it 0% likely that the player will fidget
        fidgetTimer = 0; // set the timer back to 0 so he's not just constantly fidgeting forever
    }
}
