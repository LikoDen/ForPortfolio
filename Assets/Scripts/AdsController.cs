using System.Collections;
using ECM2;
using TMPro;
using UnityEngine;
using YG;

public class AdsController : MonoBehaviour
{
    public Character character;
    
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;
    
    public GameObject backgroundAdInfo;
    public GameObject backgroundAdClose;
    public TextMeshProUGUI textAd;
    public int intervalAd;
    
    public static bool isPause = false;
    
    private void Start()
    {
        UnPause();
        // Запуск корутины
        StartCoroutine(AdsCounting());
    }

    private IEnumerator AdsCounting()
    {
        // Бесконечный цикл
        while (true)
        {
            yield return new WaitForSeconds(intervalAd);
            AudioListener.pause = true;
            Time.timeScale = 0;
            isPause = true;
            backgroundAdInfo.SetActive(true);
            textAd.text = 2.ToString();
            for (int i = 2; i >= 1; i--)
            {
                textAd.text = (i).ToString();
                yield return new WaitForSecondsRealtime(1);
            }
            
            YandexGame.FullscreenShow();
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            backgroundAdInfo.SetActive(false);
            backgroundAdClose.SetActive(true);
        }
    }
    
    public void UnPause()
    {
        isPause = false;
        Time.timeScale = 1;
        AudioListener.pause = false;

        if (!YandexGame.EnvironmentData.isMobile)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Rewarded(int id)
    {
        switch (id)
        {
            case 1:
                GameManager.Instance.AddCupsAds();
                break;
            
            case 2:
                GameManager.Instance.AddParamAds();
                break;
            
            case 3:
                GameManager.Instance.speedCounter = 2;
                StartCoroutine(MinusSpeed());
                break;
            
            case 4:
                GameManager.Instance.cupsCounter = 2;
                StartCoroutine(MinusMoney());
                break;
        }
    }

    public GameObject errorText;

    public void RewardAd(int id)
    {
        if (!Input.anyKey || YandexGame.EnvironmentData.isMobile == true)
        {
            YandexGame.RewVideoShow(id);
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

    public IEnumerator MinusSpeed()
    {
        yield return new WaitForSeconds(60f);
        
        GameManager.Instance.speedCounter = 1;
    }
    
    public IEnumerator MinusMoney()
    {
        yield return new WaitForSeconds(60f);
        
        GameManager.Instance.cupsCounter = 1;
    }
}
