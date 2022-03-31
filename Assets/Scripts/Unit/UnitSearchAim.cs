using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSearchAim : MonoBehaviour
{
   // [SerializeField] private LayerMask enemy = new LayerMask();
    [SerializeField] private GameObject gameobj;
    UnitAminmations unitAminmationsp;
    public Animator animator;
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    private void CheckDistance()
    {
       
        if (gameobj.layer == 6 && Vector2.Distance(transform.position, gameobj.transform.position) <1.4f)
        {
            Debug.Log(Vector2.Distance(transform.position, gameobj.transform.position));
            // animator.SetBool("OrkWalk", false);
            gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(false);
            gameObject.GetComponent<MoveLeafs>().Speed = 0;
        }
        else
            gameObject.GetComponent<UnitAminmations>().PlayAnimationAttack(true);
        
            
    }
}
