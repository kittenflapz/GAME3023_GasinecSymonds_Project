using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSimple : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    Rigidbody2D rigidbody;

    // Animation
    Animator animator;
  
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement

        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        movementVector *= speed;
        rigidbody.velocity = movementVector;

        // Animation

        animator.SetFloat("moveX", rigidbody.velocity.x);
        animator.SetFloat("moveY", rigidbody.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
