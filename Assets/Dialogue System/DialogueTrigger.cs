using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [Header("Settings")]
    public bool onTriggerEnter;
    [SerializeField] private bool repeatable;
    private bool _played=false;
    public void TriggerDialogue()
    {
        if (repeatable)
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }
        else if (!_played)
        {
            DialogueManager.instance.StartDialogue(dialogue);
            _played = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Colliding With Player");
                other.gameObject.GetComponent<PlayerController>().triggerDialogue = true;
                TriggerDialogue();
            }
        }
    }
}
