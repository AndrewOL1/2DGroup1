using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxCont : MonoBehaviour
{
    public DialogueManager dm;
    public GameObject GameObject;
    private void Start()
    {
        dm = GetComponent<DialogueManager>();
    }

    void Update()
    {
        DisplayDialogueBox();
    }

    void DisplayDialogueBox()
    {
        if (dm.isDialogueActive)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
