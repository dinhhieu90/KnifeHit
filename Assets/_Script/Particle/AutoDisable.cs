using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour

{
    public float lifeTime;

    public void OnEnable()
    {
       StartCoroutine( DisableParticle());
    }

    IEnumerator DisableParticle()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }


}
