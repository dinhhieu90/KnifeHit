using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject uiGameOver;
    [SerializeField]
    GameObject uiShop;
    [SerializeField]
    GameObject uiItem;
    // Start is called before the first frame update

   public void OpenShop()
    {
      
        uiShop.gameObject.SetActive(true);
        uiItem.SetActive(true);
        uiGameOver.SetActive(false);
        Time.timeScale = 1;

    }

}
