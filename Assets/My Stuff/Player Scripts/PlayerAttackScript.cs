using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    public bool isAttacking = false;
    public bool isDashing = false;
    public bool isPhasing = false;
    public bool isUlting = false;

    private static float slashCooldown = 1.5f;
    private static float dashCooldown = 5f;
    private static float phaseCooldown = 10f;
    private static float ultCooldown = 85f;

    private static float slashTimer = 0;
    private static float dashTimer = 0;
    private static float phaseTimer = 0;
    private static float ultTimer = 0;

    private static int slashDmg = 10;
    private static int dashDmg = 15;
    private static int ultDmg = 100;


    public int currDmg = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slashTimer -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
        phaseTimer -= Time.deltaTime;
        ultTimer -= Time.deltaTime;

        attack();
    }

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking && slashTimer <= 0)
        {
            slashMechanics();
        } else if(Input.GetKeyDown(KeyCode.X) && !isAttacking && dashTimer <= 0)
        {
            dashMechanics();
        } else if (Input.GetKeyDown(KeyCode.C) && !isAttacking && phaseTimer <= 0)
        {
            phaseMechanics();
        } else if (Input.GetKeyDown(KeyCode.G) && !isAttacking && ultTimer <= 0)
        {
            ultMechanics();
        } else if (isAttacking)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                isAttacking = false;
                isDashing = false;
                isPhasing = false;
                isUlting = false;
                anim.SetBool("Down Slash", false);
                anim.SetBool("Dash", false);
                anim.SetBool("Phase", false);
                anim.SetBool("Ult", false);
                boxCollider.enabled = true;
                currDmg = 0;
            }
        }
    }
    
    private void slashMechanics()
    {
        anim.SetBool("Down Slash", true);
        isAttacking = true;
        currDmg = slashDmg;
        slashTimer = slashCooldown;
    }

    private void dashMechanics()
    {
        anim.SetBool("Dash", true);
        isAttacking = true;
        isDashing = true;
        currDmg = dashDmg;
        dashTimer = dashCooldown;
    }
    private void phaseMechanics()
    {
        anim.SetBool("Phase", true);
        isAttacking = true;
        isPhasing = true;
        boxCollider.enabled = false;
        phaseTimer = phaseCooldown;
    }

    private void ultMechanics()
    {
        //anim.SetBool("G Pressed", true);
        //isAttacking = true;
        //isUlting = true;
        //currDmg = ultDmg;
        //ultTimer = ultCooldown;
    }
}
