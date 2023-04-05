using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator animator;
    public CameraController cameraController;

    private Queue<string> dialogue; 

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();        
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        SuspendPlayerControl();

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogue.Dequeue();

        dialogueText.text = currentLine;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogue.Clear();

        Time.timeScale = 1f;
        cameraController.GetComponent<CameraController>().enabled = true;
    }

    void SuspendPlayerControl()
    {
        Time.timeScale = 0f;
        cameraController.GetComponent<CameraController>().enabled = false;               
    }
}