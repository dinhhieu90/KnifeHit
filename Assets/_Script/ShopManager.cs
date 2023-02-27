
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    KnifeInfo[] knifeShop;
    int maxItem;
    int currentItem;
    [SerializeField]
    GameObject[] knifeObt;
    [SerializeField]
    int[] price;
    [SerializeField]
    TextMeshProUGUI priceTMP;
    [SerializeField]
    GameObject buyBtn;
    [SerializeField]
    GameObject pickBtn;
    [SerializeField]
    GameObject pickedBtn;
    void Awake()
    {
        maxItem = knifeObt.Length;
        currentItem = 0;
        knifeShop = new KnifeInfo[maxItem];
        for (int i = 0; i < maxItem; i++)
        {
            knifeShop[i] = new KnifeInfo();
            knifeShop[i].IsUnlock = PlayerPrefs.GetInt("unlock" + i, 0);
        }
        knifeShop[0].IsUnlock = 1;

        ShowShop(0);

    }

    void FixPriceText()
    {
        switch (currentItem)
        {
            case 0:
                priceTMP.rectTransform.anchoredPosition = new Vector2(95.9f, -40.8f);
                break;
            case 1: priceTMP.rectTransform.anchoredPosition = new Vector2(81.7f, -40.8f);
                break;
            case 2:
                priceTMP.rectTransform.anchoredPosition = new Vector2(71.9f, -40.8f);
                break;
            case 3:
                priceTMP.rectTransform.anchoredPosition = new Vector2(71.9f, -40.8f);
                break;
            case 4:
                priceTMP.rectTransform.anchoredPosition = new Vector2(71.9f, -40.8f);
                break;
            case 5:
                priceTMP.rectTransform.anchoredPosition = new Vector2(62.82f, -40.8f);
                break;
            case 6:
                priceTMP.rectTransform.anchoredPosition = new Vector2(62.82f, -40.8f);
                break;
            case 7:
                priceTMP.rectTransform.anchoredPosition = new Vector2(62.82f, -40.8f);
                break;
            case 8:
                priceTMP.rectTransform.anchoredPosition = new Vector2(62.82f, -40.8f);
                break;

            default:
                priceTMP.rectTransform.anchoredPosition = new Vector2(62.82f, -40.8f);
                break;
        }
    }

    public void NextItem()
    {
        currentItem += 1;
        if (currentItem > maxItem - 1)
        {
            currentItem = 0;
        }
        ShowShop(currentItem);

    }

    public void PreItem()
    {
        currentItem -= 1;
        if (currentItem < 0)
        {
            currentItem = maxItem - 1;
        }
        ShowShop(currentItem);

    }


    void ShowShop(int current)
    {
        foreach (GameObject knife in knifeObt)
        {
            knife.SetActive(false);
        }
        knifeObt[current].SetActive(true);
        FixPriceText();
        priceTMP.SetText("" + price[current]);

        if (knifeShop[current].IsUnlock == 1)
        {
            buyBtn.SetActive(false);
            if (current == GamePlay.Instance.SelectItem)
            {
                pickedBtn.SetActive(true);
                pickBtn.SetActive(false);
            }
            else
            {
                pickedBtn.SetActive(false);
                pickBtn.SetActive(true);
            }
        }
        else
        {
            buyBtn.SetActive(true);
            pickedBtn.SetActive(false);
            pickBtn.SetActive(false);

        }
    }
    public void BuyItem()
    {
        if (GamePlay.Instance.GetApple() >= price[currentItem])
        {
            knifeShop[currentItem].IsUnlock = 1;
            PlayerPrefs.SetInt("unlock" + currentItem, 1);
            GamePlay.Instance.SetApple(GamePlay.Instance.GetApple() - price[currentItem]);
            buyBtn.SetActive(false);
            pickBtn.SetActive(true);
            pickedBtn.SetActive(false);
        }

    }

    public void PickItem()
    {

        LoadingScene.selectItem = currentItem;
        PlayerPrefs.SetInt("selectitem", currentItem);
        pickedBtn.SetActive(true);
        pickBtn.SetActive(false);
        GamePlay.Instance.SelectItem = currentItem;
    }

}
