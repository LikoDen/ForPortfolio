using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ObstaclesLineController.Instance.Respawn();
            GameManager.Instance.PlayerRespawn();
        }
    }
}
