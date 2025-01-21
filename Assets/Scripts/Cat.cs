using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject full;

    public int type = 0;
    private float _speed = 10f;
    private float _fullEnergy = 5f;
    private float _energy = 0f;

    public RectTransform foreground;

    private bool _isFull = false;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9f, 9f);
        transform.position = new Vector3(x, 31f, 0);

        switch (type)
        {
            case 0://그냥 고양이
                _speed = 10f;
                _fullEnergy = 5f;
                break;
            case 1://뚱뚱한 고양이
                _speed = 5f;
                _fullEnergy = 10f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_energy < _fullEnergy)
        {
            transform.position += Vector3.down * Time.deltaTime * _speed;
            if(transform.position.y < -16f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 1)
            {
                transform.position += Vector3.right * Time.deltaTime * _speed * 1.5f;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * _speed * 1.5f;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            if(_energy < _fullEnergy)
            {
                _energy += 1f;
                foreground.localScale = new Vector3(_energy / _fullEnergy, 1f, 1f);
                if(_energy >= _fullEnergy)
                {
                    if (!_isFull)
                    {
                        _isFull = true;
                        full.SetActive(true);
                        Destroy(gameObject, 3f);
                        GameManager.Instance.AddScore();
                    }
                }
            }
        }
    }
}
