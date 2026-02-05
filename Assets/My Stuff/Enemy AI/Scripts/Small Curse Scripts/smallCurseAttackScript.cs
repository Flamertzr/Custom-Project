using UnityEngine;

public class smallCurseAttackScript : MonoBehaviour
{
    private float acidSpeed = 6f;
    float acidMoveTime = 2f;

    [SerializeField] public float flinchDuration;
    private Animator anim;
    private smallCurseFollowScript follow;
    private smallCurseHurtScript HurtScript;
    private GameObject acid;
    private SpriteRenderer acidSprite;
    private Animator acidAnim;
    private Rigidbody2D body;
    

    private static float cooldown = 3f;
    private static float attkTimer;

    public float hurtTimer;
    public float close;

    private float acidTimer;
    private bool isAttacking;
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
        AnimatorStateInfo stateInfo = acidAnim.GetCurrentAnimatorStateInfo(0);
        close = Vector2.Distance(transform.position, follow.player.transform.position);

        if (close > 40 || hurtTimer > 0)
            return;

        attkTimer -= Time.deltaTime;

        // START ATTACK
        if (!isAttacking && attkTimer <= 0)
        {
            StartAttack();
        }

        // MOVE ACID
        if (isAttacking)
        {
            acidTimer -= Time.deltaTime;

            body.linearVelocity = new Vector2(-transform.localScale.x * acidSpeed, 0);

            if (stateInfo.normalizedTime >= 1.0f)
            {
                EndAttack();
            }
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        acidTimer = acidMoveTime;
        attkTimer = cooldown;

        anim.SetBool("Attack", true);
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
