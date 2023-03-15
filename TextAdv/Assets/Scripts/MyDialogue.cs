using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MyDialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogueBox;
    public string[] sentences;
    public float dialogueSpeed = 0.1f;
    public AudioSource charVoice;
    public bool isDone = true;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool NextSentence()
    {
        if (index < sentences.Length)
        {
            DialogueBox.text = "";
            StartCoroutine(WriteSentence());
            return true;
        }
        else return false;
    }

    IEnumerator WriteSentence()
    {
        isDone = false;
        foreach (char myChar in sentences[index].ToCharArray())
        {
            //charVoice.Play();
            DialogueBox.text += myChar;
            yield return new WaitForSeconds(dialogueSpeed);
            //charVoice.Stop();
        }
        isDone = true;
        index++;
    }
}
