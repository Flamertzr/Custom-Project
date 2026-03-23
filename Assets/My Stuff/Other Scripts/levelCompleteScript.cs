using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelCompleteScript : MonoBehaviour
{
    [SerializeField] private oldManCutsceneScript oldManScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && oldManScript.banditsDead == true && oldManScript.talkToOldMan == true)
        {
            returnToLevels();
        }
    }

    public void returnToLevels()
    {
        // Make in coroutine
        // Keep player moving + lock controls
        // Fade to black
        SceneManager.LoadScene("Levels");
    }
}
