using UnityEngine;

public class eliasRookCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject elias;

    [SerializeField] private GameObject eliasTextBox;
    [SerializeField] private GameObject eliasText1;
    [SerializeField] private GameObject eliasText2;
    [SerializeField] private GameObject eliasText3;

    [SerializeField] private GameObject eliasLeft;
    [SerializeField] private GameObject eliasRight;
    [SerializeField] private GameObject eliasText4;

    [SerializeField] private GameObject eliasText5;
    [SerializeField] private GameObject eliasText6;
    [SerializeField] private GameObject eliasText7;
    [SerializeField] private GameObject eliasText8;
    [SerializeField] private GameObject eliasText9;
    [SerializeField] private GameObject eliasText10;

    [SerializeField] private GameObject bandit1;
    [SerializeField] private GameObject bandit2;
    [SerializeField] private GameObject bandit3;
    [SerializeField] private GameObject bandit4;

    private PlayerMoveScript playerMove;
    private Rigidbody2D playerBody;
    private Animator eliasAnim;
    private Rigidbody2D eliasBody;

    private bool cutscene1Triggered = false;

    private bool cutscene1Complete = false;
    private bool cutscene2Complete = false;

    private Vector3 camPos;

    void Start()
    {
        playerMove = player.GetComponent<PlayerMoveScript>();
        playerBody = player.GetComponent<Rigidbody2D>();
        eliasAnim = elias.GetComponent<Animator>();
        eliasBody = elias.GetComponent<Rigidbody2D>();

        eliasTextBox.SetActive(false);
        eliasText1.SetActive(false);
        eliasText2.SetActive(false);  
        eliasText3.SetActive(false);

        eliasLeft.SetActive(false);
        eliasRight.SetActive(false);

        eliasText4.SetActive(false);
        eliasText5.SetActive(false);
        eliasText6.SetActive(false);
        eliasText7.SetActive(false);
        eliasText8.SetActive(false);
        eliasText9.SetActive(false);
        eliasText10.SetActive(false);

        bandit1.SetActive(false);
        bandit2.SetActive(false);  
        bandit3.SetActive(false);  
        bandit4.SetActive(false);     
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
            if (!cutscene1Complete && !cutscene1Triggered)
            {
                StartCoroutine(cutscene());
            }

            if (cutscene1Complete && !cutscene2Complete && bandit4 == null)
            {
                StartCoroutine(cutscene2());
            }
        }
    }

    private System.Collections.IEnumerator cutscene()
    {
        cutscene1Triggered = true;
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

        eliasTextBox.SetActive(true);
        eliasLeft.SetActive(true);
        yield return new WaitForSeconds(1f);
        eliasLeft.SetActive(false);
        eliasTextBox.SetActive(false);
        bandit1.SetActive(true);
        yield return new WaitForSeconds(1f/* */);

        eliasTextBox.SetActive(true);
        eliasRight.SetActive(true);
        yield return new WaitForSeconds(1f);
        eliasRight.SetActive(false);
        eliasTextBox.SetActive(false);
        bandit3.SetActive(true);
        yield return new WaitForSeconds(1f/* */);

        eliasTextBox.SetActive(true);
        eliasLeft.SetActive(true);
        yield return new WaitForSeconds(1f);
        eliasLeft.SetActive(false);
        eliasTextBox.SetActive(false);
        bandit2.SetActive(true);
        yield return new WaitForSeconds(1f/* */);

        eliasTextBox.SetActive(true);
        eliasRight.SetActive(true);
        yield return new WaitForSeconds(1f);
        eliasRight.SetActive(false);
        eliasTextBox.SetActive(false);
        bandit4.SetActive(true);
        yield return new WaitForSeconds(1f/* */);

        cutscene1Complete = true;
    }

    private System.Collections.IEnumerator cutscene2()
    {
        playerMove.inCutscene = true;

        eliasAnim.SetBool("InitCutscene", true);
        yield return new WaitForSeconds(1.8f);
        eliasAnim.SetBool("InitCutscene", false);

        eliasTextBox.SetActive(true);
        eliasText4.SetActive(true);
        yield return new WaitForSeconds(3f);
        eliasText4.SetActive(false);

        eliasText5.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        eliasText5.SetActive(false); 

        eliasText6.SetActive(true);
        yield return new WaitForSeconds(5f);
        eliasText6.SetActive(false); 
        eliasTextBox.SetActive(false);

        eliasTextBox.SetActive(true);
        eliasText7.SetActive(true);
        yield return new WaitForSeconds(6f);
        eliasText7.SetActive(false);

        eliasTextBox.SetActive(true);
        eliasText8.SetActive(true);
        yield return new WaitForSeconds(9f);
        eliasText8.SetActive(false);

        eliasTextBox.SetActive(true);
        eliasText9.SetActive(true);
        yield return new WaitForSeconds(5.8f);
        eliasText9.SetActive(false);

        eliasTextBox.SetActive(true);
        eliasText10.SetActive(true);
        yield return new WaitForSeconds(3f);
        eliasText10.SetActive(false);
        eliasTextBox.SetActive(false);

        eliasBody.linearVelocity = new Vector2(20, 0);
        eliasAnim.SetBool("Walk", true);
        yield return new WaitForSeconds(2f);
        
        playerMove.inCutscene = false;
    }
}

