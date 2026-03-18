using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuMusicScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Backstory 1")
        {
            audioSource.Stop();
        }
    }
}
