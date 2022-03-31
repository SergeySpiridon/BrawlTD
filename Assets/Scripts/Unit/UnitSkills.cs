using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSkills : MonoBehaviour
{
    
    [SerializeField]public static List<GameObject> Enemy = new List<GameObject>();
    private GameObject enemyObject;

    public float Health;
    public float Damage;
    public float Range;
    public float SpeedAttack;
    public float Cost;
    public static float costEnemy;
    private float time;

    private bool flagDeath = false;



    public void Start()
    {
        InvokeRepeating("DealDmg", 0, SpeedAttack);
    }
    public void FixedUpdate()
    {
        SearchAim();
        
        Die();
    }
    public void SearchAim()
    {
        //Для клиента на 1 спавне
        if (Enemy.Count > 0)
        {
            if (gameObject.layer == 7)
                for (int i = 0; i < Enemy.Count; i++)
                {

                    if (Enemy[i].layer == 6 && Vector2.Distance(gameObject.transform.position, Enemy[i].transform.position) < Range)
                    {
                        GetComponent<MoveLeafs>().Speed = 0;
                        Debug.Log(Enemy[i].transform.position);
                        enemyObject = Enemy[i];
                        gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(false, SpeedAttack);

                    }
                    else
                    {
                        gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(true, SpeedAttack);
                        GetComponent<MoveLeafs>().Speed = 3;
                    }
                    
                }
            //для клиента на 2 спавне
            else if (gameObject.layer == 6)
                for (int i = 0; i < Enemy.Count; i++)
                {
                    if (Enemy[i].layer == 7 && Vector2.Distance(gameObject.transform.position, Enemy[i].transform.position) < Range)
                    {
                        GetComponent<MoveLeafs>().Speed = 0;
                        enemyObject = Enemy[i];
                        gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(false, SpeedAttack);

                    }
                    else
                    {
                        gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(true, SpeedAttack);
                        GetComponent<MoveLeafs>().Speed = 3;
                    }

                }
        }
        else
            gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(true, SpeedAttack);
    }
    private void Die()
    {
        if (Health <= 0)
        {
         //   flagDeath = true;
            costEnemy = enemyObject.GetComponent<UnitSkills>().Cost / 71;
            GetComponent<MoveLeafs>().Speed = 0;
            EventManager.EnemyDie();
            Enemy.Remove(enemyObject);  
            StartCoroutine(PlayDeath());
            flagDeath = true;
        }
    }
    public void DealDmg()
    {

        StartCoroutine(StartDamage());

    }
    public IEnumerator StartDamage()
    {

        yield return new WaitForSeconds(SpeedAttack);
        if (!flagDeath)
            enemyObject.GetComponent<UnitSkills>().Health -= Damage;
    }
    public IEnumerator PlayDeath()
    {
        gameObject.GetComponent<UnitAminmations>().PlayAnimationDeath(Health);
       
        yield return new WaitForSeconds(3f);
     //   Enemy.Remove(enemyObject);
        
        Destroy(gameObject);
    }
}
