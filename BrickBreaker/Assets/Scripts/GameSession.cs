using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    //config parameters
    //range is something that is used to create a slider and min and max values for a variable
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] Text scoreText;



    //state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        //key is the fact that it looks for OBJECTS emphasis on the S
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            //the above line is due to the fact of script execution order which can result in 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            //dont destroy when level/game status is used again
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
       scoreText.text = currentScore.ToString();
       //scoreText.text = "0";
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void addToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
