using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable
{
    public string[] dialogue;

    public string name_s;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name_s);
        //Debug.Log("Interacting with NPC.");
    }
}
