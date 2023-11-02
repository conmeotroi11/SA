using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Button buyButton;   // Button mua skin
    private float requiredCoins = 100f;  // Số coin yêu cầu để mua skin
    public TextMeshProUGUI buyButtonText;
    public float coinCount;

    public Button buyButton1;   // Button mua skin
    private float requiredCoins1 = 200f;  // Số coin yêu cầu để mua skin
    public TextMeshProUGUI buyButtonText1;
   


    private void Start()
    {
        // Ban đầu, khóa Button Buy
        buyButton.interactable = false;
        buyButtonText.text = "Lock";

        buyButton1.interactable = false;
        buyButtonText1.text = "Lock";


    }

    private void Update()
    {
        coinCount = ManagerSingleton.instance.data.totalCoin;
        CheckIfCanBuy();
    }

    // Hàm này được gọi từ script khác để kiểm tra xem có đủ coin để mua skin không
    public void CheckIfCanBuy()
    {
       
        if (coinCount >= requiredCoins)
        {
            
            buyButton.interactable = true;
            buyButtonText.text = "Buy";
          
        }
        else
        {
            // Khóa Button Buy nếu không đủ coin
            buyButton.interactable = false;
            buyButtonText.text = "Lock";
        }

        if (coinCount >= requiredCoins1)
        {

            buyButton1.interactable = true;
            buyButtonText1.text = "Buy";

        }
        else
        {
            // Khóa Button Buy nếu không đủ coin
            buyButton1.interactable = false;
            buyButtonText1.text = "Lock";
        }

    }
    public void BuySkin()
    {
        ManagerSingleton.instance.data.totalCoin -= requiredCoins;
        
    }
    public void BuySkin1()
    {
        ManagerSingleton.instance.data.totalCoin -= requiredCoins1;

    }

}

