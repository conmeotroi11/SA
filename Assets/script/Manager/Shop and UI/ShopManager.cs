using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Button buyButton;   
    private float requiredCoins = 100f;  
    [SerializeField] private TextMeshProUGUI buyButtonText;

    [SerializeField] private Button buyButton1;
    private float requiredCoins1 = 200f;
    [SerializeField] private TextMeshProUGUI buyButtonText1;
    
    private float coinCount;

 
   


    private void Start()
    {
        
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

    public void CheckIfCanBuy()
    {
       
        if (coinCount >= requiredCoins)
        {
            
            buyButton.interactable = true;
            buyButtonText.text = "Buy";
          
        }
        else
        {
          
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


//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//[System.Serializable]
//public class ShopItem
//{
//    public Button buyButton;
//    public float requiredCoins;
//    public TextMeshProUGUI buyButtonText;
//}

//public class ShopManager : MonoBehaviour
//{
//    [SerializeField] private ShopItem[] shopItems;
//    private float coinCount;

//    private void Start()
//    {
//        foreach (var item in shopItems)
//        {
//            item.buyButton.interactable = false;
//            item.buyButtonText.text = "Lock";
//        }
//    }

//    private void Update()
//    {
//        coinCount = ManagerSingleton.instance.data.totalCoin;
//        CheckIfCanBuy();
//    }

//    public void CheckIfCanBuy()
//    {
//        foreach (var item in shopItems)
//        {
//            if (coinCount >= item.requiredCoins)
//            {
//                item.buyButton.interactable = true;
//                item.buyButtonText.text = "Buy";
//            }
//            else
//            {
//                item.buyButton.interactable = false;
//                item.buyButtonText.text = "Lock";
//            }
//        }
//    }

//    public void BuySkin(int itemIndex)
//    {
//        if (itemIndex >= 0 && itemIndex < shopItems.Length)
//        {
//            var item = shopItems[itemIndex];
//            ManagerSingleton.instance.data.totalCoin -= item.requiredCoins;
//        }
//    }
//}

