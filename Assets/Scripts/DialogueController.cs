using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{

    public Text dialogueText;

    Queue<string> sentences;

    [HideInInspector]
    public int nextSceneNumber;

    // this is used so that once a dialogue ends it will also trigger an Activator
    public GameObject myActivator;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {

        if(sentences.Count == 0)
        {

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.04f);
        }


        yield return new WaitForSeconds(1);

        // Change the scene once the dialogue ends completely 
        myActivator.GetComponent<Activator>().ChangeScene(nextSceneNumber);

    }

    


}
