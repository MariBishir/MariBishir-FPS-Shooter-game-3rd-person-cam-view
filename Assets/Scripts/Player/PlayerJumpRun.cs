using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpRun : MonoBehaviour
{
    public Transform cam;
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    private Vector3 moveDirection;
    // track gravity and jumping
    private Vector3 velocity;

    private bool isGrounded;
    // just adding gravity
    public float groundCheckDistance;
    public LayerMask groundMask;
    public float gravity;

    public float jumpHeight;

    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }

    private void Move()
    {
        // our position + our radius + our layer of ground
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);  
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }

            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }

            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            //to make sure we use it
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

        }

        controller.Move(moveDirection * Time.deltaTime);

        // calculate and apply gravity for our player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle ()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
    