using UnityEngine;

public class giantCurseAttackScript : MonoBehaviour
{
    [SerializeField] public float flinchDuration;
    private float close;
    private Animator anim;
    private followScript follow;
    private giantCurseHurtScript HurtScript;

    private static float biteCooldown = 1f;
    private static float biteTimer = 0;

    public float hurtTimer;

    public int biteDmg = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<followScript>();
        HurtScript = GetComponent<giantCurseHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
        hurtTimer -= Time.deltaTime;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        close = follow.distance - follow.targetPos;
        biteTimer -= biteCooldown;

        if (biteTimer <= 0 && close <= 40 && hurtTimer < 0)
        {
            attack();
        }

        if (close > 40 )
        {
            anim.SetBool("Bite", false);
        }

    }

    public void attack()
    {
        anim.SetBool("Bite", true);
    }
}
