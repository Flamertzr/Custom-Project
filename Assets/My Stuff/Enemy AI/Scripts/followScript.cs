using UnityEngine;

public class followScript : MonoBehaviour
{
    [SerializeField] public float test;
    public GameObject player;
    public float speed;

    private float distance;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;

        if (direction.x > 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        } else {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 targetPos = new Vector2(player.transform.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
