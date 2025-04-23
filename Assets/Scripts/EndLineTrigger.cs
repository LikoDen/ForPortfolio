using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.canEnterTrigger)
        {
            StartLineTrigger.Instance.wind.Stop();
            GameManager.Instance.canEnterTrigger = false;
            GameManager.Instance.skyDive = false;
            GameManager.Instance.speedEffect.SetActive(false);
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        StartLineTrigger.Instance.textDistance.gameObject.SetActive(false);
        GameManager.Instance.PlayerWin((int)StartLineTrigger.Instance.GetTotalDistance());
    }
}
