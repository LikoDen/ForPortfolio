using System;
using ECM2;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using YG;

public class GameManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject ground;
    public Character player;
    public GameObject speedEffect;
    public GameObject[] pets;
    public TrailRenderer[] trailRenderers;
    public Material[] trailMaterials;
    public Animator animationPlayer;
    public GameObject playerRespawn;
    public GameObject islandBlock;
    public TextMeshProUGUI cupsText; 
    public int cups = 0; 
    public int cupsCounter = 1; 
    public TextMeshProUGUI mainParameterText; 
    public int mainParameter = 1;
    public int mainParameterCounter = 1;  
    public int wins = 0;
    public bool isWalk;
    public bool isMobile;
    public bool lockMobileCameraRotate;
    public bool skyDive;
    public bool canEnterTrigger = true;
    public GameObject[] mobileElements;
    public GameObject[] pcElements;
    public GameObject[] iosDisableElements;
        
    public TextMeshProUGUI floorsText; 
    public TextMeshPro floorsCostText; 
    public int floors = 1;  
    public int floorsCounter = 1; 
    public int floorsCost = 1; 
    public TextMeshProUGUI speedText;  
    public TextMeshPro speedCostText; 
    public int speed = 1; 
    public int speedCounter = 1;  
    public int speedCost = 1;

    public float petsCounter = 1;
    public float linesCounter = 1;
    
    public bool isCursorVisible = false;

    public static GameManager Instance;

    public AudioSource Audio, WindAudio;

    private void Awake()
    {
        AdsController.isPause = false;
        Time.timeScale = 1;
        Audio.volume = 0.5f;
        WindAudio.volume = 1.0f;;
        Audio.UnPause();
        WindAudio.UnPause();
        Instance = this;
    }

    private void Start()
    {
        isMobile = YandexGame.EnvironmentData.isMobile;

        if (YandexGame.EnvironmentData.platform == "iPhone" || YandexGame.EnvironmentData.browser == "Safari")
        {
            foreach (var element in iosDisableElements)
                element.SetActive(false);
        }
        
        if(!isMobile)
        {
            foreach (var element in mobileElements)
                element.SetActive(false);
            
            /*Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/
        }
        else
        {
            foreach (var element in pcElements)
                element.SetActive(false);
        }
        
        YandexGame.GameReadyAPI();

        cups = YandexGame.savesData.cups;
        mainParameter = YandexGame.savesData.mainParam;
        wins = YandexGame.savesData.wins;

        floors = YandexGame.savesData.floors;
        speed = YandexGame.savesData.speed;
        
        ShowParamsAndCups();
    }

    void Update()
    {
        // Проверка нажатия клавиши Tab для включения/выключения курсора
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCursorVisible = !isCursorVisible;

            if (isCursorVisible)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }*/
    }

    public GameObject popup_Lines, popup_Pets, errorText;

    public void Popup_Lines(bool value)
    {
        if (!Input.anyKey || YandexGame.EnvironmentData.isMobile == true)
        {
            popup_Lines.SetActive(value);
        }
        else
        {
            StartCoroutine(TextError());
        }
    }

    public void Popup_Pets(bool value)
    {
        if (!Input.anyKey || YandexGame.EnvironmentData.isMobile == true)
        {
            popup_Pets.SetActive(value);
        }
        else
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(TextError());
            }
        }
    }

    IEnumerator TextError()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(3f);
        errorText.SetActive(false);
    }

    public void StartGame()
    {
        print("Start game");
    }

    public void PlayAnimation(string nameAnimation)
    {
        AnimatorClipInfo[] animatorinfo;
        string current_animation;
        
        animatorinfo = this.animationPlayer.GetCurrentAnimatorClipInfo(0);
        try
        {
            current_animation = animatorinfo[0].clip.name;
            animationPlayer.CrossFade(nameAnimation, 0.1f);
        }
        catch (Exception e)
        {
        }
    
    }

    public void PlayerRespawn()
    {
        player.TeleportPosition(playerRespawn.transform.position);
    }

    public void TeleportPlayer(Transform teleportPoint)
    {
        player.TeleportPosition(teleportPoint.position);
    }
    
    public void TeleportPlayerToStartPoint(Transform teleportPoint)
    {
        player.TeleportPosition(new Vector3(teleportPoint.position.x, player.transform.position.y, teleportPoint.position.z));
    }

    public void PlayerWin(int newCups)
    {
        if(cups < newCups)
            cups = newCups;
        
        mainParameter += (int)(newCups * cupsCounter * petsCounter);

        ShowParamsAndCups();
    
        PlayerRespawn();
        wins++;
        YandexGame.NewLeaderboardScores("Leaders", cups);
        Save();
        canEnterTrigger = true;
    }

    public void ShowParamsAndCups()
    {
        mainParameterText.text = mainParameter.ToString();
        cupsText.text = cups.ToString();

        floorsText.text = floors.ToString();
        speedText.text = speed.ToString();

        ground.transform.position = new Vector3(ground.transform.position.x,
            ground.transform.parent.transform.position.y - 8.5f * floors, ground.transform.position.z);
        
        floorsCost = GetCost(floors);
        floorsCostText.text = floorsCost.ToString();
        speedCost = GetCost(speed);
        speedCostText.text = speedCost.ToString();
        
        CheckIsland();
        CheckPets();
        CheckLines();
    }

    private void CheckIsland()
    {
        if(cups >= 50000)
            islandBlock.SetActive(false);
    }
    
    private void CheckPets()
    {
        if (cups >= 1000)
        {
            pets[0].SetActive(true);
            pets[1].SetActive(true);
            pets[2].SetActive(true);
            petsCounter = 1.1f;
        }
        else if(cups >= 5000)
        {
            pets[0].SetActive(true);
            pets[1].SetActive(true);
            petsCounter = 1.25f;
        }
        else if(cups >= 25000)
        {
            pets[0].SetActive(true);
            petsCounter = 1.5f;
        }
    }

    private void CheckLines()
    {
        if (cups >= 1000)
        {
            foreach (var trail in trailRenderers)
            {
                trail.material = trailMaterials[0];
            }
            linesCounter = 1.1f;
        }
        else if(cups >= 10000)
        {
            foreach (var trail in trailRenderers)
            {
                trail.material = trailMaterials[1];
            }
            linesCounter = 1.25f;
        }
        else if(cups >= 100000)
        {
            foreach (var trail in trailRenderers)
            {
                trail.material = trailMaterials[2];
            }
            linesCounter = 1.5f;
        }
    }
    
    public void BuyFloor()
    {
        if(mainParameter < floorsCost)
            return;
        
        mainParameter -= floorsCost;
        floors++;
        ShowParamsAndCups();
        Save();
    }

    public void BuySpeed()
    {
        if(mainParameter < speedCost)
            return;

        mainParameter -= speedCost;
        speed++;
        ShowParamsAndCups();
        Save();
    }

    public void AddCupsAds()
    {
        floors += 1;
        ShowParamsAndCups();
        Save();
    }

    public void AddParamAds()
    {
        speed += 1;
        ShowParamsAndCups();
        Save();
    }

    public int GetCost(float param)
    {
        return (int)(param * 150);
    }
    
    public void Save()
    {
        YandexGame.savesData.cups = cups;
        YandexGame.savesData.mainParam = mainParameter;
        YandexGame.savesData.wins = wins;
        YandexGame.savesData.floors = floors;
        YandexGame.savesData.speed = speed;
        
        YandexGame.SaveProgress();
    }
}