using UnityEngine;
using UnityEngine.SceneManagement;

public class L2MusicScript : MonoBehaviour
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
        if (scene.name != "L2")
        {
            audioSource.Stop();
        }
    }
}
