using UnityEngine;

public class kaelGruntAttackScript : MonoBehaviour
{
    float blastMoveTime = 5f;

    [SerializeField] public float flinchDuration;
    [SerializeField] public GameObject blast; // this is now a PREFAB
    [SerializeField] private Transform firePoint; // where the blast spawns
    [SerializeField] private float blastSizeMultiplier;

    private Animator anim;
    private kaelGruntFollowScript follow;
    private kaelGruntHurtScript HurtScript;

    private float cooldown = 3f;
    private float attkTimer;

    public float blastSpeed;
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

            if (!isAttacking && attkTimer <= 0 /*&& !HurtScript.stunned*/)
            {
                StartAttack();
            }
        }

        // Attack timer
        if (isAttacking)
        {
            blastTimer -= Time.deltaTime;

            if (blastTimer <= 0)
            {
                EndAttack();
            }
        }
        hurtTimer -= Time.deltaTime;
    }

    void StartAttack()
    {
        anim.SetBool("Attack", true);

        // 🔥 Spawn new projectile
        GameObject newBlast = Instantiate(blast, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = newBlast.GetComponent<Rigidbody2D>();   

        float direction = Mathf.Sign(follow.player.transform.position.x - transform.position.x);

        // 👇 SCALE + DIRECTION TOGETHER
        Vector3 scale = newBlast.transform.localScale;
        scale *= blastSizeMultiplier;                  // increase size
        scale.x = Mathf.Abs(scale.x) * direction;      // face correct direction
        newBlast.transform.localScale = scale;

        // Apply movement
        rb.linearVelocity = new Vector2(direction * blastSpeed, 0);

        // Optional: trigger animation on projectile
        Animator blastAnim = newBlast.GetComponent<Animator>();
        if (blastAnim != null)
        {
            blastAnim.SetBool("Attack", true);
        }

        // Destroy projectile after time
        Destroy(newBlast, blastMoveTime);

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