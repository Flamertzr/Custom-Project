using UnityEngine;

public class banditCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject banditTextBox;
    [SerializeField] private GameObject banditText;
    [SerializeField] private banditFollowScript bandit1;
    [SerializeField] private banditFollowScript bandit2;
    private PlayerMoveScript playerMove;

    private int cutsceneActivated = 0;

    private Vector3 camPos;

    void Start()
    {
        playerMove = playerObject.GetComponent<PlayerMoveScript>();

        banditTextBox.SetActive(false);
        banditText.SetActive(false);
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
                banditTextBox.SetActive(true);
                banditText.SetActive(true);

                playerMove.inCutscene = true;

                StartCoroutine(cutsceneTimer());
            }
        }
    }

    private System.Collections.IEnumerator cutsceneTimer()
    {
        yield return new WaitForSeconds(2f);

        bandit1.player = playerObject;
        bandit2.player = playerObject;

        playerMove.inCutscene = false;

        banditTextBox.SetActive(false);
        banditText.SetActive(false);
    }
}