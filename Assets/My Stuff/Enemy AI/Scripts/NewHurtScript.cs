using UnityEngine;

public class enemyHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int health = 100;

    public bool dead = false;
    private bool flashing = false;

    private GameObject enemy;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
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
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        iframes -= Time.deltaTime;
        if (health <=0)
        {
            dead = true;
            anim.SetBool("Dead", true);
            boxCollider.enabled = false;
            body.simulated = false;
            if (stateInfo.IsName("Death Animation") && stateInfo.normalizedTime >= 1.0f )
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox") && iframes < -iframesDuration)
        {
            iframes = iframesDuration;
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
}
