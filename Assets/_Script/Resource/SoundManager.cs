using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SoundName
{
    throw2 = 0,
    impact = 1,
    impactknife = 2,
    breakwood = 3,
    impactfruit1 = 4,
    click = 5,
    breakfruit3 = 6,
    gameover1=7
}
public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    public AudioSource audioFx;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
            audioFx.playOnAwake = false;
        }
    }



    public void OnPlaySound(SoundName soundName)
    {
        var audioClip = Resources.Load<AudioClip>($"Sounds/{soundName.ToString()}");
        audioFx.PlayOneShot(audioClip);
    }

}
