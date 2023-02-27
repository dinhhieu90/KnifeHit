using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MusicName
{
    bg=0,
    play=1
}
public class MusicManager : MonoBehaviour

{
    public static MusicManager Instance;

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



    public void OnPlayMusic(MusicName musicName)
    {
        var audioClip = Resources.Load<AudioClip>($"Musics/{musicName.ToString()}");
        audioFx.clip = audioClip;
        audioFx.Play();
    }
}
