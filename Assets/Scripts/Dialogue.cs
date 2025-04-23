using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueObj;
    public TextMeshProUGUI dialogueTextMeshProUGUI;
    public string[] dialogues;
    public int dialogueWait;
    public int offWait;

    private void Start()
    {
        StartCoroutine(DialogueRoutine());
    }

    private string currentDialogue;

    private IEnumerator DialogueRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            dialogueObj.SetActive(true);
            currentDialogue = dialogues[Random.Range(0, dialogues.Length)];
            if (currentDialogue == "Эй, привет!  Если ты заработаешь 50000 рекорда, я подарю тебе крутой особняк на крыше дома!")
            {
                dialogueTextMeshProUGUI.text = TranslateMagnat0();
            }
            else if (currentDialogue == "Хочешь чтобы я подарил тебе крутой особняк за 999,999$? Тогда набери 50 000 очков рекорда!")
            {
                dialogueTextMeshProUGUI.text = TranslateMagnat1();
            }
            else if (currentDialogue == "Я очень богат и у меня много особняков, я подарю один тебе если ты наберешь 50 000 рекорда!")
            {
                dialogueTextMeshProUGUI.text = TranslateMagnat2();
            }
            else if (currentDialogue == "Если бы ты знал насколько я богат. Хмм, давай я подарю тебе один из своих особняков, набери 50 000 рекорда!")
            {
                dialogueTextMeshProUGUI.text = TranslateMagnat3();
            }
            else if (currentDialogue == "Особняк на крыше за 999,999$ что может быть лучше? Эй, ты, я подарю его тебе когда наберешь 50 000 рекорда!")
            {
                dialogueTextMeshProUGUI.text = TranslateMagnat4();
            }
            else if (currentDialogue == "Привет, путник! Ты уже играл в другие наши игры? Обязательно сыграй, жми на кнопку справа от меня!")
            {
                dialogueTextMeshProUGUI.text = TranslateOtherGames0();
            }
            else if (currentDialogue == "Видел сколько ещё крутых игр есть? Скорее жми на кнопку и начинай играть!")
            {
                dialogueTextMeshProUGUI.text = TranslateOtherGames1();
            }
            else if (currentDialogue == "Привет! Я вижу тебе понравилось играть в обби! Хочешь ещё? Жми на кнопку и исследуй лучшие игры!")
            {
                dialogueTextMeshProUGUI.text = TranslateOtherGames2();
            }
            else if (currentDialogue == "Ты знаешь сколько у нас есть ещё крутых игр? Исследуй их все, жми на кнопку справа от меня!")
            {
                dialogueTextMeshProUGUI.text = TranslateOtherGames3();
            }
            else if (currentDialogue == "Я смотрю ты профессионал, испытаешь себя в других играх? Жми на кнопку справа! ")
            {
                dialogueTextMeshProUGUI.text = TranslateOtherGames4();
            }
            else if (currentDialogue == "Йо-хо-хо. Похоже я перепутал миры. Не знаю как я тут оказался...")
            {
                dialogueTextMeshProUGUI.text = TranslatePirate0();
            }
            else if (currentDialogue == "Я ведь из игры про обби-лаву, у меня там свой пиратский корабль, не заглянешь туда?")
            {
                dialogueTextMeshProUGUI.text = TranslatePirate1();
            }
            else if (currentDialogue == "Смотрю ты большой профессионал, там какой-то магнат остров дарит, испытай удачу!")
            {
                dialogueTextMeshProUGUI.text = TranslatePirate2();
            }
            else if (currentDialogue == "Я с радостью смотри как ты строишь этот небоскреб, удачи тебе!")
            {
                dialogueTextMeshProUGUI.text = TranslatePirate3();
            }
            else if (currentDialogue == "Кого я вижу! Это же мой старый друг, как твои дела?")
            {
                dialogueTextMeshProUGUI.text = TranslatePirate4();
            }
            else if (currentDialogue == "Эй, я буду самым крутым про на этом сервере!")
            {
                dialogueTextMeshProUGUI.text = TranslatePro0();
            }
            else if (currentDialogue == "Считаешь что ты лучший? Ладно ты прав, похоже ты профессионал!")
            {
                dialogueTextMeshProUGUI.text = TranslatePro1();
            }
            else if (currentDialogue == "Я побью твой рекорд и построю самый лучший небоскреб!")
            {
                dialogueTextMeshProUGUI.text = TranslatePro2();
            }
            else if (currentDialogue == "Сегодня смотрел список лидеров, я всё равно рано или поздно стану круче чем ты!")
            {
                dialogueTextMeshProUGUI.text = TranslatePro3();
            }
            else if (currentDialogue == "Я открыл уже почти всех петов! А ты так можешь?")
            {
                dialogueTextMeshProUGUI.text = TranslatePro4();
            }
            else
            {
                Debug.Log("не перевел");
                dialogueTextMeshProUGUI.text = currentDialogue;
            }
            yield return new WaitForSeconds(dialogueWait+ Random.Range(1, 6));
            dialogueObj.SetActive(false);
            yield return new WaitForSeconds(offWait + Random.Range(1, 10));
        }
    }

    private string TranslateMagnat0()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Эй, привет!  Если ты заработаешь 50000 рекорда, я подарю тебе крутой особняк на крыше дома!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Hey, merhaba! Eğer 50.000 kayıt kazanırsan, sana havalı bir çatı katı hediye edeceğim!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Эй, прывітанне! Калі ты зарабіш 50 000 запісаў, я падару табе класны пентхаус!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Эй, сәлем! Егер сен 50 000 жазба жинасаң, мен саған керемет шатырлы үй сыйлаймын!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Эй, салом! Агар сен 50,000 рекорд тўпласанг, мен сенга кулл пентхаус ҳадя қиламан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Hey, hola! ¡Si ganas 50,000 registros, te regalaré un ático genial!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Hey, hallo! Wenn du 50.000 Rekorde erzielst, schenke ich dir ein tolles Penthouse!";
        }
        else
        {
            return "Hey, hi! If you earn 50,000 records, I'll give you a cool penthouse!";
        }
    }

    private string TranslateMagnat1()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Хочешь чтобы я подарил тебе крутой особняк за 999,999$? Тогда набери 50 000 очков рекорда!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Sana 999.999$ değerinde havalı bir malikane vermemi ister misin? O zaman 50.000 puan topla!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Хочаш, каб я падарыў табе класны асабняк за 999,999$? Тады набяры 50 000 ачкоў!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Саған 999,999$ тұратын керемет үй сыйлағанымды қалайсың ба? Онда 50 000 ұпай жина!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Сенга 999,999$ лик кулл сарой ҳадя қилишимни истайсанми? Унда 50,000 очко тўпла!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¿Quieres que te regale una mansión genial por $999,999? ¡Entonces consigue 50,000 puntos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Möchtest du, dass ich dir eine coole Villa für 999.999$ schenke? Dann erreiche 50.000 Punkte!";
        }
        else
        {
            return "Do you want me to give you a cool mansion for $999,999? Then score 50,000 points!";
        }
    }

    private string TranslateMagnat2()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я очень богат и у меня много особняков, я подарю один тебе если ты наберешь 50 000 рекорда!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Ben çok zenginim ve birçok malikanem var, 50.000 puan alırsan sana bir tane vereceğim!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я вельмі багаты і ў мяне шмат асабнякоў, я падару адзін табе, калі ты набярэш 50 000 ачкоў!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Мен өте баймын және көптеген үйлерім бар, егер сен 50 000 ұпай жинасаң, мен саған біреуін беремін!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен жуда бойман ва кўплаб саройларим бор, агар сен 50,000 очко тўпласанг, биттасини сенга ҳадя қиламан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Soy muy rico y tengo muchas mansiones, ¡te regalaré una si consigues 50,000 puntos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich bin sehr reich und habe viele Villen, ich werde dir eine schenken, wenn du 50.000 Punkte erreichst!";
        }
        else
        {
            return "I am very rich and I have many mansions, I will give you one if you score 50,000 points!";
        }
    }

    private string TranslateMagnat3()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Если бы ты знал насколько я богат. Хмм, давай я подарю тебе один из своих особняков, набери 50 000 рекорда!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Ne kadar zengin olduğumu bilsen. Hmm, sana malikanemden birini vereyim, 50.000 puan al!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Каб ты ведаў, наколькі я багаты. Хмм, давай я падару табе адзін з маіх асабнякоў, набяры 50 000 ачкоў!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Менің қаншалықты бай екенімді білсең ғой. Хмм, мен саған бір үйімді берейін, 50 000 ұпай жина!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен қанчалик бой эканлигимни билсанг. Ҳмм, мен сенга саройларимдан бирини ҳадя қиламан, 50,000 очко тўпла!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Si supieras lo rico que soy. Hmm, déjame darte una de mis mansiones, ¡consigue 50,000 puntos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Wenn du wüsstest, wie reich ich bin. Hm, lass mich dir eine meiner Villen schenken, erreiche 50.000 Punkte!";
        }
        else
        {
            return "If you knew how rich I am. Hmm, let me give you one of my mansions, score 50,000 points!";
        }
    }

    private string TranslateMagnat4()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Особняк на крыше за 999,999$ что может быть лучше? Эй, ты, я подарю его тебе когда наберешь 50 000 рекорда!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "999.999$'a çatı katı, bundan daha iyi ne olabilir? Hey, sen, 50.000 puan aldığında sana vereceğim!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Пентхаус за 999,999$, што можа быць лепш? Эй, ты, я падару яго табе, калі ты набярэш 50 000 ачкоў!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "999,999$ тұратын шатырдағы үй, одан жақсы не болуы мүмкін? Эй, сен, 50 000 ұпай жинағанда саған оны беремін!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "999,999$лик пентхаус, бундан яхшироқ нима бўлиши мумкин? Эй, сен, 50,000 очко тўплаганингда, уни сенга ҳадя қиламан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¿Un ático por $999,999, qué podría ser mejor? ¡Hey, tú, te lo daré cuando consigas 50,000 puntos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ein Penthouse für 999.999$, was könnte besser sein? Hey, du, ich gebe es dir, wenn du 50.000 Punkte erreichst!";
        }
        else
        {
            return "A penthouse for $999,999, what could be better? Hey, you, I'll give it to you when you score 50,000 points!";
        }
    }

    private string TranslateOtherGames0()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Привет, путник! Ты уже играл в другие наши игры? Обязательно сыграй, жми на кнопку справа от меня!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Merhaba, yolcu! Diğer oyunlarımızı oynadın mı? Mutlaka oyna, sağımda bulunan düğmeye tıkla!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Прывітанне, падарожнік! Ты ўжо гуляў у іншыя нашы гульні? Абавязкова згуляй, націсні на кнопку справа ад мяне!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Сәлем, жолаушы! Біздің басқа ойындарымызды ойнап көрдің бе? Міндетті түрде ойна, менің оң жағымдағы түймені бас!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Салом, сайёҳ! Бошқа ўйинларимизни ўйнаганмисан? Албатта ўйна, менинг ўнгимдаги тугмани бос!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Hola, viajero! ¿Ya has jugado nuestros otros juegos? ¡Asegúrate de jugar, haz clic en el botón a mi derecha!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Hallo, Reisender! Hast du schon unsere anderen Spiele gespielt? Spiele sie unbedingt, klicke auf den Knopf rechts von mir!";
        }
        else
        {
            return "Hello, traveler! Have you already played our other games? Be sure to play, click the button to my right!";
        }
    }

    private string TranslateOtherGames1()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Видел сколько ещё крутых игр есть? Скорее жми на кнопку и начинай играть!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Ne kadar havalı oyunlar olduğunu gördün mü? Hemen düğmeye tıkla ve oynamaya başla!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Бачыў, колькі яшчэ класных гульняў ёсць? Хутчэй націскай на кнопку і пачынай гуляць!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Қаншама керемет ойындар бар екенін көрдің бе? Тезірек түймені басып, ойнауды баста!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Қанча кулл ўйинлар борлигини кўрдингми? Тезроқ тугмани бос ва ўйинни бошла!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¿Has visto cuántos juegos geniales hay? ¡Rápido, haz clic en el botón y empieza a jugar!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Hast du gesehen, wie viele coole Spiele es gibt? Schnell, klicke auf den Knopf und fang an zu spielen!";
        }
        else
        {
            return "Have you seen how many cool games there are? Quickly, click the button and start playing!";
        }
    }

    private string TranslateOtherGames2()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Привет! Я вижу тебе понравилось играть в обби! Хочешь ещё? Жми на кнопку и исследуй лучшие игры!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Merhaba! Obby oynamayı sevdiğini görüyorum! Daha fazla ister misin? Düğmeye tıkla ve en iyi oyunları keşfet!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Прывітанне! Я бачу, табе спадабалася гуляць у Obby! Хочаш яшчэ? Націскай на кнопку і даследуй лепшыя гульні!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Сәлем! Obby ойынын ұнатқаныңды көріп тұрмын! Тағы қалайсың ба? Түймені басып, ең жақсы ойындарды зертте!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Салом! Obby ўйинини ёқтирганингни кўряпман! Яна ўйнашни истайсанми? Тугмани бос ва энг яхши ўйинларни ўйна!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Hola! Veo que disfrutaste jugando Obby. ¿Quieres más? ¡Haz clic en el botón y explora los mejores juegos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Hallo! Ich sehe, dass dir das Spielen von Obby gefallen hat! Möchtest du mehr? Klicke auf den Knopf und entdecke die besten Spiele!";
        }
        else
        {
            return "Hi! I see you enjoyed playing Obby! Want more? Click the button and explore the best games!";
        }
    }

    private string TranslateOtherGames3()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Ты знаешь сколько у нас есть ещё крутых игр? Исследуй их все, жми на кнопку справа от меня!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Ne kadar havalı oyunlarımız olduğunu biliyor musun? Hepsini keşfet, sağımda bulunan düğmeye tıkla!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Ты ведаеш, колькі ў нас яшчэ класных гульняў? Даследуй іх усе, націскай на кнопку справа ад мяне!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Бізде қаншама керемет ойын бар екенін білесің бе? Олардың барлығын зертте, менің оң жағымдағы түймені бас!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Бизда қанча кулл ўйинлар борлигини биласанми? Улардан барчасини ўрган, ўнгимдаги тугмани бос!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¿Sabes cuántos juegos geniales tenemos? ¡Explóralos todos, haz clic en el botón a mi derecha!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Weißt du, wie viele coole Spiele wir haben? Erkunde sie alle, klicke auf den Knopf rechts von mir!";
        }
        else
        {
            return "Do you know how many cool games we have? Explore them all, click the button to my right!";
        }
    }

    private string TranslateOtherGames4()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я смотрю ты профессионал, испытаешь себя в других играх? Жми на кнопку справа! ";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Profesyonel olduğunu görüyorum, diğer oyunlarda kendini deneyecek misin? Sağdaki düğmeye tıkla!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я бачу, ты прафесіянал, выпрабуеш сябе ў іншых гульнях? Націскай на кнопку справа!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Сенің кәсіби екеніңді көріп тұрмын, басқа ойындарда өзіңді сынап көресің бе? Оң жақтағы түймені бас!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Сенинг профессионал эканингни кўряпман, бошқа ўйинларда ўзингни синаб кўрасанми? Ўнг томондаги тугмани бос!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Veo que eres un profesional, ¿te probarás en otros juegos? ¡Haz clic en el botón a mi derecha!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich sehe, du bist ein Profi, wirst du dich in anderen Spielen testen? Klicke auf den Knopf rechts von mir!";
        }
        else
        {
            return "I see you are a professional, will you test yourself in other games? Click the button to my right!";
        }
    }

    private string TranslatePirate0()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Йо-хо-хо. Похоже я перепутал миры. Не знаю как я тут оказался...";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Yo-ho-ho. Görünüşe göre dünyaları karıştırdım. Burada nasıl olduğumu bilmiyorum...";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Йо-хо-хо. Здаецца, я пераблытаў свет. Не ведаю, як я тут апынуўся...";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Йо-хо-хо. Көрінеді, мен әлемдерді шатастырып алдым. Мұнда қалай тап болғанымды білмеймін...";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Йо-хо-хо. Ҳеч бўлмаганда мен дунёларни аралаштириб юбортдим. Қандай қилиб шу ерда эканимни билмайман...";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Yo-ho-ho. Parece que he confundido los mundos. No sé cómo he llegado aquí...";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Yo-ho-ho. Es scheint, ich habe die Welten durcheinandergebracht. Ich weiß nicht, wie ich hier gelandet bin...";
        }
        else
        {
            return "Yo-ho-ho. It seems I mixed up the worlds. I don’t know how I ended up here...";
        }
    }

    private string TranslatePirate1()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я ведь из игры про обби-лаву, у меня там свой пиратский корабль, не заглянешь туда?";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Ben Obby Lava oyunundanım, kendi korsan gemim var. Oraya göz atar mısın?";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я з гульні Obby Lava, дзе ў мяне ёсць свой піратскі карабель. Не зайдзеш туды?";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Мен Obby Lava ойынынанмын, онда менің өз пират кемем бар. Оған көз жүгіртесің бе?";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен Obby Lava ўйиниданман, у ерда менда ўзимнинг пират кемам бор. Унга назар соласизми?";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Soy de la partida de Obby Lava, donde tengo mi propio barco pirata. ¿Lo vas a revisar?";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich komme aus dem Spiel Obby Lava, wo ich mein eigenes Piratenschiff habe. Willst du es dir ansehen?";
        }
        else
        {
            return "I’m from the Obby Lava game, where I have my own pirate ship. Will you check it out?";
        }
    }

    private string TranslatePirate2()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Смотрю ты большой профессионал, там какой-то магнат остров дарит, испытай удачу!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Büyük bir profesyonel olduğunu görüyorum, bir iş adamı bir ada hediye ediyor. Şansını dene!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я бачу, што ты вялікі прафесіянал, там нейкі магнат дорыць востраў. Паспрабуй сваю удачу!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Сен үлкен кәсіби маман екенсің, бір бай арал сыйлауда. Өз бақытыңды сына!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Сен катта профессионал экансан, у ерда бир бой кишининг орол ҳадя қилгани айтилмоқда. Омадингни сина!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Veo que eres un gran profesional, hay un magnate que está regalando una isla. ¡Prueba tu suerte!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich sehe, dass du ein großer Profi bist. Da gibt es einen Magnaten, der eine Insel verschenkt. Versuch dein Glück!";
        }
        else
        {
            return "I see you’re a big professional, there’s a tycoon giving away an island. Try your luck!";
        }
    }

    private string TranslatePirate3()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я с радостью смотри как ты строишь этот небоскреб, удачи тебе!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Bu gökdeleni inşa edişini görmek için sabırsızlanıyorum. Bol şans!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я з радасцю гляджу, як ты будуеш гэты хмарачос. Поспехаў!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Мен осы зәулім үйді қалай салып жатқаныңды көріп қуаныштымын. Сәттілік тілеймін!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен бу осмонўи бинани қандай қуришингизни кўриб хурсандман. Омадингни сина!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Estoy emocionado de ver cómo construyes este rascacielos. ¡Buena suerte!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich freue mich, zu sehen, wie du dieses Hochhaus baust. Viel Glück!";
        }
        else
        {
            return "I’m excited to see you build this skyscraper. Good luck!";
        }
    }

    private string TranslatePirate4()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Кого я вижу! Это же мой старый друг, как твои дела?";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Kimleri görüyorum! Eski arkadaşım, nasılsın?";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Кога я бачу! Гэта ж мой стары сябар, як твае справы?";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Кімді көріп тұрмын! Бұл менің ескі досым, қалайсың?";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Кимни кўряпман! Бу менинг eski дўстим, қандайсиз?";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Quién veo! ¡Es mi viejo amigo, cómo estás?";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Wen sehe ich da! Mein alter Freund, wie geht es dir?";
        }
        else
        {
            return "Who do I see! It’s my old friend, how are you?";
        }
    }

    private string TranslatePro0()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Эй, я буду самым крутым про на этом сервере!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Hey, bu sunucuda en havalı profesyonel ben olacağım!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Эй, я буду самым крутым прафесіяналам на гэтым серверы!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Эй, мен осы серверде ең керемет кәсіби ойыншы боламын!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Эй, мен бу серверда энг кулл профессионал бўламан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Eh, voy a ser el profesional más genial en este servidor!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Hey, ich werde der coolste Profi auf diesem Server sein!";
        }
        else
        {
            return "Hey, I’m going to be the coolest pro on this server!";
        }
    }

    private string TranslatePro1()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Считаешь что ты лучший? Ладно ты прав, похоже ты профессионал!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "En iyisi olduğunu mu düşünüyorsun? Tamam, haklısın, profesyonel gibi görünüyor!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Лічыш, што ты лепшы? Добра, ты правы, выглядае, што ты прафесіянал!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Ең үздік екеніңді ойлайсың ба? Жақсы, дұрыс айтасың, сен кәсіби маман сияқтысың!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Энг яхши эканингни ўйлайсанми? Ҳамма ишлар яхши, сен профессионал каби кўринасан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¿Crees que eres el mejor? Está bien, tienes razón, ¡parece que eres un profesional!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Glaubst du, dass du der Beste bist? Na gut, du hast recht, es sieht so aus, als wärst du ein Profi!";
        }
        else
        {
            return "Think you’re the best? Alright, you’re right, it looks like you’re a professional!";
        }
    }

    private string TranslatePro2()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я побью твой рекорд и построю самый лучший небоскреб!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Rekorunu kıracağım ve en iyi gökdeleni inşa edeceğim!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я паб'ю твой рэкорд і пабудую найлепшы хмарачос!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Мен сенің рекордыңды жаңартамын және ең жақсы зәулім үйді саламын!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен сенинг рекордингни бузаман ва энг яхши осмонўи бинани қураман!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡Voy a romper tu récord y construir el mejor rascacielos!";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich werde deinen Rekord brechen und das beste Hochhaus bauen!";
        }
        else
        {
            return "I’m going to break your record and build the best skyscraper!";
        }
    }

    private string TranslatePro3()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Сегодня смотрел список лидеров, я всё равно рано или поздно стану круче чем ты!";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Bugün liderler listesini kontrol ettim ve er ya da geç senden daha iyi olacağım!";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Сёння я паглядзеў спіс лідараў, і рана ці позна я стану лепшым за цябе!";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Бүгін көшбасшылар тізімін қарадым, және ерте ме, кеш пе, мен сенен жақсырақ боламын!";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Бугун лидерлар рўйхатини кўрдим ва кеч бўлса ҳам, сендан яхшироқ бўламан!";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "Hoy revisé la lista de líderes y, tarde o temprano, seré mejor que tú.";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich habe heute die Bestenliste angesehen, und früher oder später werde ich besser sein als du!";
        }
        else
        {
            return "I checked the leaderboard today, and sooner or later, I’ll be better than you!";
        }
    }

    private string TranslatePro4()
    {
        if (YandexGame.savesData.language == "ru" | YandexGame.savesData.language == "uk")
        {
            return "Я открыл уже почти всех петов! А ты так можешь?";
        }
        else if (YandexGame.savesData.language == "tr")
        {
            return "Neredeyse tüm evcil hayvanları açtım! Sen bunu yapabilir misin?";
        }
        else if (YandexGame.savesData.language == "be")
        {
            return "Я адкрыў амаль усіх хатніх жывёл! А ты можаш гэта зрабіць?";
        }
        else if (YandexGame.savesData.language == "kk")
        {
            return "Мен дерлік барлық питомцтарды аштым! Сен бұны жасай аласың ба?";
        }
        else if (YandexGame.savesData.language == "uz")
        {
            return "Мен деярли барча пухликларни очдим! Сен ҳам шундай қила оласанми?";
        }
        else if (YandexGame.savesData.language == "es")
        {
            return "¡He desbloqueado casi todas las mascotas! ¿Puedes hacer eso?";
        }
        else if (YandexGame.savesData.language == "de")
        {
            return "Ich habe bereits fast alle Haustiere freigeschaltet! Kannst du das auch?";
        }
        else
        {
            return "I’ve unlocked almost all the pets! Can you do that?";
        }
    }
}
