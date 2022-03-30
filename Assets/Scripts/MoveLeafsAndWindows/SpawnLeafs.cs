using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeafs : MonoBehaviour
{

    public List<GameObject> leafs;
    public float minSize;
    public float maxSize;
    public float minSpeed;
    public float maxSpeed;
    public float minY;
    public float maxY;
    public float frequency;

    void Start()
    {
        InvokeRepeating("CreateLeafs", 0, frequency);
    }

    void CreateLeafs()
    {
        GameObject leaf = leafs[Random.Range(0, leafs.Count)];
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY,maxY));
        float scl = Random.Range(minSize, maxSize);
        Vector2 scale = new Vector2(scl, scl);
        float speed = Random.Range(minSpeed,maxSpeed);
        GameObject s = Instantiate(leaf, pos, Quaternion.identity);
        s.GetComponent<MoveLeafs>().Speed = speed;
        s.transform.localScale = scale;
    }

    
    
}
