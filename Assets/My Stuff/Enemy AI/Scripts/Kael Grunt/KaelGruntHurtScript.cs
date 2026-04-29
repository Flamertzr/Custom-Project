using UnityEngine;

public class kaelGruntHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int health = 100;
    [SerializeField] public float flinchDuration;

    public bool dead = false;
    private bool flashing = false;
    public bool stunned = false;

    private GameObject enemy;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
    private kaelGruntAttackScript kaelGruntAttack;
    private Animator anim;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemy = gameObject;
        playerAttack = player.GetComponent<PlayerAttackScript>();
        kaelGruntAttack = GetComponent<kaelGruntAttackScript>();
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Countdown i-frames but don't go below 0
        iframes -= Time.deltaTime;
        if (iframes < 0)
            iframes = 0;

        if (health <= 0 && !dead)
        {
            death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Hitbox") && iframes <= 0 && !dead)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        iframes = iframesDuration;

        StartCoroutine(flinch());
        kaelGruntAttack.hurtTimer = kaelGruntAttack.flinchDuration;

        health -= playerAttack.currDmg;

        if (!flashing)
        {
            StartCoroutine(hits());
        }
    }

    private System.Collections.IEnumerator hits()
    {
        flashing = true;
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        sprite.color = originalColor;

        yield return new WaitForSeconds(iframesDuration - 0.2f);

        flashing = false;
    }

    private void death()
    {
        dead = true;

        anim.SetBool("Dead", true);
        boxCollider.enabled = false;
        body.simulated = false;

        StartCoroutine(DestroyAfterAnimation());
    }

    private System.Collections.IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1f); // adjust to match animation length
        Destroy(gameObject);
    }

    private System.Collections.IEnumerator flinch()
    {
        stunned = true;
        anim.SetBool("Stun", true);
        yield return new WaitForSeconds(flinchDuration);
        anim.SetBool("Stun", false);
        stunned = false;
    }
}