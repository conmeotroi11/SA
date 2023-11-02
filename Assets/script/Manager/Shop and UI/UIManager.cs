using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gamePlayMenuUI;
    [SerializeField] private GameObject gameOverMenuUI;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private bool playerBuy = false;
    private bool playerBuy1 = false;



    [SerializeField] private TextMeshProUGUI scoreResume;
    [SerializeField] private TextMeshProUGUI coinResume;
    [SerializeField] private TextMeshProUGUI scoreOver;
    [SerializeField] private TextMeshProUGUI coinOver;
    [SerializeField] private TextMeshProUGUI highScoreOver;

    [SerializeField] private TextMeshProUGUI totalCoin;
    
    
    ManagerSingleton gm;

    private void Start()
    {
        gm = ManagerSingleton.instance;
        gm.onGameover.AddListener(GameOverPanel);
        playerBuy = PlayerPrefs.GetInt("PlayerBuy", 0) == 1; 
        playerBuy1 = PlayerPrefs.GetInt("PlayerBuy1", 0) == 1;

    }
    
    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
        coinUI.text = gm.PrettyCoin();
        totalCoin.text = "Total Coin : " + gm.PrettyTotalCoin();

        if(playerBuy)
        {
            player1.SetActive(true);
        }

        if (playerBuy1)
        {
            player2.SetActive(true);
        }

    }
    public void PlayButtonHandlder()
    {
        gm.StartGame();
        startMenuUI.SetActive(false);
        gamePlayMenuUI.SetActive(true);
      
    }
    public void GameOverPanel()
    {
        gameOverMenuUI.SetActive(true);
        scoreOver.text = "Score : " + gm.PrettyScore();
        highScoreOver.text = "Highccore : " + gm.PrettyHighScore();
        coinOver.text = "Coin : " + gm.PrettyCoin();


    }
   public void MenuButton()
    {
        gm.PlayerActive();
        gm.SpawnReset();
        gm.isPlay = false;
       
    }
    public void PlayAgain()
    {
        gm.SpawnReset();
        gm.PlayerActive();
        gm.isPlay = true;
        gm.currentCoin = 0f;
        gm.currentScore = 0f;
       
       
    }
    public void ResumeButton()
    {
        gm.isPlay = true;
      
    }
    public void PauseButton()
    {
        gm.isPlay =false;
        scoreResume.text ="Score : " + gm.PrettyScore();
        coinResume.text ="Coin : " + gm.PrettyCoin();
        
   
    }
    public void BuyPlayer()
    {
       
        playerBuy = true;
        PlayerPrefs.SetInt("PlayerBuy", playerBuy ? 1 : 0); 
        PlayerPrefs.Save(); 
    }

    public void BuyPlayer1()
    {

        playerBuy1 = true;
        PlayerPrefs.SetInt("PlayerBuy1", playerBuy1 ? 1 : 0); 
        PlayerPrefs.Save(); 
    }


}
