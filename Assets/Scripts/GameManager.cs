using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private HeroStackController heroStackController;
    public int currentLevel;
    public int playerScore;
    public int cubeScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI cubeText;
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;


    void Start()
    {
        
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
        playerScore = 0;
        cubeScore = 0;
        cubeText.text = cubeScore+ " Cube";
    }

    
    void Update()
    {
        cubeScore = heroStackController.blockList.Count;
        cubeText.text = cubeScore+ " Cube";
        int scoreToInt = (int)heroStackController.transform.position.z;
        scoreText.text = scoreToInt+ " Score";

    }
    public void PlayButton() {
        if (PlayerPrefs.GetInt("playerLevel")<1) {
            SceneManager.LoadScene(1);
        }
        else {
            SceneManager.LoadScene(PlayerPrefs.GetInt("playerLevel"));
            Debug.Log(PlayerPrefs.GetInt("playerLevel"));
        }
        

    }
    public void NextButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
    public void RetryButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetInt("playerLevel"));

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Cube") {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            currentLevel++;
            PlayerPrefs.SetInt("playerLevel", PlayerPrefs.GetInt("playerLevel")+1);
            Debug.Log(PlayerPrefs.GetInt("playerLevel"));

        }
        if (collision.gameObject.tag == "MainCube") {
            playerScore = 0;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

        }
    }


}
