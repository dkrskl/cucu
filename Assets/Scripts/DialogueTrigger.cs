using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Next Scene to Go to")]
    public int nextScene;

    public Dialogue myDialogue;


    public void TriggerDialogue()
    {

        DialogueController controller = FindObjectOfType<DialogueController>();
        controller.StartDialogue(myDialogue);

        controller.nextSceneNumber = nextScene;
    }

}
