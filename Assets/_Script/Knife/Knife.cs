using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    //  public static Knife Instance { get; private set; }
    // Start is called before the first frame update
    //cac trang thai cua dao, 1 la dang bay, 2 la ghim vao enemy,3 la trigger voi knife khac
    // GameObject enemyObject;
    BoxCollider knifeCollider;
    bool  isCheckAfter;
    private void Awake()
    {
        knifeCollider = GetComponent<BoxCollider>();
        isCheckAfter = false;
 
    }

    

    private void OnCollisionEnter(Collision collision)
    {

        if (!GamePlay.Instance.GetIsGameOver() && !isCheckAfter)
        {

            if (collision.transform.CompareTag("Knife"))
            {
                isCheckAfter = true;

                SoundManager.Instance.OnPlaySound(SoundName.impactknife);
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;

                // set number knife de? continue
                GamePlay.Instance.SetNumberKnife(EnemyRotate.Instance.GetNumberKIN());

                GamePlay.Instance.GameOver();
                Invoke("DeleteKnife", 0.5f);
            }
            else if (collision.transform.CompareTag("Enemy"))
            {

                isCheckAfter = true;
               
                transform.SetParent(collision.transform, true);
                //fix box collider cua knife- size z 0.92, center z 0.42 
                knifeCollider.center = new Vector3(knifeCollider.center.x, knifeCollider.center.y, knifeCollider.center.z + 0.3399945f);
                knifeCollider.size = new Vector3(knifeCollider.size.x, knifeCollider.size.y - 0.41f, knifeCollider.size.z - 0.6f);
                Destroy(GetComponent<Rigidbody>());
                EnemyRotate.Instance.AddNumberKIN();
                Destroy(GetComponent<Knife>());

            }




        }

    }



    public void DeleteKnife()
    {
        Destroy(gameObject);
    }
}
