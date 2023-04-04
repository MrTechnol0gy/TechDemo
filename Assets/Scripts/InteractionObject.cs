using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{

    public enum InteractableType
    {
        nothing,        // default nothing object
        info,           // objects that give simple info        
        dialogue        // lines of dialogue from a character
    }

    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("Simple Info Message")]
    public string infoMessage;
    private TMP_Text infoText;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;

    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<TMP_Text>();
    }
    public void DebugTest()
    {
            Debug.Log("this is a " + gameObject.name);
    }

    public void Nothing()
    {
        Debug.LogWarning("Object " + this.gameObject.name + " has no type set.");
    }

    public void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }   

    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}