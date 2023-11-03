using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<Button> buyButtons;   
     
    [SerializeField] private List<TextMeshProUGUI> buyButtonTexts;

    [SerializeField] private GameObject panelSkin1;
    [SerializeField] private GameObject panelSkin2;
    
    private float coinSkin1 = 10f;
    private bool buySkin1 = false;
    private float coinSkin2 = 20f;
    private bool buySkin2 = false;
    private float coinCount;

 
   


    private void Start()
    {
        for (int i = 0; i < buyButtons.Count; i++)
        {
            buyButtons[i].interactable = false;
            buyButtonTexts[i].text = "Lock";
        }
        buySkin1= PlayerPrefs.GetInt("buySkin1", 0) == 1;
        buySkin2 = PlayerPrefs.GetInt("buySkin2", 0) == 1;


    }

    private void Update()
    {
        coinCount = ManagerSingleton.instance.data.totalCoin;
        CheckIfCanBuy();

        if(buySkin1)
        {
            panelSkin1.SetActive(false);

        }
        if(buySkin2)
        {
            panelSkin2 .SetActive(false);
        }
    }

    public void CheckIfCanBuy()
    {


        for (int i = 0; i < buyButtons.Count; i++)
        {
            if (coinCount >= (i == 0 ? coinSkin1 : coinSkin2))
            {
                buyButtons[i].interactable = true;
                buyButtonTexts[i].text = "Buy";
            }
            else
            {
                buyButtons[i].interactable = false;
                buyButtonTexts[i].text = "Lock";
            }

        }
    }
    public void BuySkin1()
    {
        ManagerSingleton.instance.data.totalCoin -= coinSkin1;
        buySkin1 = true;
        PlayerPrefs.SetInt("buySkin1", buySkin1 ? 1 : 0);
        PlayerPrefs.Save();

    }
    public void BuySkin2()
    {
        ManagerSingleton.instance.data.totalCoin -= coinSkin2;
        buySkin2 = true;
        PlayerPrefs.SetInt("buySkin2", buySkin2 ? 1 : 0);
        PlayerPrefs.Save();

    }

}


