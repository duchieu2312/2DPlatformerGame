using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;   
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumbForce = 10f;
    [SerializeField] private AudioSource JumpSoundEffect;
    private float dirX = 0f;
    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;
    private enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log(dirX);
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        #if UNITY_STANDALONE || UNITY_WEBGL // PC input
            dirX = Input.GetAxis("Horizontal");
        #else // Mobile input
            dirX = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) || leftButtonPressed)
            {
                MoveLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow) || rightButtonPressed)
            {
                MoveRight();
            }
        #endif
        rb2D.velocity = new Vector2 (dirX * moveSpeed, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        /*
        Debug.Log("rb2D.velocity=" + rb2D.velocity);
        Debug.Log("rb2D.velocity.y=" + rb2D.velocity.y);
        Debug.Log("dir= " + dirX);
        */
        UpdateAnimation();
    }
    public void OnLeftButtonDown()
    {
        leftButtonPressed = true;
    }

    public void OnLeftButtonUp()
    {
        leftButtonPressed = false;
    }

    public void OnRightButtonDown()
    {
        rightButtonPressed = true;
    }

    public void OnRightButtonUp()
    {
        rightButtonPressed = false;
    }
    private void MoveLeft()
    {
        dirX = -1f;
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);
        UpdateAnimation();
    }
    private void MoveRight()
    {
        dirX = 1f;
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);
        UpdateAnimation();
    }
    public void OnJumpButtonDown()
    {
        Jump();
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            JumpSoundEffect.Play();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumbForce);
        }
        UpdateAnimation();
    }
    private void UpdateAnimation() 
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;// hình ảnh trở về ban đầu
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;//hình ảnh gốc sẽ bị đảo ngược 
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb2D.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }else if(rb2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("State", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
