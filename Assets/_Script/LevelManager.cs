using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;


    [SerializeField]
    GameObject enemyClone;
    [SerializeField]
    GameObject knifeObjectRoot;
    [SerializeField]
    GameObject appleObjectRoot;

    [SerializeField]
    GameObject apple1ObjectRoot;
    float subColliderKnifeY, subColliderKnifeZ;
    

    List<int> listKnife1;
    List<int> listKnife2;
    List<int> listKnife3;


    List<int> listApple1;
    List<int> listApple2;
    List<int> listApple3;

    int levelPlay;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        subColliderKnifeY = 0.41f;
        subColliderKnifeZ = 0.6f;
        listKnife1 = new List<int>();
        listKnife2 = new List<int>();
        listKnife3 = new List<int>();

        listApple1 = new List<int>();
        listApple2 = new List<int>();
        listApple3 = new List<int>();

    }


    public void LoadLv(int level)
    {
        levelPlay = level;
        listKnife1.Clear();
        listKnife2.Clear();
        listKnife3.Clear();
        listApple1.Clear();
        listApple2.Clear();
        listApple3.Clear();


        Invoke("GetLv" + level, 0);

        Invoke("SpawnLevel", 0.0001f);
    }
    void SpawnLevel()
    {
        float rd = Random.value;

        if (rd < 0.33f)
        {
            SpawnAllKnifeInE(listKnife1);
            SpawnAllAppleInE(listApple1);
        }
        else if (rd < 0.66f)
        {
            SpawnAllKnifeInE(listKnife2);
            SpawnAllAppleInE(listApple2);
        }
        else
        {
            SpawnAllKnifeInE(listKnife3);

            SpawnAllAppleInE(listApple3);
        }

        listKnife1.Clear();
        listKnife2.Clear();
        listKnife3.Clear();
        listApple1.Clear();
        listApple2.Clear();
        listApple3.Clear();
    }

    void AddLK1(int[] a)
    {

        foreach (int val in a)
            listKnife1.Add(val);
    }

    void AddLK2(int[] a)
    {
        foreach (int val in a)
            listKnife2.Add(val);
    }

    void AddLK3(int[] a)
    {
        foreach (int val in a)
            listKnife3.Add(val);
    }

    void AddLA1(int[] a)
    {
        foreach (int val in a)
            listApple1.Add(val);
    }
    void AddLA2(int[] a)
    {
        foreach (int val in a)
            listApple2.Add(val);
    }

    void AddLA3(int[] a)
    {
        foreach (int val in a)
            listApple3.Add(val);
    }


    public void GetLv1()
    {
        listApple1.Add(Random.Range(1, 8));



    }

    public void GetLv2()
    {
        listKnife1.Add(Random.Range(1, 8));
        listApple1.Add(Random.Range(1, 8));

        AddLK2(new int[] { Random.Range(1, 8) });
        AddLA2(new int[] { Random.Range(1, 8) });

        AddLK3(new int[] { 1, 2 });
        AddLA3(new int[] { 7, 8 });




    }

    public void GetLv3()
    {

        AddLK1(new int[] { Random.Range(1, 8) });
        AddLA1(new int[] { 5, 6 });

        AddLK2(new int[] { 1, Random.Range(2, 8) });
        AddLA2(new int[] { 3, 5, 6 });

        AddLK3(new int[] { 1, 2 });
        AddLA3(new int[] { 7, 8 });

    }

    public void GetLv4()
    {
        AddLK1(new int[] { 1, 2 });
        AddLA1(new int[] { Random.Range(1, 8) });

        AddLK2(new int[] { 2, 5, 6 });
        AddLA2(new int[] { 3, 4 });

        AddLK3(new int[] { 4, 5 });
        AddLA3(new int[] { 6, 7 });
    }
    public void GetLv5()
    {
        AddLA1(new int[] { 3, 4, 7, 8 });


        AddLK2(new int[] { 1, 3, 2 });
        AddLA2(new int[] { 1, 2, 3, 4 });

        AddLA3(new int[] { 5, 6, 7, 8 });
    }

    public void GetLv6()
    {
        AddLK1(new int[] { 5, 6, 7, 8 });


        AddLK2(new int[] { 1, 3, 2, 4 });
        AddLA2(new int[] { Random.Range(1, 8) });

        AddLK3(new int[] { 1, 2, 3, 4 });

    }

    public void GetLv7()
    {
        AddLK1(new int[] { 1, 2 });


        AddLK2(new int[] { 5, 6 });


        AddLK3(new int[] { 6, 8 });

    }
    public void GetLv8()
    {
        AddLK1(new int[] { 1, 3, 4 });
        AddLA1(new int[] { 3, 4, 7, 8 });

        AddLK2(new int[] { 1, 7, 8 });
        AddLA2(new int[] { 2, 5, 6 });

        AddLK3(new int[] { 6, 7, 8 });
        AddLA3(new int[] { 1, 5, 8 });
    }
    public void GetLv9()
    {
        AddLK1(new int[] { Random.Range(1, 8) });

        AddLK2(new int[] { 1, 7, 8, 4 });

        AddLK3(new int[] { 1, 2, 6, 8 });

    }
    public void GetLv10()
    {
        AddLK1(new int[] { Random.Range(1, 8) });
        AddLA1(new int[] { 1, 2, 3, 4, 5, 6, 7 });

        AddLK2(new int[] { Random.Range(1, 4), Random.Range(5, 8) });
        AddLA2(new int[] { 1, 2, 3, 4, 5, 6, 7 });

        AddLK3(new int[] { 1 });
        AddLA3(new int[] { 2, 3, 4, 5, 6, 7, 8 });

    }
    public void GetLv11()
    {
        AddLK1(new int[] { 1, 2 });


        AddLK2(new int[] { 1, 5 });


        AddLK3(new int[] { 1, 7 });


    }

    public void GetLv12()
    {
        AddLK1(new int[] { 3, 4 });


        AddLK2(new int[] { 7, 8 });


        AddLK3(new int[] { 2, 5, 6 });

    }

    public void GetLv13()
    {
        AddLK1(new int[] { 4, 5, 8 });
        AddLA1(new int[] { 1, Random.Range(2, 8) });

        AddLK2(new int[] { 1, 3, 4 });
        AddLA2(new int[] { 1, Random.Range(2, 8) });

        AddLK3(new int[] { 2, 5, 7 });
        AddLA3(new int[] { 1, Random.Range(2, 8) });

    }

    public void GetLv14()
    {
        AddLA1(new int[] { 1, 2, 3 });


        AddLA2(new int[] { 5, 6, 7 });


        AddLA3(new int[] { 1, 2, 8 });


    }

    public void GetLv15()
    {

        AddLA1(new int[] { 1, 2, 5, 6, 3 });


        AddLA2(new int[] { 1, 3, 5, 6, 8 });

        AddLK3(new int[] { 1, 2, 3 });
        AddLA3(new int[] { 1, 2, 5, 6 });

    }
    public void GetLv16()
    {
        AddLA1(new int[] { Random.Range(1, 8) });
    }
    public void GetLv17()
    {

        AddLK1(new int[] { Random.Range(1, 8) });
        AddLA1(new int[] { 1, 2, 5, 6 });

        AddLK2(new int[] { Random.Range(1, 8) });
        AddLA2(new int[] { 1, 2, 3, 4 });

        AddLK3(new int[] { 1, 2 });
        AddLA3(new int[] { 1, 2, 7, 8 });

    }

    public void GetLv18()
    {
        AddLK1(new int[] { 1, 2 });
        AddLK2(new int[] { 1, 8 });
        AddLK3(new int[] { 1, 2, 8 });
    }

    public void GetLv19()
    {
        AddLK1(new int[] { 1, 3, 4 });
        AddLK2(new int[] { 1, 7, 8 });
        AddLK3(new int[] { 1, 2, 8 });

    }
    public void GetLv20()
    {
        AddLA1(new int[] { 1, 2, 3, 4, 5, 6 });

        AddLK2(new int[] { 1 });
        AddLA2(new int[] { 1, 2, 3, 4, 5, 6 });

        AddLK3(new int[] { 1, 7 });
        AddLA3(new int[] { 1, 2, 7, 8, 3, 6 });

    }

    public void GetLv21()
    {

        AddLK1(new int[] { Random.Range(1, 8) });


        AddLK2(new int[] { Random.Range(1, 8) });


        AddLK3(new int[] { Random.Range(1, 8) });


    }

    public void GetLv22()
    {

        AddLK1(new int[] { 1, 2 });


        AddLK2(new int[] { 1, 7 });


        AddLK3(new int[] { 7, 8 });


    }

    public void GetLv23()
    {

        AddLK1(new int[] { 1, 2, 3, 4 });


        AddLK2(new int[] { 1, 8, 2, 6 });
        AddLA2(new int[] { Random.Range(1, 8) });

        AddLK3(new int[] { 1, 4, 7, 8 });


    }


    public void GetLv24()
    {

        AddLK1(new int[] { 1, 2, 3 });


        AddLK2(new int[] { 1, 8, 2, 6 });
        AddLA2(new int[] { Random.Range(1, 8) });

        AddLK3(new int[] { 1, 4, 7, 8 });

    }

    public void GetLv25()
    {

        AddLA1(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        AddLA2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        AddLA3(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });

    }
    public void GetLv26()
    {

        AddLK1(new int[] { 1, 2 });
        AddLK2(new int[] { 1, 2, 3 });
        AddLK3(new int[] { 1, 8 });

    }

    public void GetLv27()
    {

        AddLK1(new int[] { 3, 4 });
        AddLK2(new int[] { 1, 7, 8 });
        AddLK3(new int[] { 7, 8 });

    }
    public void GetLv28()
    {

        AddLK1(new int[] { 3, 4 });
        AddLK2(new int[] { 1, 7, 8 });
        AddLK3(new int[] { 7, 8 });

    }

    public void GetLv29()
    {
        AddLK1(new int[] { 3, 4, 6 });
        AddLK2(new int[] { 1, 7, 8 });
        AddLK3(new int[] { 7, 8, 2 });
        AddLA3(new int[] { 1, 7, 8 });

    }

    public void GetLv30()
    {
        AddLA1(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        AddLA2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        AddLA3(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });


    }
    public void GetLv31()
    {
        AddLK1(new int[] { 3, 4, 6 });
        AddLK2(new int[] { Random.Range(1, 8) });
        AddLK3(new int[] { Random.Range(1, 8) });
    }
    public void GetLv32()
    {
        AddLK1(new int[] { 1, 2, 3, 4 });
        AddLK2(new int[] { 5, 6, 7, 8 });
        AddLK3(new int[] { 1, 4, 7, 8 });
    }

    public void GetLv33()
    {
        AddLK1(new int[] { 3, 4, 6 });
        AddLA1(new int[] { 1, 2, });

        AddLK2(new int[] { 2, 3, 4 });
        AddLA2(new int[] { 1 });

        AddLK3(new int[] { 1, 7, 8 });
    }

    public void GetLv34()
    {
        AddLK1(new int[] { 3, 4, 6 });
        AddLK2(new int[] { 7, 8 });
        AddLA2(new int[] { 1 });
        AddLK3(new int[] { 8, 2 });
        AddLA3(new int[] { 8 });
    }

    public void GetLv35()
    {
        AddLA1(new int[] { 1, 2, 3, 4, 5 });

        AddLA2(new int[] { 1, 3, 4, 6, 7 });

        AddLK3(new int[] { 8, 2, 1 });
        AddLA3(new int[] { 5, 6, 7, 8 });
    }

    public void GetLv36()
    {
        AddLK1(new int[] { 1, 2, 6, 8 });
        AddLK2(new int[] { 1, 2, 7, 8 });
        AddLK3(new int[] { 5, 6, 7, 8 });
    }

    public void GetLv37()
    {
        AddLK1(new int[] { 3, 4, 6 });
        AddLK2(new int[] { 7, 8 });
        AddLA2(new int[] { 1 });
        AddLK3(new int[] { 8, 2 });
        AddLA3(new int[] { 8 });
    }

    public void GetLv38()
    {
        AddLK1(new int[] { 1, 3, 4 });


        AddLA2(new int[] { 1, 2, 5, 6, 7, 8 });

        AddLK3(new int[] { 8, 7, 2 });
        AddLA3(new int[] { 8, 7 });
    }

    public void GetLv39()
    {
        AddLK1(new int[] { 1, 2 });

        AddLK2(new int[] { 7, 8 });
        AddLA2(new int[] { Random.Range(1, 8) });

        AddLK3(new int[] { 3, 4 });
        AddLA3(new int[] { Random.Range(1, 4), Random.Range(5, 8) });
    }

    public void GetLv40()
    {

        AddLA2(new int[] { Random.Range(1, 8) });

        AddLA3(new int[] { Random.Range(1, 4), Random.Range(5, 8) });
    }

    public void GetLv41()
    {
        AddLK1(new int[] { 1, 2 });

        AddLK2(new int[] { 7, 8 });

        AddLK3(new int[] { 3, 4 });

    }

    public void GetLv42()
    {
        AddLK1(new int[] { 1, 2 });


        AddLA2(new int[] { Random.Range(1, 8) });

        AddLA3(new int[] { Random.Range(1, 4), Random.Range(5, 8) });
    }

    public void GetLv43()
    {
        AddLK1(new int[] { 1, 2, 3 });
        AddLA1(new int[] { 1, 4, 6, 7 });

        AddLK2(new int[] { 1, 2, 6, 8 });


        AddLK3(new int[] { 3, 4, 6, 8 });

    }

    public void GetLv44()
    {
        AddLK1(new int[] { 1, 2 });


        AddLK2(new int[] { 3, 4 });


        AddLK3(new int[] { 6, 8 });

    }

    public void GetLv45()
    {
        AddLK1(new int[] { 1, 2, 3, 4, 5 });
        AddLA1(new int[] { 1, 4, 6, 7 });

        AddLK2(new int[] { 1, 2, 6, 8 });
        AddLA2(new int[] { 1, 2, 5, 6 });

        AddLK3(new int[] { 3, 4, 6, 8 });
        AddLA3(new int[] { 1, 2, 3, 4 });
    }


    public void GetLv46()
    {
        GetLv26();
    }


    public void GetLv47()
    {
        GetLv28();
    }

    public void GetLv49()
    {
        GetLv36();
    }

    public void GetLv50()
    {
        GetLv25();
    }

    public void GetLv51()
    {
        GetLv37();
    }

    public void GetLv52()
    {
        GetLv17();
    }
    public void GetLv53()
    {
        GetLv26();
    }
    public void GetLv54()
    {
        GetLv42();
    }

    public void GetLv55()
    {
        GetLv20();
    }

    public void GetLv56()
    {
        GetLv33();
    }
    public void GetLv57()
    {
        GetLv43();
    }

    public void GetLv58()
    {
        GetLv25();
    }
    public void GetLv59()
    {
        GetLv16();
    }

    public void GetLv60()
    {
        GetLv30();
    }

    public void GetLv61()
    {
        GetLv18();
    }

    public void GetLv62()
    {
        GetLv32();
    }

    public void GetLv63()
    {
        GetLv21();
    }
    public void GetLv64()
    {
        GetLv13();
    }

    public void GetLv65()
    {
        GetLv25();
    }

    public void GetLv66()
    {
        GetLv31();
    }

    public void GetLv67()
    {
        GetLv19();
    }

    public void GetLv68()
    {
        GetLv29();
    }

    public void GetLv69()
    {
        GetLv39();
    }

    public void GetLv70()
    {
        GetLv15();
    }


    public void SpawnAllKnifeInE(List<int> listK)
    {

        foreach (int i in listK)
        {
            SpawnKnifeInEnemy(i);
        }

    }


    public void SpawnAllAppleInE(List<int> listA)
    {
        foreach (int i in listA)
        {
            SpawnAppleInEnemy(i);
        }
    }


    public void SpawnKnifeInEnemy(int pos)
    {

        GameObject KnifeObjectClone;
        switch (pos)
        {
            case 1:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.2f), Quaternion.Euler(0, 0, -90));

                break;
            case 2:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.176f), Quaternion.Euler(0, -180, -90));

                break;
            case 3:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x + 0.23f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z), Quaternion.Euler(0, 90, -90));

                break;
            case 4:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x - 0.225f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z), Quaternion.Euler(0, -90, -90));

                break;
            case 5:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x - 0.1581f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.1626f), Quaternion.Euler(0, -135, -90));

                break;
            case 6:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x + 0.1848f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.1814f), Quaternion.Euler(0, 135, -90));

                break;
            case 7:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x + 0.146f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.149f), Quaternion.Euler(0, 45, -90));

                break;

            default:
                KnifeObjectClone = Instantiate(knifeObjectRoot, new Vector3(enemyClone.transform.position.x - 0.14805f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.15165f), Quaternion.Euler(0, -45, -90));

                break;
        }

        KnifeObjectClone.name = "Knife0" + pos;
        Transform transformKnife = KnifeObjectClone.GetComponent<Transform>();
        transformKnife.SetParent(enemyClone.transform);
        BoxCollider knifeCollider = KnifeObjectClone.GetComponent<BoxCollider>();
        knifeCollider.center = new Vector3(knifeCollider.center.x, knifeCollider.center.y, knifeCollider.center.z + 0.3399945f);
        knifeCollider.size = new Vector3(knifeCollider.size.x, knifeCollider.size.y - subColliderKnifeY, knifeCollider.size.z - subColliderKnifeZ);
        Destroy(KnifeObjectClone.GetComponent<Knife>());
        Destroy(KnifeObjectClone.GetComponent<Rigidbody>());
    }


    public void SpawnAppleInEnemy(int pos)
    {
        float rd;
        if (levelPlay > 15)
        {
            rd = Random.value;
        }
        else
        {
            rd = 1;
        }
        GameObject appleObjectClone;
        if (rd>0.5f)
        {
            switch (pos)
            {
                case 1:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x - 0.089f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.21f), Quaternion.Euler(-90, 25, 0));
                    break;
                case 2:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x + 0.095f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.223f), Quaternion.Euler(-90, -25, 0));

                    break;
                case 3:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x + 0.078f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.208f), Quaternion.Euler(90, 0, -25));

                    break;
                case 4:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x - 0.078f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.208f), Quaternion.Euler(90, 0, 25));

                    break;
                case 5:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x - 0.227f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.089f), Quaternion.Euler(90, 0, 115));

                    break;
                case 6:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x + 0.227f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.089f), Quaternion.Euler(90, 0, -115));

                    break;
                case 7:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x + 0.235f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.102f), Quaternion.Euler(90, 0, -70));

                    break;

                default:
                    appleObjectClone = Instantiate(appleObjectRoot, new Vector3(enemyClone.transform.position.x - 0.235f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.102f), Quaternion.Euler(90, 0, 70));

                    break;
            }
        }
        else
        {

            switch (pos)
            {
                case 1:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x - 0.089f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.21f), Quaternion.Euler(-90, 25, 0));
                    break;
                case 2:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x + 0.095f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.223f), Quaternion.Euler(-90, -25, 0));

                    break;
                case 3:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x + 0.078f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.208f), Quaternion.Euler(90, 0, -25));

                    break;
                case 4:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x - 0.078f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.208f), Quaternion.Euler(90, 0, 25));

                    break;
                case 5:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x - 0.227f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.089f), Quaternion.Euler(90, 0, 115));

                    break;
                case 6:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x + 0.227f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z - 0.089f), Quaternion.Euler(90, 0, -115));

                    break;
                case 7:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x + 0.235f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.102f), Quaternion.Euler(90, 0, -70));

                    break;

                default:
                    appleObjectClone = Instantiate(apple1ObjectRoot, new Vector3(enemyClone.transform.position.x - 0.235f, enemyClone.transform.position.y + 0.08f, enemyClone.transform.position.z + 0.102f), Quaternion.Euler(90, 0, 70));

                    break;
            }
        }
        appleObjectClone.name = "Apple0" + pos;

        Transform transformApple = appleObjectClone.GetComponent<Transform>();
        transformApple.SetParent(enemyClone.transform);

    }



}
