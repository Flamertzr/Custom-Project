using UnityEngine;

public class enemyHurtScript : MonoBehaviour
{
    [SerializeField] public float iframes;
    [SerializeField] public float iframesDuration;
    [SerializeField] public int health = 100;
    public bool dead = false;

    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Color originalColor;
    private GameObject player;
    private PlayerAttackScript playerAttack;
    

    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerAttack = player.GetComponent<PlayerAttackScript>();
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        iframes -= Time.deltaTime;
        if (health <=0)
        {
            dead = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox") && iframes < iframesDuration)
        {
            iframes = iframesDuration;
            health -= 1;
            StartCoroutine(hits());
        }
    }

    private System.Collections.IEnumerator hits()
    {
        sprite.color = Color.red;        
        yield return new WaitForSeconds(.2f);
        sprite.color = originalColor;  
        yield return new WaitForSeconds(iframesDuration);  
    }
}
