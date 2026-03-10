using UnityEngine;

public class banditCutsceneScript : MonoBehaviour
{

    [SerializeField] private GameObject banditTextStuff; 
    int cutsceneActivated = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        banditTextStuff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cutsceneActivated += 1;
            if (cutsceneActivated == 1)
            {
                banditTextStuff.SetActive(true);
            }
        }

    }
}
