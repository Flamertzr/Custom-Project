using UnityEngine;

public class oldManCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject oldManTextBox;
    [SerializeField] private GameObject oldManText1;
    [SerializeField] private GameObject oldManText2;
    [SerializeField] private GameObject oldManText3;
    [SerializeField] private GameObject oldManText4;

    private PlayerMoveScript playerMove;

    private int cutsceneActivated = 0;

    private Vector3 camPos;

    public bool banditsDead = false;
    public bool talkToOldMan = false;

    void Start()
    {
        playerMove = playerObject.GetComponent<PlayerMoveScript>();

        oldManTextBox.SetActive(false);
        oldManText1.SetActive(false);
        oldManText2.SetActive(false);
        oldManText3.SetActive(false);
        oldManText4.SetActive(false);
        
    }

    void Update()
    {
        camPos = Camera.main.transform.position;

        oldManTextBox.transform.position = new Vector3(
            camPos.x,
            camPos.y + 50,
            0f
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && banditsDead == true)
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

        oldManTextBox.SetActive(true);
        oldManText1.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        oldManText1.SetActive(false);

        oldManText2.SetActive(true);
        yield return new WaitForSeconds(7f);
        oldManText2.SetActive(false);

        oldManText3.SetActive(true);
        yield return new WaitForSeconds(10f);
        oldManText3.SetActive(false);

        oldManText4.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        oldManText4.SetActive(false);

        playerMove.inCutscene = false;
        oldManTextBox.SetActive(false);

        talkToOldMan = true;
    }
}
