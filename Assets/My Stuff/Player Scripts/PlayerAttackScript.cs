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

    public static float slashCooldown = 1.5f;
    public static float dashCooldown = 5f;
    public static float phaseCooldown = 10f;
    public static float ultCooldown = 85f;

    public static float slashTimer = 0;
    public static float dashTimer = 0;
    public static float phaseTimer = 0;
    public static float ultTimer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //abilityTimer -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        slashTimer -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
        phaseTimer -= Time.deltaTime;
        ultTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking && slash())
        {
            anim.SetBool("Down Slash", true);
            isAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.X) && !isAttacking && dash())
        {
            anim.SetBool("Dash", true);
            isAttacking = true;
            isDashing = true;
        }

        if (Input.GetKeyDown(KeyCode.C) && !isAttacking && phase())
        {
            anim.SetBool("Phase", true);
            isAttacking = true;
            isPhasing = true;
            boxCollider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.G) && !isAttacking && ult())
        {
            //anim.SetBool("G Pressed", true);
            //isAttacking = true;
            //isUlting = true;
        }

        if (isAttacking)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Down Slash") && stateInfo.normalizedTime >= 1.0f && isAttacking)
            {
                isAttacking = false;
                anim.SetBool("Down Slash", false);
            }
            if (stateInfo.IsName("Dash") && stateInfo.normalizedTime >= 1.0f && isAttacking)
            {
                isAttacking = false;
                isDashing = false;
                anim.SetBool("Dash", false);
            }
            if (stateInfo.IsName("Phase") && stateInfo.normalizedTime >= 1.0f && isAttacking)
            {
                isAttacking = false;
                anim.SetBool("Phase", false);
                isPhasing = false;
                boxCollider.enabled = true;
            }
            if (stateInfo.IsName("Ult") && stateInfo.normalizedTime >= 1.0f && isAttacking)
            {
                isAttacking = false;
                anim.SetBool("Ult", false);
                isUlting = false;
            }
        }
    }

    private static bool slash()
    {
        if (slashTimer > 0f)
        {
            return false;
        }

        slashTimer = slashCooldown;
        return true;
    }

    private static bool dash()
    {
        if (dashTimer > 0f)
        {
            return false;
        }

        dashTimer = dashCooldown;
        return true;
    }

    private static bool phase()
    {
        if (phaseTimer > 0f)
        {
            return false;
        }

        phaseTimer = phaseCooldown;
        return true;
    }

    private static bool ult()
    {
        if (ultTimer > 0f)
        {
            return false;
        }

        ultTimer = ultCooldown;
        return true;
    }
}
