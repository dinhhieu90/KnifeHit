using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    public static int appleScore,selectItem;

    GameObject textLevel;
    // Start is called before the first frame update
    void Start()
    {
        appleScore = PlayerPrefs.GetInt("apple",0);
        selectItem= PlayerPrefs.GetInt("selectitem", 0);
        TransScene();
    }

    public void TransScene()
    {

        fader.gameObject.SetActive(true);
        // ALPHA
         LeanTween.alpha (fader, 0, 0);
         LeanTween.alpha (fader, 1, 0.3f).setOnComplete (() => {
             // Example for little pause before laoding the next scene
          
             SceneManager.LoadScene(1);
         });

      //  SceneManager.LoadScene(1);
    }
    // Update is called once per frame
  
}
