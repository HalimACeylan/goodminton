using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManagerScript : MonoBehaviour
{

    private GameObject windZone;
    private GameObject player;
    public GameObject gameOverUI;
    public int aiScore;
    public int playerScore;
    public GameObject scoreBoard;
    public int windCountDown = 5;

    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        windZone = GameObject.Find("WindZone");
        player = GameObject.Find("Player");
        scoreBoard = GameObject.Find("ScoreBoard");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();

            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }

        if (aiScore == 21 || playerScore == 21)
        {
            gameOver();
        }
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (windCountDown <= 0)
        {
            windZone.GetComponent<WindZone>().strangthReset();
            windCountDown = 5;

        }


    }


    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        gameOverUI.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public bool incrementScore(bool isLastHitByAi)
    {
        bool isTurnAi = false;
        if (isLastHitByAi)
        {
            playerScore = playerScore + 1;
            TMP_Text playerScoreBoard = scoreBoard.transform.GetChild(3).gameObject.GetComponent<TMP_Text>();
            playerScoreBoard.text = playerScore.ToString();
            Debug.Log("Board  : " + playerScoreBoard.text + " playerScore : " + playerScore);
            player.GetComponent<PlayerController>().setPlayerReset();
            isTurnAi = false;
            windCountDown = windCountDown - 1;
        }
        else
        {
            aiScore = aiScore + 1;
            TMP_Text aiScoreBoard = scoreBoard.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            aiScoreBoard.text = aiScore.ToString();
            Debug.Log("Board  : " + aiScoreBoard.text + " playerScore : " + aiScore);
            isTurnAi = true;
            windCountDown = windCountDown - 1;
        }

        return isTurnAi;
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        gameOverUI.transform.GetChild(0).gameObject.SetActive(true);

        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }



    }
}
