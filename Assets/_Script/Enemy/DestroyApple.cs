using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyApple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAppleBreak", 1.5f);
    }
    public void DestroyAppleBreak()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
   
}
