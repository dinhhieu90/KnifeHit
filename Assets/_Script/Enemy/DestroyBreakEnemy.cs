using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBreakEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBreakE", 0.9f);
    }

    public void DestroyBreakE()
    {
        Destroy(gameObject);
    }

   
}
