using UnityEngine;

public class smallCurseAttackScript : MonoBehaviour
{
    [SerializeField] float acidSpeed = 6f;
    [SerializeField] float acidMoveTime = 0.4f;

    [SerializeField] public float flinchDuration;
    private Animator anim;
    private smallCurseFollowScript follow;
    private smallCurseHurtScript HurtScript;
    private GameObject acid;
    private SpriteRenderer acidSprite;
    private Animator acidAnim;
    private Rigidbody2D body;
    

    private static float cooldown = 3f;
    private static float attkTimer = 0;

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
        if (isAttacking)
        {
            acidTimer -= Time.deltaTime;

            if (acidTimer <= 0)
            {
                body.linearVelocity = Vector2.zero; // stop moving
                isAttacking = false;
            }
        }
        hurtTimer -= Time.deltaTime;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo stateInfo1 = acidAnim.GetCurrentAnimatorStateInfo(0);

        close = Vector2.Distance(transform.position, follow.player.transform.position);
        attkTimer -= cooldown;

        if (close > 40  )
        {
            anim.SetBool("Attack", false);
            acidAnim.SetBool("Attack", false);
        } else 
        {
            if (attkTimer <= 0 && close <= 40 && hurtTimer < 0)
        {
            anim.SetBool("Attack", true);
            acidAnim.SetBool("Attack", true);

            isAttacking = true;
            acidTimer = acidMoveTime;

            body.linearVelocity = new Vector2(-transform.localScale.x * acidSpeed, 0);

            if (stateInfo.normalizedTime >= 1.0f)
            {
                acid.transform.localPosition = Vector3.zero;
            }
        }
        }

    }
}
