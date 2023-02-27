using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    GameObject appleBreakObject;
    bool isBreak;
    // Start is called before the first frame update
    private void Awake()
    {
        isBreak = false;
    }
    
    // Update is called once per frame
   
    private void OnTriggerEnter(Collider other)
    {
      
        if (!isBreak)
            if (other.gameObject.CompareTag("Knife"))
            {

                isBreak = true;
                GamePlay.Instance.AddApple(1); 
                Vector3 breakPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Instantiate(appleBreakObject, breakPosition, transform.rotation);              
                GamePlay.Instance.SetSoundAOrE(true);
                Destroy(gameObject);
            }

    }



}
