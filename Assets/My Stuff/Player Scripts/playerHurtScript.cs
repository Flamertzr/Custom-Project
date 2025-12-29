using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int maxHealth = 100;

    public int currHealth; 

    public bool dead = false;
    private bool flashing = false;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
    private enemyGeneralScript enemyAttack;
    private Animator anim;
    

    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = gameObject;
        playerAttack = player.GetComponent<PlayerAttackScript>();
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        iframes -= Time.deltaTime;

        death();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Hitbox") && iframes < -iframesDuration)
        {
            enemyAttack = other.gameObject.GetComponentInParent<enemyGeneralScript>();
            
            iframes = iframesDuration;
            currHealth -= enemyAttack.damage;
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
        yield return new WaitForSeconds(0.2f);
        sprite.color = originalColor;
        yield return new WaitForSeconds(iframesDuration - 0.2f);
        flashing = false;
    }

    private void death()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (currHealth <=0)
            {
                dead = true;
                anim.SetBool("Dead", true);
                boxCollider.enabled = false;
                body.simulated = false;
                if (dead && stateInfo.normalizedTime >= 1.0f )
                {
                    SceneManager.LoadScene("Death Screen");
                }
        }  
    }
}
