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
    // public AudioClip audioClip;
    public AudioSource audioSource;
    Player playerScript;
    
    public Animator animator;

    private Queue<string> messages;
    private Queue<AudioClip> recordings;
    

    void Start()
    {
        messages = new Queue<string>();
        recordings = new Queue<AudioClip>();
        playerScript = FindObjectOfType<Player>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerScript.UpdateControllers();
        animator.SetBool("dialogueBoxIsOpen", true);
        
        nameText.text = dialogue.name;
        avatar.sprite = dialogue.image;

        messages.Clear();
        recordings.Clear();

        // Can these be merged?
        foreach (string message in dialogue.messages)
        {
            messages.Enqueue(message);
        }
        
        foreach (AudioClip recording in dialogue.audioClips)
        {
            recordings.Enqueue(recording);
        }

        DisplayNextMessage();
    }

    public void DisplayNextMessage()
    {
        if (messages.Count == 0 && recordings.Count == 0)
        {
            EndDialogue();
            return;
        }


        StopAllCoroutines();

        try
        {
            AudioClip recording = recordings.Dequeue();
            StartCoroutine(PlayAudio(recording));
        }
        catch { }

        try
        {
            string message = messages.Dequeue();
            StartCoroutine(TypeMessage(message));
        }
        catch { }
    }

    IEnumerator PlayAudio(AudioClip recording)
    {
        audioSource.clip = recording;
        audioSource.Play();
        yield return null;
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
