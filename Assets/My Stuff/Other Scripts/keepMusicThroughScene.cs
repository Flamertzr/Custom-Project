using UnityEngine;

public class keepMusicThroughScene : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
