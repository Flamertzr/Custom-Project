using UnityEngine;

public class kaelGruntFollowScript : MonoBehaviour
{
    [SerializeField] public float speed;
    public GameObject player;
    private Animator anim;

    public float distance;

    private kaelGruntHurtScript hurtScript;
    private kaelGruntAttackScript attkScript;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        hurtScript = GetComponent<kaelGruntHurtScript>();
        attkScript = GetComponent<kaelGruntAttackScript>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hurtScript.dead == false)
        {
            float directionX = player.transform.position.x - transform.position.x;
            
            
            // 🔥 Always face the player
            if (directionX > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (directionX < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

            // Movement logic
            if (attkScript.close >= 50)
            {
                anim.SetBool("Walk", true);

                distance = Vector2.Distance(transform.position, player.transform.position);
                Vector2 targetPos = new Vector2(player.transform.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        }
    }
}