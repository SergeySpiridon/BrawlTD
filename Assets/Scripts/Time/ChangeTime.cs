using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour
{
    public Transform Rotate;
    public Animator up;
    public GameObject casinoWindow;
    private float speedTimeBattle = 360 / UIManager.timeBattle * 4f;
    private float speedTimeCasino = 360/ UIManager.timeCasino * 4f;
    private float x;
    private bool flagCas1;
    [SerializeField] private ButtonCas1 buttonCas1;
 //   ButtonCas1 buttonCas1 = new ButtonCas1();

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
        if (UIManager.timeBattle < 0 && UIManager.timeCasino >= -2)
        {
            if(!flagCas1)
            {
                //Тут мне нужно вызвать метод из класса кнопочки
                buttonCas1.GetComponent<ButtonCas1>().RandomBoost();
                flagCas1 = true;
            }
            casinoWindow.SetActive(true);
            //Debug.Log(UIManager.timeCasino);
            //КАСТЫЛЬ, НО Я НЕ ХОЧУ ВСЕ ПЕРЕДЕЛЫВАТЬ
            //тут нужно будет поставить счетчик раундов
            
            if (UIManager.timeCasino <= 1 && UIManager.timeCasino > -2)
                
                up.SetBool("NightStart", true);
        }
        else
        {
            //Включается и выключается канвас казиныча
            casinoWindow.SetActive(false);
            flagCas1 = false;
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
