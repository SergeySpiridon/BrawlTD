using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float _damage = 0.01f;
    public Image hpBarClient1;
    public Image hpBarClient2;
    public Collider2D colliderCrystal;
    [SerializeField] private GameObject Crystall1;
    [SerializeField] private GameObject Crystall2;
    [SerializeField] private GameObject effect1;
    [SerializeField] private GameObject effect2;
    void Awake()
    {
        effect1.SetActive(false);
        effect2.SetActive(false);
        hpBarClient1 = Crystall1.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<Image>();
        hpBarClient2 = Crystall2.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<Image>();
        colliderCrystal = gameObject.GetComponent<Collider2D>();
    }
    private void Start()
    {
        EventManager.DealDmgForCrystall += GetDmg;
    }

    private void GetDmg(float dmg, GameObject crystall)
    {
        if (crystall.Equals(Crystall1))
        {
            Debug.Log(1);
            hpBarClient1.fillAmount -= dmg;
        }

        else
        {
            hpBarClient2.fillAmount -= dmg;
            StartCoroutine(ParitclesOn());
            if(hpBarClient2.fillAmount == 0)
            {
                Debug.Log("You Win!");
                Destroy(Crystall2);
                OffEvent();
            }
        }

    }
    private void OffEvent()
    {
        EventManager.DealDmgForCrystall -= GetDmg;
    }
    private IEnumerator ParitclesOn()
    {
        effect2.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        effect2.SetActive(false);
    }

}
