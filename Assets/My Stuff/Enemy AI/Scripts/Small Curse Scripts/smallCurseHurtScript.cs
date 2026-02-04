using UnityEngine;

public class smallCurseHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int health = 100;
    [SerializeField] public float flinchDuration;

    public bool dead = false;
    private bool flashing = false;

    private GameObject enemy;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
    private smallCurseAttackScript smallCurseAttack;
    private Animator anim;
    private Animator acidAnim;
    private GameObject acid;
    

    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemy = gameObject;
        playerAttack = player.GetComponent<PlayerAttackScript>();
        smallCurseAttack = GetComponent<smallCurseAttackScript>();
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
        acid = transform.Find("Acid").gameObject;
        acidAnim = acid.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        iframes -= Time.deltaTime;
        if (health <=0)
        {
            death();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player Hitbox") && iframes < -iframesDuration)
        {
            StartCoroutine(flinch());
            iframes = iframesDuration;
            smallCurseAttack.hurtTimer = smallCurseAttack.flinchDuration;
            health -= playerAttack.currDmg;
            if (flashing == false)
            {
                StartCoroutine(hits());
            }
        }
    }

    private System.Collections.IEnumerator hits()
    {
        flashing = true;
        sprite.color = Color.red;        
        yield return new WaitForSeconds(.2f);
        sprite.color = originalColor;
        yield return new WaitForSeconds(iframesDuration - 0.2f);
        flashing = false;
    }

    private void death()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        dead = true;
        anim.SetBool("Dead", true);
        acidAnim.SetBool("Dead", true);
        boxCollider.enabled = false;
        body.simulated = false;
        if (stateInfo.IsName("Death") && stateInfo.normalizedTime >= 1.0f )
        {
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator flinch()
    {      
        anim.SetBool("Attack", false); 
        yield return new WaitForSeconds(flinchDuration);
    }
}
