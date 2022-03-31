using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWindows : MonoBehaviour
{
    public List<GameObject> windows;
    public float minSize;
    public float maxSize;
    public float minSpeed;
    public float maxSpeed;
    public float minY;
    public float maxY;
    public float frequency;
    public float loseSize;

    void Start()
    {
        InvokeRepeating("CreateWindow", 0, frequency);
    }

    void CreateWindow()
    {

        GameObject window = windows[Random.Range(0, windows.Count)];
        if (window.name.Equals("Widnow0"))
            CreateWindow0(window);
        else
            CreateWindow2(window);

        //int rnd = Random.Range(0, windows.Count);
        //GameObject window = windows[rnd];
        //if (rnd == 0)
        //    CreateWindow0(window);
        //else
        //    CreateWindow2(window);

    }
    void CreateWindow0(GameObject window)
    {
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        float scl = Random.Range(minSize/loseSize, maxSize/loseSize);
        Vector2 scale = new Vector2(scl/loseSize, scl/loseSize);
        float speed = Random.Range(minSpeed, maxSpeed);
        GameObject s = Instantiate(window, pos, Quaternion.identity);
        s.GetComponent<MoveLeafs>().Speed = speed/loseSize;
        s.transform.localScale = scale;
    }
    void CreateWindow2(GameObject window)
    {
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        float scl = Random.Range(minSize, maxSize);
        Vector2 scale = new Vector2(scl, scl);
        float speed = Random.Range(minSpeed, maxSpeed);
        GameObject s = Instantiate(window, pos, Quaternion.identity);
        s.GetComponent<MoveLeafs>().Speed = speed;
        s.transform.localScale = scale;
    }
}
