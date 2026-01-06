using UnityEngine;

public class enemyAttackScript : MonoBehaviour
{
    private float close;
    private Animator anim;
    private followScript follow;
    private enemyHurtScript HurtScript;

    private static float biteCooldown = 1f;
    private static float biteTimer = 0;

    public int biteDmg = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<followScript>();
        HurtScript = GetComponent<enemyHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        close = follow.distance - follow.targetPos;
        biteTimer -= biteCooldown;

        if (biteTimer <= 0 && close <= 40 && HurtScript.iframes < 0)
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
