using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class deathTypewriterScript : MonoBehaviour
{
	Text _text;
	TMP_Text _tmpProText;
	string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;

	// Use this for initialization
	void Start()
	{
		_text = GetComponent<Text>()!;
		_tmpProText = GetComponent<TMP_Text>()!;

		randomText();
	}

	IEnumerator TypeWriterText()
	{
		_text.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_text.text.Length > 0)
			{
				_text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
			}
			_text.text += c;
			_text.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if(leadingChar != "")
        {
			_text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
		}
	}

	IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
			}
			_tmpProText.text += c;
			_tmpProText.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
	}

	public void randomText()
	{
		int random = Random.Range(1, 6);

		if (random == 1)
		{
			writer = "My grandma can fight better than you.";
		}
		else if (random == 2)
		{
			writer = "Wait you died? HAHA Loser!";
		}
		else if (random == 3)
		{
			writer = "Imagine dying to that! Weakling.";
		}
		else if (random == 4)
		{
			writer = "Does not suprise me.";
		}
		else if (random == 5)
		{
			writer = "Filthy monkey who can't even use Jujutsu!";
		}

		StopAllCoroutines();

		if (_text != null)
		{
			_text.text = "";
			StartCoroutine(TypeWriterText());
		}
		else if (_tmpProText != null)
		{
			_tmpProText.text = "";
			StartCoroutine(TypeWriterTMP());
		}
	}
}