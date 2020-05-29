using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    bool runningRoutine1 = false;
    bool runningRoutine2 = false;


    static AudioSource audio;
    public static AudioClip passarinho;
    public static AudioClip passarinho2;
    public static AudioClip passarinho3;
    public static AudioClip passarinho4;
    // Start is called before the first frame update
    void Start()
    {
         audio = GetComponent<AudioSource>();
         passarinho = Resources.Load<AudioClip>("13");
         passarinho2 = Resources.Load<AudioClip>("29");
         passarinho3 = Resources.Load<AudioClip>("22");
         passarinho4 = Resources.Load<AudioClip>("04");
         
    }

    // Update is called once per frame
    void Update()
    {

        //passarinhos cantando
        if (runningRoutine1 == false){
            StartCoroutine(Timer1());
        }
        if (runningRoutine2 == false){
            StartCoroutine(Timer2());
        }
        
        
    }


    IEnumerator Timer1() {
        runningRoutine1 = true;
        yield return new WaitForSeconds(1.5f);
        audio.clip = passarinho2;
        audio.Play();
        yield return new WaitForSeconds(4.3f);
        audio.clip = passarinho4;
        audio.Play();
        //passarinho1.Stop();
        runningRoutine1 = false;
        
    } 

    IEnumerator Timer2() {
        runningRoutine2 = true;
        yield return new WaitForSeconds(3.3f);
        audio.clip = passarinho;
        audio.Play();
        yield return new WaitForSeconds(2.1f);
        audio.clip = passarinho3;
        audio.Play();
        runningRoutine2 = false;
        //passarinho2.Stop();

        
    } 
}
