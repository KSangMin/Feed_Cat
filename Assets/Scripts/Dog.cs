using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateFood", 0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if(x < -8.5f)
        {
            x = -8.5f;
        }
        else if(x > 8.5f)
        {
            x = 8.5f;
        }
        transform.position = new Vector3(x, -16.1f, 0f);
    }

    public void CreateFood()
    {
        Instantiate(food, transform.position + new Vector3(0f, 3.4f, 0f), Quaternion.identity);
    }
}
