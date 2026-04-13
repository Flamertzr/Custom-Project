using UnityEngine;

public class eliasRookCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject elias;
    [SerializeField] private GameObject eliasTextBox;
    [SerializeField] private GameObject eliasText1;
    [SerializeField] private GameObject eliasText2;
    [SerializeField] private GameObject eliasText3;

    private PlayerMoveScript playerMove;
    private Animator eliasAnim;

    private int cutsceneActivated = 0;

    private Vector3 camPos;

    void Start()
    {
        playerMove = player.GetComponent<PlayerMoveScript>();
        eliasAnim = elias.GetComponent<Animator>();

        eliasTextBox.SetActive(false);
        eliasText1.SetActive(false);
        eliasText2.SetActive(false);  
        eliasText3.SetActive(false);   
    }

    void Update()
    {
        camPos = Camera.main.transform.position;

        eliasTextBox.transform.position = new Vector3(
            camPos.x,
            camPos.y + 35,
            0f
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cutsceneActivated++;

            if (cutsceneActivated == 1)
            {
                StartCoroutine(cutsceneTimer());
            }
        }
    }

    private System.Collections.IEnumerator cutsceneTimer()
    {
        playerMove.inCutscene = true;

        eliasAnim.SetBool("InitCutscene", true);
        yield return new WaitForSeconds(1.8f);
        eliasAnim.SetBool("InitCutscene", false);

        eliasTextBox.SetActive(true);
        eliasText1.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        eliasText1.SetActive(false);

        eliasText2.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        eliasText2.SetActive(false); 

        eliasText3.SetActive(true);
        yield return new WaitForSeconds(7f);
        eliasText3.SetActive(false); 
        eliasTextBox.SetActive(false);

        eliasAnim.SetBool("SitDown", true);
        yield return new WaitForSeconds(1.5f);
        eliasAnim.SetBool("SitDown", false);

        playerMove.inCutscene = false;
    }
}
