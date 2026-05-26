using UnityEngine;

public class kaelMashCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject kael;

    [SerializeField] private GameObject kaelTextBox;
    [SerializeField] private GameObject kaelText1;

    [SerializeField] private GameObject eliasTextBox;
    [SerializeField] private GameObject eliasText1;

    private PlayerMoveScript playerMove;
    private Rigidbody2D playerBody;
    private Animator kaelAnim;
    private Rigidbody2D kaelBody;

    public bool cutscene1Triggered = false;

    public bool cutscene1Complete = false;
    public bool cutscene2Complete = false;

    private Vector3 camPos;

    void Start()
    {
        playerMove = player.GetComponent<PlayerMoveScript>();
        playerBody = player.GetComponent<Rigidbody2D>();
        kaelAnim = kael.GetComponent<Animator>();
        kaelBody = kael.GetComponent<Rigidbody2D>();

        kaelTextBox.SetActive(false);
        kaelText1.SetActive(false);   

        eliasTextBox.SetActive(false);
        eliasText1.SetActive(false); 
    }

    void Update()
    {
            camPos = Camera.main.transform.position;

            kaelTextBox.transform.position = new Vector3(
                camPos.x,
                camPos.y + 35,
                0f
            );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!cutscene1Complete && !cutscene1Triggered)
            {
                StartCoroutine(cutscene());
            }

            if (cutscene1Complete && !cutscene2Complete)
            {
                StartCoroutine(cutscene2());
            }
        }
    }

    private System.Collections.IEnumerator cutscene()
    {
        cutscene1Triggered = true;
        playerMove.inCutscene = true;

        kaelAnim.SetBool("InitCutscene", true);
        yield return new WaitForSeconds(1.8f);
        kaelAnim.SetBool("InitCutscene", false);

        kaelTextBox.SetActive(true);
        kaelText1.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        kaelText1.SetActive(false);
        //continue here

        kaelTextBox.SetActive(false);
        cutscene1Complete = true;
    }

    private System.Collections.IEnumerator cutscene2()
    {
        playerMove.inCutscene = true;

        kaelTextBox.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        //continue here

        kaelTextBox.SetActive(false);
        cutscene2Complete = true;
        playerMove.inCutscene = false;
    }
}

