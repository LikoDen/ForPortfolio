using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangePlatform : MonoBehaviour
{
    public GameObject[] challenges;

    public void GenerateChallenge()
    {
        foreach (var challenge in challenges)
            challenge.SetActive(false);
        
        challenges[Random.Range(0, challenges.Length)].SetActive(true);
    }
}
