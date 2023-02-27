using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour

{
    public static Hand Instance;

//Knife khi da~ bay khoi hand
[SerializeField]
    GameObject[] knifeObjectRoot;
    GameObject knifeObjectClone;

    [SerializeField]
    float velocityKnife;
    Vector3 pointSpawnKnife;

    Animator animatorHand;
    const string animatorState = "beginThrow";
    [SerializeField]
    GameObject[] knifeOH1;
    //kiem tra xem hand nem" Knife hay chua



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        animatorHand = gameObject.GetComponent<Animator>();
        pointSpawnKnife = new Vector3(6f, 2.545f, 4f);
      
    }

    private void Start()
    {
        ShowKnifeOfHandBegin();
    }
    void ShowKnifeOfHandBegin()
    {
        foreach (GameObject kOH in knifeOH1) {

            kOH.SetActive(false);
        }

        knifeOH1[LoadingScene.selectItem].SetActive(true);
    }

    public void ShowKnifeOfHand()
    {
        foreach (GameObject kOH in knifeOH1)
        {

            kOH.SetActive(false);
        }
        knifeOH1[GamePlay.Instance.SelectItem].SetActive(true);
    }
    //last fram attack animation
    //throw knife, chuyen sang trang thai idle va active knife


    //hide knife cua animation attack 1 khi knife dang bay, va throw knife
    public void HideKnifeH()
    {
        //  knifeOfHandObject.SetActive(false);

        animatorHand.SetBool(animatorState, false);
        if (GamePlay.Instance.GetNumberKnife() < GamePlay.Instance.getMaxKnife())
        {
            knifeOH1[GamePlay.Instance.SelectItem].SetActive(true);
        }
        else
        {
            knifeOH1[GamePlay.Instance.SelectItem].SetActive(false);

        }

    }



    // Update is called once pe r frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Input.GetButtonDown("Vertical")
            //Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began
            if (!GamePlay.Instance.GetIsGameOver())
                if (GamePlay.Instance.GetNumberKnife() < GamePlay.Instance.getMaxKnife())
                {
                    GamePlay.Instance.AddNumberKnife();
                    //SoundManager.Instance.OnPlaySound(SoundName.throw2);


                    if (!animatorHand.GetBool(animatorState))
                    {
                        animatorHand.SetBool(animatorState, true);
                    }
                    else
                    {
                        animatorHand.SetTrigger("returnBegin");

                    }
                 
                    // Invoke("SpawnKnife", 0.18f);
                    StartCoroutine(SpawnKnife(GamePlay.Instance.GetNumberKnife()));
                }
        }
        /*
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ScreenCapture.CaptureScreenshot("GameScreenShot.png");
        }
        */

    }

    IEnumerator SpawnKnife(int number)
    {
        //yield on a new YieldInstruction that waits for 0.18 seconds.
        yield return new WaitForSeconds(0.1f);
        knifeObjectClone = Instantiate(knifeObjectRoot[GamePlay.Instance.SelectItem], pointSpawnKnife, Quaternion.Euler(0, -180, -90));
        knifeObjectClone.name = "Knife" + number;
        knifeObjectClone.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, velocityKnife), ForceMode.Impulse);
     

    }

}
