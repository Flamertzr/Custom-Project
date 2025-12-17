using UnityEngine;

public class enemyAttackScript : MonoBehaviour
{
    private float close;
    private Animator anim;
    private followScript follow;

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
    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

    close = follow.distance - follow.targetPos;

      if (close <= 40)
        {
            anim.SetBool("Bite", true);
        } else 
        {
            anim.SetBool("Bite", false);
        }

    if (stateInfo.IsName("Bite") && stateInfo.normalizedTime >= 1.0f)
        {
            anim.SetBool("Bite", false);
        }
    }
}
