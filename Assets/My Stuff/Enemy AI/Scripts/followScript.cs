using UnityEngine;

public class followScript : MonoBehaviour
{
    [SerializeField] public float speed;
    public GameObject player;


    private float distance;
    private enemyHurtScript hurtScript;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        hurtScript = GetComponent<enemyHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtScript.dead != true)
        {
            Vector2 direction = player.transform.position - transform.position;

            

            Vector2 targetPos = new Vector2(player.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
