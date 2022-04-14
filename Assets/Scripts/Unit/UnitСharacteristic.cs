using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit—haracteristic : MonoBehaviour
{

    public static List<GameObject> Enemy = new List<GameObject>();
    public GameObject Unit;
    public GameObject UnitEnemy;
    //  public GameObject Unit;
    public Collider2D collUnit;
    public Animator anim;
   // public GameObject crystalEnemyHp;
    [SerializeField]private GameObject CrystalEnemy;
    private Collider2D colliderCrystalEnemy;

    public float Health;
    public float Damage;
    public float Range;
    public float SpeedAttack;
    public float Cost;
    private float time;
    public static float costEnemy;
    private bool flag = false;

    public void Start()
    {

        collUnit = GetComponent<Collider2D>();
        colliderCrystalEnemy = CrystalEnemy.GetComponent<Collider2D>();

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
        if (Vector2.Distance(collUnit.transform.position, colliderCrystalEnemy.transform.position) <= Range)
        {
            flag = false;
            gameObject.GetComponent<MoveLeafs>().Speed = 0f;
            gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(false, SpeedAttack);
        }
        else
        {
            flag = true;
            foreach (var unitEnemy in Enemy)
            {
                //   Debug.Log(unitEnemy);
                if (unitEnemy == null)
                {
                    EventManager.EnemyDie();
                    // Debug.Log(costEnemy);
                    Enemy.Remove(unitEnemy);


                }


                if (Vector2.Distance(collUnit.transform.position, unitEnemy.GetComponent<Collider2D>().transform.position) <= Range)
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
    }
    public void DealDmg()
    {
        if (flag)
            UnitEnemy.GetComponent<Unit—haracteristic>().Health -= Damage;
        //
        //
        //
        else
        {      
            var _dmg = Damage * 0.001f;
            EventManager.DealDmg(_dmg, CrystalEnemy);
        }
       

    }

    public void CheckHealth()
    {
        Destroy(gameObject);
    }
    public void DieForNight()
    {
        Health = 0;
        Enemy.Clear();
    }
    public void DestroyColl()
    {
        collUnit.enabled = false;

    }

}
