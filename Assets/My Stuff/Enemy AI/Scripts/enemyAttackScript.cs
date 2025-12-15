using UnityEngine;

public class enemyAttackScript : MonoBehaviour
{
    private Animator anim;
    private followScript follow;

    public bool biting = false;
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

      if (follow.distance - follow.targetPos <= 10)
        {
            anim.SetBool("Bite", true);
        }  

    if (stateInfo.IsName("Bite") && stateInfo.normalizedTime >= 1.0f && biting)
        {
            biting = false;
            anim.SetBool("Bite", false);
        }
    }
}
