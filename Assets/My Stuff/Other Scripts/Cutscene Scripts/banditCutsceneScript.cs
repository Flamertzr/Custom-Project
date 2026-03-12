using UnityEngine;

public class banditCutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject banditTextStuff;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject banditTextBox;
    [SerializeField] private banditFollowScript bandit1;
    [SerializeField] private banditFollowScript bandit2;
    private PlayerMoveScript playerMove;

    private int cutsceneActivated = 0;

    private Vector3 camPos;

    void Start()
    {
        playerMove = playerObject.GetComponent<PlayerMoveScript>();

        banditTextStuff.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cutsceneActivated++;

            if (cutsceneActivated == 1)
            {
                banditTextStuff.SetActive(true);

                camPos = Camera.main.transform.position;

                banditTextStuff.transform.position = new Vector3(
                    camPos.x + 400,
                    camPos.y + 100,
                    camPos.z
                );

                playerMove.inCutscene = true;

                StartCoroutine(cutsceneTimer());
            }
        }
    }

    private System.Collections.IEnumerator cutsceneTimer()
    {
        yield return new WaitForSeconds(200f);

        bandit1.player = playerObject;
        bandit2.player = playerObject;

        playerMove.inCutscene = false;

        banditTextStuff.SetActive(false);
    }
}