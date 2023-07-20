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

        foreach (string message in dialogue.messages)
        {
            messages.Enqueue(message);
        }
        
        foreach (AudioClip recording in dialogue.audioClips)
        {
            recordings.Enqueue(recording);
        }

        DisplayNextMessage();
        // PlayNextRecording();
    }

    // public void PlayNextRecording()
    // {
    //     recordings.Enqueue
    // }

    public void DisplayNextMessage()
    {
        if (messages.Count == 0 || recordings.Count == 0)
        {
            EndDialogue();
            return;
        }

        string message = messages.Dequeue();
        AudioClip recording = recordings.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeMessage(message));
        StartCoroutine(PlayNextAudio(recording));
    }

    IEnumerator PlayNextAudio(AudioClip recording)
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
