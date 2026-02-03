using UnityEngine;

public class smallCurseAttackScript : MonoBehaviour
{
    [SerializeField] public float flinchDuration;
    private Animator anim;
    private smallCurseFollowScript follow;
    private smallCurseHurtScript HurtScript;
    private GameObject acid;
    private SpriteRenderer acidSprite;
    private Animator acidAnim;
    

    private static float cooldown = 3f;
    private static float attkTimer = 0;

    public float hurtTimer;
    public float close;

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
    }

    // Update is called once per frame
    void Update()
    {
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
            acidAnim.SetBool("Attack", false);
        }
        }

    }
}
