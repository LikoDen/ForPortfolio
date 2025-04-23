using System;
using System.Collections;
using System.Collections.Generic;
using ECM2;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObstaclesLineController : MonoBehaviour
{
    public Character player;
    public GameObject linePart;
    public GameObject[] endLines;
    public int count;
    public int lenght;
    public GameObject startPosition;

    public List<GameObject> parts;

    public static ObstaclesLineController Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Respawn()
    {
        foreach (var part in parts)
        {
            Destroy(part);
        }
        parts.Clear();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Vector3 position = startPosition.transform.position;
        for (var i = 0; i < count + GameManager.Instance.cups; i++)
        {
            var part = Instantiate(linePart, position, Quaternion.identity);
            parts.Add(part);
            parts[i].GetComponent<LinePart>().OpenPlates(i >= GameManager.Instance.mainParameter);
            position.z += lenght;
            yield return new WaitForSeconds(0.05f);
        }
        
        var endLinePart = Instantiate(endLines[Random.Range(0, endLines.Length)], position, Quaternion.identity);
        parts.Add(endLinePart);
    }

    public void TeleportToLast()
    {
        Vector3 newPPosition = startPosition.transform.position;

        int pos = GameManager.Instance.mainParameter > GameManager.Instance.cups ? GameManager.Instance.cups + 4 : GameManager.Instance.mainParameter - 1;
        
        print(pos);
        
        newPPosition.z += lenght * pos;
        newPPosition.y = 5;
        newPPosition.x = parts[pos].GetComponent<LinePart>().notBroken;
        player.TeleportPosition(newPPosition);
    }
}