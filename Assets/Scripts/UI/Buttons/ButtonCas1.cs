using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonCas1 : MonoBehaviour
{
    private List<Action> powerUp = new List<Action>();
    [SerializeField] private Button button;
    [Header("Sprites")]
    public Sprite spriteUpDmg;
    public Sprite spriteUpHelath;
    public Sprite spriteUpSpeedAtack;

    private void Start()
    {
        Debug.Log(spriteUpDmg);
        Debug.Log(spriteUpHelath);
        Debug.Log(spriteUpSpeedAtack);
    }

    public void RandomBoost()
    {
        //Должна кнопочка принимать спрайт выпавшего усиления.
        AddList();
        var methodRND = powerUp[Random.Range(0, powerUp.Count)];
        methodRND.Invoke();
        powerUp.Clear();

    }

    private void UpDmg()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpDmg;
    }
    private void UpHealth()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpHelath;
    }
    private void UpSpeedAtack()
    {
        button.GetComponent<Image>().overrideSprite = spriteUpSpeedAtack;
    }
    private void AddList()
    {
        powerUp.Add(UpDmg);
        powerUp.Add(UpHealth);
        powerUp.Add(UpSpeedAtack);
    }

}
