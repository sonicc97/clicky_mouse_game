using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isgameActive;
    private int score;
    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator allows Unity to pause and resume function execution at precisely defined points.
    IEnumerator SpawnTarget()
    {
        while (isgameActive)
        {
            //Pauses the coroutine for spawnRate seconds before continuing with the next iteration of the loop.
            yield return new WaitForSeconds(spawnRate);

            //Generates a random index from the list.
            int index = Random.Range(0, targets.Count);

            //Instantiate is a method in Unity used to create a copy (instance) of an existing object.
            Instantiate(targets[index]);

            
        }
    }

    public void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        isgameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame( int difficulty)
    {
        isgameActive = true;
        score = 0;
        spawnRate /= difficulty; 

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}
