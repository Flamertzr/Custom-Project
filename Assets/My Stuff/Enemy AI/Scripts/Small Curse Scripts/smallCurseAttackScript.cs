using UnityEngine;

public class smallCurseAttackScript : MonoBehaviour
{
    [SerializeField] public float flinchDuration;
    private float close;
    private Animator anim;
    private smallCurseFollowScript follow;
    private smallCurseHurtScript HurtScript;
    

    private static float cooldown = 1f;
    private static float attkTimer = 0;

    public float hurtTimer;

    public int dmg = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<smallCurseFollowScript>();
        HurtScript = GetComponent<smallCurseHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
        hurtTimer -= Time.deltaTime;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        close = follow.distance - follow.targetPos;
        attkTimer -= cooldown;

        if (close > 40  )
        {
            anim.SetBool("Attack", false);
        } else 
        {
            if (attkTimer <= 0 && close <= 40 && hurtTimer < 0)
        {
            anim.SetBool("Attack", true);
        }
        }

    }
}
