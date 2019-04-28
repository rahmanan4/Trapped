using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : Interactable
{
    public override void Interact()
    {
        // base.Interact() will make the parent Interact happen
        Debug.Log("Interacting with base action item");
    }
}
