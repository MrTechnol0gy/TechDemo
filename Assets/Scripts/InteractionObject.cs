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
        pickup,         // objects that are picked up
        dialogue        // lines of dialogue from a character
    }

    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("Simple Info Message")]
    public string infoMessage;
    private TMP_Text infoText;
    private Outline outline;
    private GameObject thisGameObject;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;

    public void Start()
    {
        thisGameObject = this.gameObject;
        infoText = GameObject.Find("InfoText").GetComponentInChildren<TMP_Text>();
        outline = GetComponent<Outline>();
        outline.enabled = !outline.enabled;     //outline starts disabled
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
    public void PickUp()
    {
        this.gameObject.SetActive(false);
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("outline enabled");
            outline.enabled = !outline.enabled;     //turning it off turns it on. That doesn't make any sense, but it works.
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("outline disabled");
            outline.enabled = !outline.enabled;     //turning it off turns it off, which makes sense, unless it doesn't.
        }
    }
}