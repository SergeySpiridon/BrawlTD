using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafsDestroy : MonoBehaviour
{
    public float postionDestroy;
    void Update()
    {
        
        if (transform.position.x < postionDestroy)
            Destroy(gameObject);
    }
}
