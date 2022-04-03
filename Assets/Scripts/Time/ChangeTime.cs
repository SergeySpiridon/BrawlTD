using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour
{
    public Transform Rotate;
    public Animator up;
    public GameObject casinoWindow;
    private float timeBattle = 90;
    private bool flag = false;
    private float x;
    private void Start()
    {
        StartCoroutine(RotationXFromTimeBattle());
     //   up = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        CasinoOpen();
        
    }
    //
    private void CasinoOpen()
    {
        if (UIManager.timeBattle < 0 && UIManager.timeCasino > 0)
        {
            casinoWindow.SetActive(true);
            if(UIManager.timeCasino < 3)
                up.SetBool("NightStart", true);
        }
        else
        {   
            casinoWindow.SetActive(false);
        }
    }
    //private IEnumerator AnimationUp()
    //{
    //    yield return new WaitForSeconds(up.cli);
    //}
    //ƒневное врем€(дл€ битвы)
    private IEnumerator RotationXFromTimeBattle()
    {
        if (!flag)
        {
            timeBattle = UIManager.timeBattle;
            flag = true;
        }
        while (UIManager.timeBattle > 0)
        {
            x += Time.deltaTime * (100/timeBattle*15f);
            transform.rotation = Quaternion.Euler(x, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator RotationXFromTimeCasino()
    {
        if (!flag)
        {
            timeBattle = UIManager.timeBattle;
            flag = true;
        }
        while (UIManager.timeBattle > 0)
        {
            x += Time.deltaTime * (100 / timeBattle * 15f);
            transform.rotation = Quaternion.Euler(x, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
