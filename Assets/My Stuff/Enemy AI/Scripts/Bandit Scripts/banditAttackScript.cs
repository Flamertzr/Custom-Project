using UnityEngine;

public class banditAttackScript : MonoBehaviour
{
    [SerializeField] public float flinchDuration;
    public float close;
    private Animator anim;
    private banditFollowScript follow;
    private banditHurtScript HurtScript;
    

    private static float punchCooldown = 3f;
    private static float punchTimer = 0;

    public float hurtTimer;

    public int punchDmg = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<banditFollowScript>();
        HurtScript = GetComponent<banditHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
       hurtTimer -= Time.deltaTime;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        close = Vector2.Distance(transform.position, follow.player.transform.position);
        punchTimer -= punchCooldown;

        if (close > 20)
        {
            anim.SetBool("Punch", false);
        } else 
        {
            if (punchTimer <= 0 && close <= 40 && hurtTimer < 0)
            {
                anim.SetBool("Punch", true);
            }
        } 
    }
}
