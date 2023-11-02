using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerSingleton : MonoBehaviour
{
    public static ManagerSingleton instance;
    public  GameObject destroyPoint;

    
    public float currentScore = 0f;
    public bool isPlay = false;

    public float currentCoin = 0f;
    

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameover = new UnityEvent();
    

    public GameObject player;
    public bool playerChoose;
    public GameObject player1;
    public bool playerChoose1;
    public GameObject player2;
    public bool playerChoose2;

    public bool playerActive = true;


    public GameObject spawn;
    public GameObject checkReset;

    public DataSave data;   


     void Start()
    {
        string loadedData = SaveSystem.Load("save");
        if (loadedData != null)
        {
            data = JsonUtility.FromJson<DataSave>(loadedData);
        }
        else
        {
            data = new DataSave();
        }
        playerChoose = true;
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            currentScore += Time.deltaTime;
            Debug.Log(1);
        }
    }

    #region UI 
    public void GameOVer()
    {
        DataCoin();
        DataScore();
        isPlay = false;
        onGameover.Invoke();
    }
    public void StartGame()
    {
        onPlay.Invoke();
        isPlay = true;
        currentCoin = 0f;
        currentScore = 0f;
    }


    #endregion


    #region Show Score and Coin
    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();

    }
    public string PrettyHighScore()
    {
        return Mathf.RoundToInt(data.highScore).ToString();
    }

    public string PrettyCoin()
    {
        return Mathf.RoundToInt(currentCoin).ToString();
    }

    public string PrettyTotalCoin()
    {
        return Mathf.RoundToInt(data.totalCoin).ToString();
    }

    #endregion



  

    public void PlayerActive()
    {
    
            if(playerChoose)
            {
            player.transform.position = new Vector3(0, -4, -4);
            player.SetActive(true);
            }
            
             if(playerChoose1) 
            {
            player1.transform.position = new Vector3(0, -4, -4);
            player1.SetActive(true);
            }
            if (playerChoose2)
            {
            player2.transform.position = new Vector3(0, -4, -4);
            player2.SetActive(true);
            }




        playerActive = true;

    }

    public void SpawnReset()
    {
        spawn.transform.position = new Vector3(0, 1, -5);
        checkReset.transform.position = new Vector3(1, 0, 0);
        
    }

    #region Data Score and Coin
    public void DataScore()
    {
        if (data.highScore < currentScore)
        {
            data.highScore = currentScore;
            string saveString = JsonUtility.ToJson(data);
            SaveSystem.Save("save", saveString);
        }

    }
    public void DataCoin()
    {
        data.totalCoin += currentCoin;
        string saveStringCoin = JsonUtility.ToJson(data);
        SaveSystem.Save("save", saveStringCoin);
    }
    #endregion



    #region Player Choose
    public void PlayerChoose()
    {
        playerChoose = true;
        playerChoose1 = false;
        playerChoose2 = false;
    }
    public void Player1Choose()
    {
        playerChoose1 = true;
        playerChoose = false;
        playerChoose2 = false;
    }
    public void Player2Choose()
    {
        playerChoose2 = true;
        playerChoose = false;
        playerChoose1 = false;

    }
    #endregion

}
