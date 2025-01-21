using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] cats = new GameObject[2];

    public GameObject replayButton;

    private int _level = 0;
    private int _score = 0;
    public Text levelText;
    public RectTransform levelBar;

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

    public void AddScore()
    {
        _score++;
        _level = _score / 5;
        levelBar.localScale = new Vector3((_score - _level * 5f) / 5.0f, 1f, 1f);
        levelText.text = _level.ToString();
    }
}
