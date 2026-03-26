using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class levelCompleteScript : MonoBehaviour
{
    [SerializeField] private oldManCutsceneScript oldManScript;
    [SerializeField] private fadeToBlack fade;
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
        fade.StartFadeOut();
        StartCoroutine(loadNext());
        
    }

    IEnumerator loadNext()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Levels");
        yield return null;
    }
}
