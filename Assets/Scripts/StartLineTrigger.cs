using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLineTrigger : MonoBehaviour
{
    public TextMeshProUGUI textDistance;
    public GameObject textError, playerGameObject;
    public GameObject parachute;
    public GameObject startPoint;
    public GameObject continuePoint;
    public AudioSource wind;
    public AudioSource main;
    public float speed;
    
    private Vector3 _lastPosition;
    private float _totalDistance;

    public static StartLineTrigger Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (textDistance.gameObject.activeSelf == true)
        {
            if (textError.activeSelf == true)
            {
                textError.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        textDistance.gameObject.SetActive(true);
        GameManager.Instance.skyDive = true;
        _totalDistance = 0;
        _lastPosition = startPoint.transform.position;
        GameManager.Instance.player.transform.rotation = Quaternion.Euler(0,0,0);
        GameManager.Instance.TeleportPlayer(startPoint.transform);
        GameManager.Instance.speedEffect.SetActive(true);
        
        if(main.isPlaying)
            wind.Play();
    }

    void FixedUpdate()
    {
        if(!GameManager.Instance.skyDive)
        {
            parachute.SetActive(false);
            return;
        }
    
        float distance = Vector3.Distance(playerGameObject.transform.position, _lastPosition);
        _totalDistance += distance;
        _lastPosition = playerGameObject.transform.position;
        textDistance.text = _totalDistance.ToString("F1");
    
        parachute.SetActive(true);
        playerGameObject.transform.position = new Vector3(0, playerGameObject.transform.position.y, playerGameObject.transform.position.z);
    
        playerGameObject.transform.position += new Vector3(0, 0, Time.fixedDeltaTime * speed * GameManager.Instance.speed * GameManager.Instance.speedCounter * GameManager.Instance.linesCounter);
        playerGameObject.transform.Translate(Vector3.down * Time.fixedDeltaTime * (speed / 2));

        if (playerGameObject.transform.position.z > 6800f)
        {
            _lastPosition = continuePoint.transform.position;
            GameManager.Instance.TeleportPlayerToStartPoint(continuePoint.transform);
        }
    }

    
    public float GetTotalDistance()
    {
        print("Total distance: " + _totalDistance);
        return _totalDistance;
    }
}
