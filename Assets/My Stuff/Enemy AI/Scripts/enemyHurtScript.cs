using UnityEngine;

public class enemyHurtScript : MonoBehaviour
{
    [SerializeField] public float flashDuration;
    public static float iframesDuration = 2;
    public static int health = 100;

    private static float iframes;
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
            Debug.Log("Death");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hitbox") && iframes <= 0)
        {
            iframes = iframesDuration;
            health -= 1;
            StartCoroutine(hit());
        }
    }

    private System.Collections.IEnumerator hit()
    {
        sprite.color = Color.red;        
        yield return new WaitForSeconds(flashDuration);
        sprite.color = originalColor;    
    }
}
