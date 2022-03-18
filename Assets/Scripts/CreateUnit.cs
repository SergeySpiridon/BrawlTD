using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    public GameObject unit;
    public Vector2 placeSpawn;
    public Quaternion rotation;
  
    public void Create()
    {
        Instantiate(unit, transform.position, rotation.normalized);
    }
}
