using UnityEngine;

public class smallCurseAttackScript : MonoBehaviour
{
    private float acidSpeed = 6f;
    float acidMoveTime = 4f;

    [SerializeField] public float flinchDuration;
    private Animator anim;
    private smallCurseFollowScript follow;
    private smallCurseHurtScript HurtScript;
    private GameObject acid;
    private SpriteRenderer acidSprite;
    private Animator acidAnim;
    private Rigidbody2D body;
    

    private float cooldown = 3f;
    private float attkTimer;

    public float hurtTimer;
    public float close;

    private float acidTimer;
    public bool isAttacking;
    public int dmg = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<smallCurseFollowScript>();
        HurtScript = GetComponent<smallCurseHurtScript>();
        acid = transform.Find("Acid").gameObject;
        acidAnim = acid.GetComponent<Animator>();
        acidSprite = acid.GetComponent<SpriteRenderer>();
        body = acid.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        close = Vector2.Distance(transform.position, follow.player.transform.position);

        // ALWAYS update projectile if already attacking
        if (isAttacking)
        {
            acidTimer -= Time.deltaTime;

            body.linearVelocity = new Vector2(-transform.localScale.x * acidSpeed, 0);

            if (acidTimer <= 0f)
            {
                EndAttack();
            }
        }

        // ONLY control when a new attack can start
        if (close <= 40 && hurtTimer <= 0)
        {
            attkTimer -= Time.deltaTime;

            if (!isAttacking && attkTimer <= 0)
            {
                StartAttack();
            }
        }
    }

    void StartAttack()
    {
        acid.transform.localPosition = Vector3.zero;
        isAttacking = true;
        acidTimer = acidMoveTime;
        attkTimer = cooldown;

        acidAnim.Play("Acid", 0, 0f);

        acidSprite.enabled = true;
    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        acidAnim.SetBool("Attack", false);
        
        isAttacking = false;

        body.linearVelocity = Vector2.zero;
        acidSprite.enabled = false;
        acid.transform.localPosition = Vector3.zero;
    }

}
