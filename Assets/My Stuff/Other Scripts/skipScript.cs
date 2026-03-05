using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skipScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skip()
    {
        SceneManager.LoadScene("L1");
    }
}
