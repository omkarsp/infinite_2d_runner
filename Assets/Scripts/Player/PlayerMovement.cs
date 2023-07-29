using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] Vector3 playerStartPos = new Vector3(-7f, -2f, 0f);

    [Header("Movement Speeds")]
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float jumpDownSpeed = -0.5f;

    [Header("Script References")]
    [SerializeField] HudHandler hudHandler;

    bool isGrounded = true;
    Rigidbody2D rb;
    Collider2D col;
    float horizontalMove = 0;
    float localScaleX;
    Animator animator;
    bool canMoveBack = true;
    Camera mainCam;

    #endregion

    //Initialize variables
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        localScaleX = transform.localScale.x;
        animator = GetComponent<Animator>();
        mainCam = Camera.main;
        transform.position = playerStartPos;
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        ActivateRunAnim();
        SetPlayerSpriteDirection();
        Jump();
        BetterJump();
        CantGoBack();
    }

    //Reset player position when gae restarts
    public void ResetPlayer()
    {
        transform.position = playerStartPos;
    }

    //Detect coin and enemy collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            hudHandler.UpdateScore();
        }

        if (collision.tag == "Enemy")
        {
            hudHandler.UpdateLives();
        }
    }

    //When player lands after jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isGrounded = true;
        //Debug.Log(isGrounded);
        animator.SetBool("Jump", false);
    }

    //While player is running
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    //When player is in air
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    //Restrict player to go behind the camera view
    private void CantGoBack()
    {
        if (mainCam.WorldToViewportPoint(transform.position).x < 0.01)
        {
            canMoveBack = false;
        }
        else
        {
            canMoveBack = true;
        }
    }

    void HorizontalMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (horizontalMove < 0 && !canMoveBack)
        {
            transform.position += Vector3.zero;
        }
        else
        {
            transform.position += new Vector3(horizontalMove * moveSpeed, 0, 0);
        }
    }

    //player can't jump if not on the ground
    void Jump()
    {
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            ActivateJumpAnim();
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    //Player turns looks behind while moving backwards
    void SetPlayerSpriteDirection()
    {
        if (horizontalMove < 0)
        {
            transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        }
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        }
    }

    void ActivateRunAnim()
    {
        animator.SetFloat("Run", Mathf.Abs(horizontalMove));
    }

    void ActivateJumpAnim()
    {
        animator.SetBool("Jump", true);
    }

    //Push player down to reduce floatiness while jumping
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0, jumpDownSpeed), ForceMode2D.Impulse);
        }
    }
}
