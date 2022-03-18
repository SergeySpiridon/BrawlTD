using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafsDestroy : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -11)
            Destroy(gameObject);
    }
}
