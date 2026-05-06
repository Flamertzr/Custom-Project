using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class L2CompleteScript : MonoBehaviour
{
    [SerializeField] private eliasRookCutsceneScript eliasScript;
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
        if (other.CompareTag("Player") && eliasScript.bandit4 == null && eliasScript.cutscene2Complete == true)
        {
            returnToMain();
        }
    }

    public void returnToMain()
    {
        fade.StartFadeOut();
        StartCoroutine(loadNext());
        
    }

    IEnumerator loadNext()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main Menu");
        yield return null;
    }
}