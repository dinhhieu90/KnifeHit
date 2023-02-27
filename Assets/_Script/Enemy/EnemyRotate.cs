using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{


    // public List<RotationVariatio> randomRotation = new List<RotationVariatio>();
    public static EnemyRotate Instance;
    private List<GameObject> woodParticleTrigger = new List<GameObject>();

    public GameObject woodImpact;
    [SerializeField]
    public GameObject[] bossObj;
    [SerializeField]
    public Vector3[] posBoss;

    public GameObject Dummy;

    Vector3 pointParticle;

    int numberR,numberL,rotateL, rotateR;
    int numberKnifeIn, type;
    bool beginPlay;
    Vector2 timeV;
    Vector2 gocV;
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

        pointParticle = new Vector3(6.05f, 2.6f, 4.5f);
        rotateL = 0;
        rotateR = 0;
        numberR= 1;
        numberL = 1;
        type = -1;
        beginPlay = false;
        numberKnifeIn = 0;
        timeV.Set(1.1f,0);
        gocV.Set(170, 0);


    }

    
    public void CleanEnemyToStand()
    {

        //delete knife in enemy
        foreach (Transform cT in transform)
        {
            if (cT.gameObject.CompareTag("Knife") || cT.gameObject.CompareTag("Apple"))
            {
                Destroy(cT.gameObject);
            }
        }
        LeanTween.cancel(gameObject);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        numberKnifeIn = 0;
        rotateL = 0;
        rotateR = 0;

    }
    public void ResetNumBerKnifeIn()
    {
        numberKnifeIn = 0;
    }
    public void AddNumberKIN()
    {
        numberKnifeIn += 1;
    }
    public int GetNumberKIN()
    {
        return numberKnifeIn;
    }
    // Update is called once per frame

    void PlaySoundEnemy()
    {
   
        if (GamePlay.Instance.GetSoundAOrE())
        {
            SoundManager.Instance.OnPlaySound(SoundName.impactfruit1);
            GamePlay.Instance.SetSoundAOrE(false);
        }
        else
        {
            if (type== -1)
            {
                SoundManager.Instance.OnPlaySound(SoundName.impact);
            }
            else
            {
                SoundManager.Instance.OnPlaySound(SoundName.impactfruit1);
            }
        }
    }

    public void SetBeginPlay(bool b)
    {
        beginPlay = b;
    }
    private void OnCollisionEnter(Collision other)
    {

        if (beginPlay && other.transform.tag == "Knife")
        {
        
            if (EnemyRotate.Instance.GetNumberKIN() == GamePlay.Instance.getMaxKnife())
            {

                Invoke("LevelUp", 0.05f);

            }
            else
            {
                Invoke("PlaySoundEnemy", 0.07f);

            }
            getWoodParticleTrigger(pointParticle);

        }
    }

    void LevelUp()
    {
        if (type== -1)
        {

            Break.Instance.BreakEnemy1();
            SoundManager.Instance.OnPlaySound(SoundName.breakwood);
        }
        else
        {

            Break.Instance.BreakEnemy(type);
            SoundManager.Instance.OnPlaySound(SoundName.breakfruit3);
        }


        //go lv2
        GamePlay.Instance.LevelUp();
    }
    public void loadLV1()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        timeV.Set(1.1f, 0);
        gocV.Set(177, 169);
        if (Random.value > 0.5f)
        {
            RotateL1();
        }
        else
        {
            RotateR1();
        }
     
        beginPlay = true;
    }

    public void loadLV2()
    {
        type = -1;
        timeV.Set(1.1f, 0);
        gocV.Set(177, 173);
        if (Random.value > 0.5)
        {
            RotateL1();
        }
        else
        {
            RotateR1();
        }
        beginPlay = true;
    }
    public void loadLV3()
    {
        type = -1;
        numberR = 1;
        numberL = 1;
        timeV.Set(1f, 0.6f);
        gocV.Set(177, 59);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV4()
    {
        type = -1;
        numberR = 1;
        numberL = 1;
        timeV.Set(1f, 0.6f);
        gocV.Set(177, 65);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV5()
    {

        type = Random.Range(0, 3);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);

        numberR = 2;
        numberL = 2;
        timeV.Set(1.1f, 0.5f);
        gocV.Set(177, 39);
        if (Random.value > 0.5f)
        {
            RotateR1();
        }
        else
        {
            RotateL1();
        }
        
        beginPlay = true;
    }

    public void loadLV6()
    {
      
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        numberR = 1;
        numberL = 1;
        timeV.Set(0.75f, 0.65f);
        gocV.Set(97, 75);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }


        beginPlay = true;
    }


    public void loadLV7()
    {
        type = -1;
        numberL = 2;
        numberR = 2;
        gocV.Set(177, 167);
        timeV.Set(1.1f, 1f);
        Rotate3();
        beginPlay = true;
    }

    public void loadLV8()
    {
        type = -1;
        numberL = 0;
        numberR = 0;
        gocV.Set(77, 97);
        timeV.Set(0.65f, 0.75f);
        if (Random.value > 0.5f)
        {
            RotateL2();
        }
        else
        {
            RotateR2();
        }
        beginPlay = true;
    }

    public void loadLV9()
    {
        type = -1;
        numberR = 1;
        numberL = 1;
        timeV.Set(0.8f, 0.6f);
        gocV.Set(157, 67);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }
    public void loadLV10()
    {


       type = Random.Range(0, 3);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
        
        
        numberR = 2;
        numberL = 2;
        timeV.Set(1f, 0.8f);
        gocV.Set(173, 73);
        if (Random.value > 0.5f)
        {
            RotateR4();
        }
        else
        {
            RotateR4();
        }

        beginPlay = true;
        
    }

    public void loadLV11()
    {

        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        numberR = 1;
        numberL = 1;
        timeV.Set(0.6f, 0.5f);
        gocV.Set(70, 60);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV12()
    {
        type = -1;
        timeV.Set(1.6f, 1.8f);
        gocV.Set(150, 170);
        numberR = 2;
        numberL = 1;
        Rotate5();
        beginPlay = true;
    }

    public void loadLV13()
    {
        type = -1;
        numberL = 2;
        numberR = 2;
        gocV.Set(169, 59);
        timeV.Set(0.7f, 0.7f);
        Rotate3();
        beginPlay = true;
    }

    public void loadLV14()
    {
        type = -1;
        numberL = 4;
        numberR = 4;
        gocV.Set(170, 150);
        timeV.Set(0.9f, 0.9f);
        Rotate3();
        beginPlay = true;
    }

    public void loadLV15()
    {


        type = Random.Range(0, 3);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
       
        gocV.Set(129, 171);
        numberL = 9;
        numberR = 9;
        timeV.Set(0.22f, 0.9f);
        if (Random.value > 0.5f)
        {
            RotateL6();
        }
        else{
            RotateR6();
        }
        beginPlay = true;
    }
    public void loadLV16()
    {

        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type =- 1;
        numberL = 2;
        numberR = 2;
        gocV.Set(119, 27);

        timeV.Set(0.7f, 0f);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV17()
    {
        type = -1;
        timeV.Set(0.85f, 1.3f);
        gocV.Set(157, 169);
        numberR = 4;
        numberL = 4;
        Rotate5();
        beginPlay = true;
    }
    public void loadLV18()
    {
        type = -1;
        timeV.Set(0.8f, 0.65f);
        gocV.Set(170, 70);
        numberL = 2;
        numberR = 2;
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV19()
    {

        type = -1;
        gocV.Set(169, 167);
        timeV.Set(0.99f, 0.2f);
        numberL = 2;
        numberR = 2;
        Rotate3();
        beginPlay = true;
    }

    public void loadLV20()
    {

       type = Random.Range(0, 4);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
       
        gocV.Set(169, 115);
        timeV.Set(0.9f, 0.95f);
        numberL = 3;
        numberR = 3;
        if (Random.value > 0.5f)
        {
            RotateL7();
        }
        else
        {
            RotateR7();
        }
        beginPlay = true;
    }

    public void loadLV21()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        timeV.Set(0.8f, 0.5f);
        gocV.Set(170, 70);
        numberL = 1;
        numberR = 1;
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV22()
    {
        type = -1;
        numberL = 1;
        numberR = 1;
        timeV.Set(0.85f, 0.85f);
        gocV.Set(170, 170);
        if (Random.value > 0.5f)
        {
            RotateR1();
        }
        else
        {
            RotateL1();
        }
        beginPlay = true;
    }

    public void loadLV23()
    {
        type = -1;
        numberL = 3;
        numberR = 3;
        timeV.Set(1, 0.7f);
        gocV.Set(170, 170);
        if (Random.value > 0.5f)
        {
            RotateR4();
        }
        else
        {
            RotateL4();
        }
        beginPlay = true;
    }

    public void loadLV24()
    {

        type = -1;
        numberL = 1;
        numberR = 1;
        gocV.Set(159, 17);
        timeV.Set(0.6f, 0.4f);
        if (Random.value > 0.5f)
        {
            RotateR8();
        }
        else
        {
            RotateL8();
        }
        beginPlay = true;
    }

    public void loadLV25()
    {

        type = Random.Range(0, 5);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
      
        numberL = 1;
        numberR = 1;
        gocV.Set(53, 157);
        timeV.Set(0.7f, 0.8f);
        if (Random.value > 0.5f)
        {
            RotateL9();
        }
        else
        {
            RotateR9();
        }
        beginPlay = true;
    }

    public void loadLV26()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        numberL = 3;
        numberR = 3;
        gocV.Set(167, 139);
        timeV.Set(0.5f, 0.95f);
        if (Random.value > 0.5f)
        {
            RotateR4();
        }
        else
        {
            RotateL4();
        }
        beginPlay = true;
    }

    public void loadLV27()
    {
        type = -1;
        numberL = 3;
        numberR = 3;
        gocV.Set(167, 167);
        timeV.Set(0.8f, 0.8f);
        Rotate3();
        beginPlay = true;
    }

    public void loadLV28()
    {

        type =- 1;
        numberR = 2;
        numberL = 2;
        timeV.Set(0.75f, 0.4f);
        gocV.Set(170, 60);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV29()
    {
        type = -1;
        numberL = 0;
        numberR = 0;
        gocV.Set(167, 69);
        timeV.Set(0.75f, 0.45f);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
       
        beginPlay = true;
    }
    public void loadLV30()
    {

type = Random.Range(0, 5);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
        
        timeV.Set(0.75f, 1.4f);
        gocV.Set(167, 167);
        numberL = 1;
        numberR = 1;
        Rotate5();
        beginPlay = true;
    }

    public void loadLV31()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type =- 1;
        timeV.Set(0.65f, 1.4f);
        gocV.Set(159, 167);
        numberL = 1;
        numberR = 1;
        Rotate5();
        beginPlay = true;
    }

    public void loadLV32()
    {
        type =- 1;
        timeV.Set(0.85f, 0.7f);
        gocV.Set(167, 67);
        numberL = 2;
        numberR = 3;
        Rotate3();
        beginPlay = true;
    }
    public void loadLV33()
    {
        type =- 1;
        gocV.Set(159, 167);
        timeV.Set(0.8f, 1.1f);
        numberR = 1;
        numberL = 1;
        if (Random.value > 0.5f)
        {
            RotateL1();
        }
        else
        {
            RotateR1();
        }
        beginPlay = true;
    }




    public void loadLV34()
    {
        type = -1;
        numberL = 3;
        numberR = 3;
        timeV.Set(0.75f, 0.7f);
        gocV.Set(167, 77);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
             RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV35()
    {

       type = Random.Range(0, 5);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);
        
        gocV.Set(175, 177);
        numberL = 6;
        numberR = 6;
        timeV.Set(0.55f, 1.1f);
        if (Random.value > 0.5f)
        {
            RotateL6();
        }
        else
        {
            RotateR6();
        }
        beginPlay = true;
    }

    public void loadLV36()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type = -1;
        numberL = 3;
        numberR = 3;
        gocV.Set(177, 139);
        timeV.Set(0.85f, 0.75f);
        if (Random.value > 0.5f)
        {
            RotateR4();
        }
        else
        {
            RotateL4();
        }
        beginPlay = true;
    }

    public void loadLV37()
    {
        type = -1;
        timeV.Set(0.75f, 0.95f);
        gocV.Set(157, 177);
        numberR = 3;
        numberL = 3;
        Rotate5();
        beginPlay = true;
    }

    public void loadLV38()

    {
        type =- 1;
        gocV.Set(173, 177);
        numberL = 9;
        numberR = 9;
        timeV.Set(0.45f, 0.95f);
        if (Random.value > 0.5f)
        {
            RotateL6();
        }
        else
        {
            RotateR6();
        }
            beginPlay = true;
    }

    public void loadLV39()
    {
        type =- 1;
        timeV.Set(0.65f, 1.1f);
        gocV.Set(177, 137);
        numberR = 2;
        numberL = 2;
        Rotate10();
        beginPlay = true;
    }

    public void loadLV40()
    {

    type= Random.Range(0, 5);
        GameObject B1 = Instantiate(bossObj[type], posBoss[type], Quaternion.identity);
        B1.transform.SetParent(gameObject.transform);
        B1.SetActive(true);
        Dummy.SetActive(false);

        gocV.Set(157, 177);
        timeV.Set(0.55f, 0.99f);
        numberL = 3;
        numberR = 3;
        if (Random.value > 0.5f)
        {
            RotateL7();
        }
        else
        {
            RotateR7();
        }
        beginPlay = true;
    }

    public void loadLV41()
    {
        foreach (Transform cT in gameObject.transform)
        {
            if (cT.gameObject.CompareTag("Boss"))
            {
                Destroy(cT.gameObject);
            }

        }
        Dummy.SetActive(true);
        type =- 1;
        numberL = 3;
        numberR = 3;
        gocV.Set(147, 179);
        timeV.Set(0.7f, 0.8f);
        if (Random.value > 0.5f)
        {
            RotateL9();
        }
        else
        {
            RotateR9();
        }
            beginPlay = true;
    }
    public void loadLV42()
    {
        type = -1;
        numberR = 3;
        numberL = 3;
        timeV.Set(0.8f, 0.7f);
        gocV.Set(177, 97);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }

    public void loadLV43()
    {
        type =- 1;
        numberR = 1;
        numberL = 1;
        timeV.Set(0.7f, 0.8f);
        gocV.Set(173, 123);
        if (Random.value > 0.5f)
        {
            RotateR2();
        }
        else
        {
            RotateL2();
        }
        beginPlay = true;
    }
    public void loadLV44()
    {
        loadLV27();
    }

    public void loadLV45()
    {
        loadLV15();
    }

    public void loadLV46()
    {
        loadLV26();
    }

    public void loadLV47()
    {
        loadLV28();
    }
    public void loadLV48()
    {
        loadLV37();
    }
    public void loadLV49()
    {
        loadLV22();
    }

    public void loadLV50()
    {
        loadLV35();
    }


    public void loadLV51()
    {
        loadLV31();
    }
    public void loadLV52()
    {
        loadLV39();
    }
    public void loadLV53()
    {
        loadLV18();
    }

    public void loadLV54()
    {
        loadLV27();
    }

    public void loadLV55()
    {
        loadLV25();
    }

    public void loadLV56()
    {
        loadLV36();
    }

    public void loadLV57()
    {
        loadLV24();
    }

    public void loadLV58()
    {
        loadLV29();
    }

    public void loadLV59()
    {
        loadLV37();
    }
    public void loadLV60()
    {
        loadLV30();
    }
    public void loadLV61()
    {
        loadLV31();
    }

    public void loadLV62()
    {
        loadLV32();
    }

    public void loadLV63()
    {
        loadLV34();
    }
    public void loadLV64()
    {
        loadLV18();
    }

    public void loadLV65()
    {
        loadLV25();
    }

    public void loadLV66()
    {
        loadLV31();
    }
    public void loadLV67()
    {
        loadLV38();
    }
    public void loadLV68()
    {
        loadLV42();
    }
    public void loadLV69()
    {
        loadLV33();
    }

    public void loadLV70()
    {
        loadLV40();
    }

    public void loadLV71()
    {
        loadLV26();
    }
















    //lv21- quay hon 1 vong thi dung" lai
    //lv22 - quay deu" - nhieu" dao

    // Quay deu'



    public GameObject getWoodParticleTrigger(Vector3 point)
    {

        //   point.z = 5;
        foreach (GameObject objectParticle in woodParticleTrigger)
        {

            if (!objectParticle.activeInHierarchy)
            {
                objectParticle.SetActive(true);
                //    objectParticle.transform.position = point;
                return null;
            }
        }



        woodParticleTrigger.Add(Instantiate(woodImpact, point, Quaternion.Euler(0, 0, 0)));
        return null;
    }

    

    //quay deu"
    void RotateR1()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR1);
    }

    void RotateL1()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL1);
    }

    //quay 1 goc hoac vai vong" roi dung" lai
    void RotateR2()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR2);
            rotateR += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR2A);
            rotateR = 0;
        }
    }
   
    void RotateR2A()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR2).setEaseOutSine();
    }

    void RotateL2()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL2);
            rotateL += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL2A);
            rotateL = 0;
        }
    }

    void RotateL2A()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL2).setEaseOutSine();
    }


    

    //quay n vong roi" doi chieu. lv7

    void Rotate3()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(Rotate3);
            rotateR += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(Rotate3B).setEaseOutSine();
            rotateR =0;
        }
    }
    void Rotate3B()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate3B);
            rotateL += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate3).setEaseOutSine();
            rotateL = 0;
        }
    }

    // quay  1 goc nho? roi doi? chieu" quay 2-3 vong.
    void RotateL4()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL4A).setEaseOutSine();

    }

    void RotateL4A()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL4A);
            rotateR += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL4).setEaseOutSine();
            rotateR = 0;

        }

    }
    //quay 1 goc nho, roi quay n vong ngc lai
    void RotateR4()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR4A).setEaseOutSine();

    }

    void RotateR4A()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject,- Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR4A);
            rotateL += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject,- Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR4).setEaseOutSine();
            rotateL = 0;

        }

    }


    //quay 2 vong roi" doi chieu. lv8

  
   
 

    // quay 1 goc nho? roi dung lai lac' lac' == AppltRotate24
 
    void RotateR8()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR8A);
    }

    void RotateR8A()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR8B);
    }
    void RotateR8B()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR8);
    }


    void RotateL8()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL8A);
    }

    void RotateL8A()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL8B);
    }
    void RotateL8B()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL8);
    }

    //lac trai 1 cai roi quay phai.== ApplyRotation25
    void RotateL9()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(RotateL9A).setEaseOutSine();
    }

    void RotateL9A()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL9A);
            rotateL += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL9).setEaseOutSine();
            rotateL = 0;
        }
     }

    void RotateR9()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x).setOnComplete(RotateR9A).setEaseOutSine();
    }

    void RotateR9A()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR9A);
            rotateR += 1;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR9).setEaseOutSine();
            rotateR = 0;
        }
    }

    // lac trai, lac phai, roi quay trai. lac phai, lac trai roi quay phai = applyrotation 12
    void Rotate5()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(Rotate5A).setEaseOutSine();

    }

    void Rotate5A()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate5B).setEaseOutSine();

    }

    void Rotate5B()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x/2).setOnComplete(Rotate5B);
            rotateL += 1;
        }
        else
        {
            rotateL = 0;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x/2).setOnComplete(Rotate5C).setEaseOutSine();
        }
    }
    void Rotate5C()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate5D).setEaseOutSine();

    }
    void Rotate5D()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x).setOnComplete(Rotate5E).setEaseOutSine();

    }
    void Rotate5E()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x/2).setOnComplete(Rotate5E);
            rotateR += 1;
        }
        else
        {
            rotateR = 0;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x/2).setOnComplete(Rotate5).setEaseOutSine();
        }
    }
    // = ApplyRotation15
    void RotateL6()
    {
        if (rotateL < 2)
        {
            rotateL += 1;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.y).setOnComplete(RotateL6);
        }
        else if (rotateL < numberL)
        {
            rotateL += 1;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x).setOnComplete(RotateL6);
        }
        else
        {
            rotateL = 0;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x).setOnComplete(RotateL6).setEaseOutSine();
        }
    }
    void RotateR6()
    {
        if (rotateR <2)
        {
            rotateR += 1;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.y).setOnComplete(RotateR6);
        }
        else if (rotateR < numberR)
        {
            rotateR += 1;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x).setOnComplete(RotateR6);
        }
        else
        {
            rotateR = 0;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x).setOnComplete(RotateR6).setEaseOutSine();
        }
    }

    //=ApplyRotation20 , lac trai, lac phai, roi lac trai. lac phai, lac trai roi quay phai
    void RotateL7()
    {
        if (rotateL == 2)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.y).setOnComplete(RotateL7B).setEaseOutSine();
            rotateL = 0;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.y).setOnComplete(RotateL7A).setEaseOutSine();
            rotateL += 1;
        }
    }

    void RotateL7A()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(RotateL7).setEaseOutSine();

    }

    void RotateL7B()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x/2).setOnComplete(RotateL7B);
            rotateR += 1;
        }
        else
        {
            rotateR = 0;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.x/2).setOnComplete(RotateL7).setEaseOutSine();
        }
    }


    void RotateR7()
    {
        if (rotateR == 2)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.y).setOnComplete(RotateR7B).setEaseOutSine();
            rotateR = 0;
        }
        else
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.y).setOnComplete(RotateR7A).setEaseOutSine();
            rotateR += 1;
        }
    }

    void RotateR7A()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(RotateR7).setEaseOutSine();

    }

    void RotateR7B()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x/2).setOnComplete(RotateR7B);
            rotateL += 1;
        }
        else
        {
            rotateL = 0;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.x/2).setOnComplete(RotateR7).setEaseOutSine();
        }
    }

    // lac trai, lac phai, roi quay trai. lac phai, lac trai roi quay phai
    void Rotate10()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.x, timeV.y).setOnComplete(Rotate10A).setEaseOutSine();

    }
    
    void Rotate10A()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate10B).setEaseOutSine();

    }

    void Rotate10B()
    {
        if (rotateL < numberL)
        {
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x).setOnComplete(Rotate10B);
            rotateL += 1;
        }
        else
        {
            rotateL = 0;
            LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.x).setOnComplete(Rotate10C).setEaseOutSine();
        }
    }
    void Rotate10C()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.x, timeV.y).setOnComplete(Rotate10D).setEaseOutSine();

    }
    void Rotate10D()
    {
        LeanTween.rotateAroundLocal(gameObject, -Vector3.up, gocV.y, timeV.y).setOnComplete(Rotate10E).setEaseOutSine();

    }
    void Rotate10E()
    {
        if (rotateR < numberR)
        {
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x).setOnComplete(Rotate10E);
            rotateR += 1;
        }
        else
        {
            rotateR = 0;
            LeanTween.rotateAroundLocal(gameObject, Vector3.up, gocV.y, timeV.x).setOnComplete(Rotate10).setEaseOutSine();
        }
    }

}

