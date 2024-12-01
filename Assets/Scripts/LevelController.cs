using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    int score = 0;
    [SerializeField] int lives = 3;
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    [SerializeField] GameObject ballPrefab;

    private void Awake()
    {
        LevelController[] objs = FindObjectsOfType<LevelController>();

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecreaseLives()
    {
        lives--;

        livesText.text = lives.ToString();
        if (lives > 0)
        {
            RespawnPlayer();
        }
        else
        {
            SceneManager.LoadScene("End Screen");
        }

    }

    private void RespawnPlayer()
    {
        Vector3 respawnPosition = new Vector3(0, -4, 0);
        Instantiate(ballPrefab, respawnPosition, Quaternion.identity);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}