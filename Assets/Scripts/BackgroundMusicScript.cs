using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicScript : MonoBehaviour
{

    public static AudioClip background;
    static AudioSource audioSource;
    private float musicVolume = 1f;
    int buildInt;

    void Start()
    {
       
        
        background = Resources.Load<AudioClip>("Background");

        audioSource = GetComponent<AudioSource>();
        buildInt = SceneManager.GetActiveScene().buildIndex;
    }
    

    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
