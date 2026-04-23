using UnityEngine;

public class kaelGruntAttackScript : MonoBehaviour
{
    private float blastSpeed = 6f;
    float blastMoveTime = 4f;

    [SerializeField] public float flinchDuration;
    [SerializeField] public GameObject blastPrefab;

    private Animator anim;
    private kaelGruntFollowScript follow;
    private kaelGruntHurtScript HurtScript;

    private float cooldown = 3f;
    private float attkTimer;

    public float hurtTimer;
    public float close;

    private float blastTimer;
    public bool isAttacking;

    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<kaelGruntFollowScript>();
        HurtScript = GetComponent<kaelGruntHurtScript>();
    }

    void Update()
    {
        close = Vector2.Distance(transform.position, follow.player.transform.position);

        if (close <= 55 && hurtTimer <= 0)
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
        anim.SetBool("Attack", true);

        GameObject newBlast = Instantiate(blastPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = newBlast.GetComponent<Rigidbody2D>();

        Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        rb.linearVelocity = dir * blastSpeed;

        isAttacking = true;
        blastTimer = blastMoveTime;
        attkTimer = cooldown;
    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        isAttacking = false;
    }
}