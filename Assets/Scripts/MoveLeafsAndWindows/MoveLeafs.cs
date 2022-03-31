using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeafs : MonoBehaviour
{

    public float Speed = 3;
    public Vector2 dir;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir*Time.deltaTime*Speed);
    }
}
