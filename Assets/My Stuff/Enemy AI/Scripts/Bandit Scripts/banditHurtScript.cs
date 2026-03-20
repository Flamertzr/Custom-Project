using UnityEngine;

public class banditHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int health = 100;
    [SerializeField] public float flinchDuration;

    [SerializeField] private oldManCutsceneScript oldman;

    public bool dead = false;
    private bool flashing = false;

    private GameObject enemy;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
    private banditAttackScript banditAttack;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemy = gameObject;
        playerAttack = player.GetComponent<PlayerAttackScript>();
        banditAttack = GetComponent<banditAttackScript>();
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        iframes -= Time.deltaTime;
        if (health <=0)
        {
            death();
            oldman.banditsDead = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player Hitbox") && iframes < -iframesDuration)
        {
            StartCoroutine(flinch());
            iframes = iframesDuration;
            banditAttack.hurtTimer = banditAttack.flinchDuration;
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
        boxCollider.enabled = false;
        body.simulated = false;
        if (stateInfo.IsName("death") && stateInfo.normalizedTime >= 1.0f )
        {
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator flinch()
    {      
        anim.SetBool("Punch", false); 
        yield return new WaitForSeconds(flinchDuration);
    }
}
