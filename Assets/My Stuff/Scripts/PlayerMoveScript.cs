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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(5, 5, 5);
            body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);


        } else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-5, 5, 5);
            body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Jump();
        }

    }
        

        //anim.SetBool("Run", horizontalInput != 0);
        //anim.SetBool("Grounded", isGrounded());
        
    private void Jump()
    {
        if (true)
        {
            body.linearVelocity = Vector2.up * jumpPower;
            //anim.SetTrigger("Jump");
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

