using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupItem : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacting with Item!");
    }
}
