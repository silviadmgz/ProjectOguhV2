using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image avatar;
    Player playerScript;
    
    public Animator animator;

    private Queue<string> messages;

    void Start()
    {
        messages = new Queue<string>();
        playerScript = FindObjectOfType<Player>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerScript.UpdateControllers();
        animator.SetBool("dialogueBoxIsOpen", true);
        
        nameText.text = dialogue.name;
        avatar.sprite = dialogue.image;

        messages.Clear();

        foreach (string message in dialogue.messages)
        {
            messages.Enqueue(message);
        }

        DisplayNextMessage();
    }

    public void DisplayNextMessage()
    {
        if (messages.Count == 0)
        {
            EndDialogue();
            return;
        }
        string message = messages.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeMessage(message));
    }

    IEnumerator TypeMessage (string message)
    {
        dialogueText.text = "";
        foreach(char letter in message.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        playerScript.UpdateControllers();
        animator.SetBool("dialogueBoxIsOpen", false);
    }
}
