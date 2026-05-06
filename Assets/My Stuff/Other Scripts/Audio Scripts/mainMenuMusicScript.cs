using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuMusicScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    static mainMenuMusicScript instance;

    public bool audioPlaying = false;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        play();
    }

    void play()
    {
        if (!audioPlaying)
        {
            audioSource.Play();
            audioPlaying = true;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Levels" || scene.name == "How To Play" || scene.name == "Main Menu")
        {
            play();
        }
        else
        {
            audioSource.Stop();
            audioPlaying = false;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}