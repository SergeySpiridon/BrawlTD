using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit—haracteristic : MonoBehaviour
{

    public static List<GameObject> Enemy = new List<GameObject>();
    public GameObject Unit;
    public GameObject UnitEnemy;
    //  public GameObject Unit;
    public Collider2D collUnit;
    public Animator anim;


    public float Health;
    public float Damage;
    public float Range;
    public float SpeedAttack;
    public float Cost;
    private float time;
    public static float costEnemy;
    private bool flagDeath = false;

    public void Start()
    {
        collUnit = GetComponent<Collider2D>();
        EventManager.StartNight += DieForNight;
    }
    void FixedUpdate()
    {
        CheckDistance();
        if (Health <= 0)
        {
            gameObject.GetComponent<UnitAminmations>().PlayAnimationDeath(Health);
            gameObject.GetComponent<MoveLeafs>().Speed = 0f;
        }
    }
    public void CheckDistance()
    {
        foreach (var unitEnemy in Enemy)
        {
         //   Debug.Log(unitEnemy);
            if (unitEnemy == null)
            {
                EventManager.EnemyDie();
               // Debug.Log(costEnemy);
                Enemy.Remove(unitEnemy);
               

            }
                

            if (Vector2.Distance(collUnit.transform.position, unitEnemy.GetComponent<Collider2D>().transform.position) < Range)
            {
            //    Debug.Log(1);
                UnitEnemy = unitEnemy;
                gameObject.GetComponent<MoveLeafs>().Speed = 0f;
                gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(false, SpeedAttack);
                costEnemy = UnitEnemy.GetComponent<Unit—haracteristic>().Cost;
            }
            else
                gameObject.GetComponent<MoveLeafs>().Speed = 6f;

        }
        if (Enemy.Count == 0)
        {
            gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(true, SpeedAttack);
            gameObject.GetComponent<MoveLeafs>().Speed = 6f;
        }
    }
    public void DealDmg()
    {
        try
        {
            UnitEnemy.GetComponent<Unit—haracteristic>().Health -= Damage;
        }
        catch
        {

        }

    }

    public void CheckHealth()
    {
        Destroy(gameObject);
    }
    public void DieForNight()
    {
        Debug.Log(222);
        Health = 0;
        Enemy.Clear();
    }
    public void DestroyColl()
    {
        collUnit.enabled = false;

    }

}
