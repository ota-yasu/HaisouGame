using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.Find("ScoreText").GetComponent<Text>();
	Score.text = "記録:" + IventScript.dayscount + "日間";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverClick(){
	SceneManager.LoadScene("StartScene");    
    }
}
