 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Rotate1();
    }
   
    void Rotate1()
    {
    
        LeanTween.rotateAroundLocal(gameObject, -Vector3.forward, 169, 1).setOnComplete(Rotate1);
      
    }
   
    
}
