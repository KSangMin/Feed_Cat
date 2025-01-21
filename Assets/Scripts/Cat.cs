using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject full;

    public float speed = 10f;

    private float _fullEnergy = 5f;
    private float _energy = 0f;
    public RectTransform foreground;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9f, 9f);
        transform.position = new Vector3(x, 31f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_energy < _fullEnergy)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
            if(transform.position.y < -16f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 1)
            {
                transform.position += Vector3.right * Time.deltaTime * speed * 1.5f;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed * 1.5f;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if(_energy < _fullEnergy)
            {
                _energy += 1f;
                foreground.localScale = new Vector3(_energy / _fullEnergy, 1f, 1f);
                if(_energy >= _fullEnergy)
                {
                    full.SetActive(true);
                    Destroy(gameObject, 3f);
                }
            }
        }
    }
}
