using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    public Vector3 Rotate;
    public float speed;
    private Quaternion StartRotation;

    void Update()
    {
        transform.Rotate(Rotate * speed * Time.deltaTime);
    }

}
