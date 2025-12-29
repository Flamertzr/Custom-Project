using UnityEngine;

public class enemyAttackScript : MonoBehaviour
{
    private float close;
    private Animator anim;
    private followScript follow;

    private static float biteCooldown = 1f;
    private static float biteTimer = 0;

    public int biteDmg = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        follow = GetComponent<followScript>();
    }

    // Update is called once per frame
    void Update()
    {
        close = follow.distance - follow.targetPos;
        biteTimer -= biteCooldown;
        attack();

    }

    public void attack()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (biteTimer <= 0 && close <= 40)
        { 
            anim.SetBool("Bite", true);
        }

        if (stateInfo.IsName("Bite") && stateInfo.normalizedTime >= 1.0f)
        {
            anim.SetBool("Bite", false);
        }
    }
}
