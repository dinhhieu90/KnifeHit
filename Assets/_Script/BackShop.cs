using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShop : MonoBehaviour
{
    [SerializeField]
    GameObject uiGameOver;
    [SerializeField]
    GameObject uiShop;
    [SerializeField]
    GameObject uiItem;
    // Start is called before the first frame update
    public void Back()
    {
        uiGameOver.SetActive(true);
        uiItem.SetActive(false);
        uiShop.SetActive(false);
        Time.timeScale = 0;

    }
}
