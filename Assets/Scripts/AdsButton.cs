using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AdsButton : MonoBehaviour
{
    public Button adButton;
    public TextMeshProUGUI timerText;

    public float cooldownTime = 120f;
    public string text;

    void Start()
    {
        if (text == "+1 этаж")
        {
            timerText.text = Translate();
        }
        else if (text == "+1 скорость")
        {
            timerText.text = TranslateSpeed();
        }
        else if (text == "x2 монеты (1 минута)")
        {
            timerText.text = TranslateCoins();
        }
        else if (text == "x2 скорость (1 минута)")
        {
            timerText.text = TranslateSpeed2();
        }
        else
        {
            timerText.text = text;
        }
        // Прикрепляем функцию к событию нажатия кнопки
        adButton.onClick.AddListener(() => StartCoroutine(StartCooldown()));
    }

    IEnumerator StartCooldown()
    {
        if (!Input.anyKey || YandexGame.EnvironmentData.isMobile == true)
        {
            adButton.interactable = false;
            float timeLeft = cooldownTime;

            while (timeLeft > 0)
            {
                timerText.text = Mathf.Round(timeLeft).ToString();
                yield return new WaitForSeconds(1f);
                timeLeft--;
            }

            adButton.interactable = true;
            if (text == "+1 этаж")
            {
                timerText.text = Translate();
            }
            else if (text == "+1 скорость")
            {
                timerText.text = TranslateSpeed();
            }
            else if (text == "x2 монеты (1 минута)")
            {
                timerText.text = TranslateCoins();
            }
            else if (text == "x2 скорость (1 минута)")
            {
                timerText.text = TranslateSpeed2();
            }
            else
            {
                timerText.text = text;
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(TextError());
            }
        }
    }

    public GameObject errorText;

    IEnumerator TextError()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(3f);
        errorText.SetActive(false);
    }

    private string Translate()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "+1 этаж";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "+1 kat";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "+1 паверх";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "+1 қабат";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "+1 qavat";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "+1 piso";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "+1 Etage";
        }
        else
        {
            return "+1 floor";
        }
    }

    private string TranslateSpeed()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "+1 скорость";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "+1 hız";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "+1 хуткасць";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "+1 жылдамдық";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "+1 tezlik";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "+1 velocidad";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "+1 Geschwindigkeit";
        }
        else
        {
            return "+1 speed";
        }
    }

    private string TranslateCoins()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "x2 монеты (1 минута)";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "x2 jeton (1 dakika)";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "x2 манеты (1 хвіліна)";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "x2 монета (1 минут)";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "x2 tanga (1 daqiqa)";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "x2 monedas (1 minuto)";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "x2 Münzen (1 Minute)";
        }
        else
        {
            return "x2 coins (1 minute)";
        }
    }

    private string TranslateSpeed2()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "x2 скорость (1 минута)";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "x2 hız (1 dakika)";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "x2 хуткасць (1 хвіліна)";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "x2 жылдамдығы (1 минут)";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "x2 tezlik (1 daqiqa)";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "velocidad x2 (1 minuto)";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "x2 Geschwindigkeit (1 Minute)";
        }
        else
        {
            return "x2 speed (1 minute)";
        }
    }
}
