using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private Dialogue dialogue;
    private bool isInTrigger = false;

    private void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        isInTrigger = false;
    }


}
