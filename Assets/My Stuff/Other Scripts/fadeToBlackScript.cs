using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadeToBlack : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    private float duration = 2f;

    public void StartFadeOut()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / duration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);

            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }
}