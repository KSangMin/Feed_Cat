using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] cats = new GameObject[2];

    public GameObject replayButton;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateCat", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCat()
    {
        int i = Random.Range(0, cats.Length);
        Instantiate(cats[i]);
    }

    public void GameOver()
    {
        replayButton.SetActive(true);
        Time.timeScale = 0f;
    }
}
