using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(15, 15, 15));
     
    }

}
