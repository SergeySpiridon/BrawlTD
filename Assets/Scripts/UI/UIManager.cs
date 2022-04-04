using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textTime;
    public static float timeBattle = 90;
    public static float timeCasino = 20;
    public float timeSaveBattle;
    public float timeSaveCasino;
    public int minute;
    public float second;
    public static bool flag { get; private set; }
    public static bool flagCourutine { get; private set; }

    private enum Condition : int
    {
        flagTextTimeBattle,
        flaTimeWait,
        flagTimeCasino
    }

    public void Start()
    {
        timeSaveBattle = timeBattle;
        timeSaveCasino = timeCasino;
        flag = true;
        flagCourutine = false;
        StartCoroutine(TextTimeWait());
    }

    public IEnumerator TextTimeBattle()
    {
        while (!flag)
        {
            textTime.color = new Color(255, 92, 0);
            if (timeBattle > 59)
            {
                minute = (int)timeBattle / 60;
                second = timeBattle % 60;
                textTime.text = minute.ToString() + ":" + second.ToString();
            }
            else
            {
                textTime.text = timeBattle.ToString();
            }
            timeBattle--;

            if (timeBattle <= 0 && !flagCourutine)
            {
                StopCoroutine(TextTimeBattle());
                StartCoroutine(TextTimeWait());
                flagCourutine = true;
            }
                
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator TextTimeWait()
    {
        yield return new WaitForSeconds(2f);
        if (!flag)
        {
            flag = true;
            timeCasino = timeSaveCasino;
            StartCoroutine(TextTimeCasino());
            
        }
        else if(flag)
        {
            Debug.Log("Battle");
            flag = false;
            timeBattle = timeSaveBattle;
            StartCoroutine(TextTimeBattle());
            
        }
        flagCourutine = false;
        Debug.Log(flag);
    }
    public IEnumerator TextTimeCasino()
    {
        while (flag)
        {
            textTime.color = Color.blue;
            textTime.text = timeCasino.ToString();
            timeCasino--;
            if(timeCasino <= 0 && !flagCourutine)
            {
                flagCourutine = true;
                StopCoroutine(TextTimeCasino());
                StartCoroutine(TextTimeWait());
            }
            yield return new WaitForSeconds(1f);

        }
    }

}