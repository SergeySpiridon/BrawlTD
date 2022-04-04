using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour
{
    public Transform Rotate;
    public Animator up;
    public GameObject casinoWindow;
    private float speedTimeBattle = 360 / UIManager.timeBattle * 7f;
    private float speedTimeCasino = 360/ UIManager.timeCasino * 7f;
    private float x;

    private void Start()
    {
        StartCoroutine(RotationQuaternions());

    }
    void FixedUpdate()
    {
        CasinoOpen();
        // Debug.Log(speedTime);

    }
    //
    private void CasinoOpen()
    {
        if (UIManager.timeBattle < 0 && UIManager.timeCasino > 0)
        {
            casinoWindow.SetActive(true);
            if (UIManager.timeCasino < 3)
                up.SetBool("NightStart", true);
        }
        else
        {
            casinoWindow.SetActive(false);
        }
    }

    public IEnumerator RotationQuaternions()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (!UIManager.flag)
                x += Time.deltaTime * speedTimeBattle;

            else
                x -= Time.deltaTime * speedTimeCasino;
            transform.rotation = Quaternion.Euler(x, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
