using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIndentity : MonoBehaviour
{
    public Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
