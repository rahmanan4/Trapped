using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool hasInteracted;

    void Update()
    {
        if (playerAgent != null && !playerAgent.pathPending)
        {
            if (!hasInteracted && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    // virtual modifies a method and allows it to be overridden in the class
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = transform.position;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
