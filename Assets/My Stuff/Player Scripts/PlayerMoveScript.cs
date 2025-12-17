using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private PlayerAttackScript playerAttack;
    private playerHurtScript playerHealth;
    private float normGrav;
    private bool facingRight;
    private int jumps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerAttack = GetComponent<PlayerAttackScript>();
        playerHealth = GetComponent<playerHurtScript>();

        normGrav = body.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currHealth > 0)   
        {
            horizontalInput = Input.GetAxis("Horizontal");
            
            if (horizontalInput > 0.01f && !playerAttack.isAttacking)
            {
                facingRight = true;
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(2, 2, 2);
                body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);


            } else if (horizontalInput < -0.01f && !playerAttack.isAttacking)
            {
                facingRight = false;
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-2, 2, 2);
                body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

            } else
            {
                anim.SetBool("Run", false);
            }

            if (((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow)))&& !playerAttack.isDashing)
            {
                Jump();
            }
            if(!isGrounded())
            {
                anim.SetBool("Jump", true);
            } else
            {
                anim.SetBool("Jump", false);
                jumps = 0;
            }

            if(playerAttack.isDashing)
            {
                body.gravityScale = 0f;
                body.linearVelocity = Vector2.zero;
                if (facingRight)
                {
                    body.linearVelocity = new Vector2(50, 0);
                } else 
                {
                    body.linearVelocity = new Vector2(-50, 0);
                }
            } else 
            {
                body.gravityScale = normGrav;
            }

            if (playerAttack.isPhasing)
            {
                body.gravityScale = 0f;
                body.linearVelocity = Vector2.zero;
                if (facingRight)
                {
                    body.linearVelocity = new Vector2(-30, 0);
                } else 
                {
                    body.linearVelocity = new Vector2(30, 0);
                }
            } else 
            {
                body.gravityScale = normGrav;
            }
        }
        
    }
        
    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = Vector2.up * jumpPower;
        } else if (jumps < 1)
        {
            body.linearVelocity = Vector2.up * jumpPower;
            jumps += 1;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }
}