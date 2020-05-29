using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private float musicVolume = 1f;
    GameObject BackgroundMusic;
    static AudioSource audioSource;


void Start()
    {

        audioSource = BackgroundMusic.GetComponent<AudioSource>();
       
    }
    

public void StartGame()
{   

    //carrega próxima scene ao clicar no botão start
    SceneManager.LoadScene(1);
}


public void QuitGame()
{

    //sai da aplicação ao clicar no botão quit
    Application.Quit();
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
