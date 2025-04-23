using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalTrigger : MonoBehaviour
{
    public GameObject teleportPoint;
    public UnityEvent[] eventsToExecute;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Action();
        }
    }

    public void Action()
    {
        foreach (var eventToExecute in eventsToExecute)
        {
            eventToExecute?.Invoke();
        }
        GameManager.Instance.TeleportPlayer(teleportPoint.transform);
    }
}
