using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gopanel;
    public GameObject winpanel;
    public int score;
    public Text scoretext;
    public Text scorefinishtxt;

    // Start is called before the first frame update
    void Start()
    {
        gopanel.SetActive(false);
        winpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        score += 10;
        scoretext.text = "score :" + score;
    }

    public void GameOver()
    {
        gopanel.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D Crystal)
    {
        if(Crystal.gameObject.tag == "Crystal")
        {
            Destroy(Crystal.gameObject);
        }
    }

    public void GameComplete()
    {
        scorefinishtxt.text = "score : " + score;
        winpanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
