using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sound_manager_script : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jumpSound,background;
    static AudioSource audioSource;
    private float musicVolume = 1f;
   

   
    void Start()
    {
       
        jumpSound = Resources.Load<AudioClip>("jump");
        background = Resources.Load<AudioClip>("Background");

        audioSource = GetComponent<AudioSource>();
    }






    public static void PlaySound(string clip)
    {
        audioSource.PlayOneShot(jumpSound);
    }

   
}
