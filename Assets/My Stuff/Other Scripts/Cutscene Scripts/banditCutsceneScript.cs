using UnityEngine;

public class banditCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject banditTextBox;
    [SerializeField] private GameObject banditText1;
    [SerializeField] private GameObject banditText2;
    [SerializeField] private GameObject banditText3;
    [SerializeField] private GameObject banditText4;
    [SerializeField] private banditFollowScript bandit1;
    [SerializeField] private banditFollowScript bandit2;

    private PlayerMoveScript playerMove;

    private int cutsceneActivated = 0;

    private Vector3 camPos;

    void Start()
    {
        playerMove = playerObject.GetComponent<PlayerMoveScript>();

        banditTextBox.SetActive(false);
        banditText1.SetActive(false);
        banditText2.SetActive(false);
        banditText3.SetActive(false);
        banditText4.SetActive(false);
    }

    void Update()
    {
        camPos = Camera.main.transform.position;

        banditTextBox.transform.position = new Vector3(
            camPos.x,
            camPos.y + 50,
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

        banditTextBox.SetActive(true);
        banditText1.SetActive(true);
        yield return new WaitForSeconds(4f);
        banditText1.SetActive(false);

        banditText2.SetActive(true);
        yield return new WaitForSeconds(3f);
        banditText2.SetActive(false);

        banditText3.SetActive(true);
        yield return new WaitForSeconds(3f);
        banditText3.SetActive(false);

        banditText4.SetActive(true);
        yield return new WaitForSeconds(3f);
        banditText4.SetActive(false);

        bandit1.player = playerObject;
        bandit2.player = playerObject;
        playerMove.inCutscene = false;
        banditTextBox.SetActive(false);
    }
}