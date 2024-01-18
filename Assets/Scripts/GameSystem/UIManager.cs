using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text scoreText;
    public GameObject gameoverPanel;


    private void Awake()
    {

        GameManager.Instance.uiManager = this;
        GameManager.Instance.score = 0;
        SettingScore(0);
        SettingGameover();
        gameoverPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingScore(int score)
    {
        scoreText.text = string.Format("{0:0}", score);
    }

    public void SettingGameover()
    {
        int score = GameManager.Instance.score;
        gameOverText.text = string.Format("Score: {0:0}", score);
        gameoverPanel.SetActive(true);
    }

    public void Restartbtn()
    {
        GameManager.Instance.RestartScene();
    }

    public void Exitbtn()
    {
        GameManager.Instance.QuitGame();
    }
}
