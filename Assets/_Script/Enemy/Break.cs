using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    public GameObject fractureObject;
    public static Break Instance;
    //test explode fruit
    public int cubesPerAxis ;
    public float force ;
    public float radius ;
    public Material[] materialBoss;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()

    {
        cubesPerAxis = 6;
        force = 180f;
        radius = 2f;
    }


    public void BreakEnemy(int type)
    {
      
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    
                   
                    CreateCube(new Vector3(x, y, z),type);
                   

                }
            }
        }
      
      EnemyRotate.Instance.CleanEnemyToStand();
        gameObject.SetActive(false);
    }
    void CreateCube(Vector3 coordinates, int type)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = materialBoss[type];

        cube.transform.localScale = transform.localScale / (cubesPerAxis+1);

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);
        cube.AddComponent<DestroyBreakEnemy>();

    }

   

    public void BreakEnemy1()
    {
        Vector3 breakPosition = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        Instantiate(fractureObject, breakPosition, transform.rotation);
        EnemyRotate.Instance.CleanEnemyToStand();
        gameObject.SetActive(false);  

    }
}
