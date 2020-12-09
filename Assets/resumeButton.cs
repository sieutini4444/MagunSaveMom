using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resumeButton : MonoBehaviour
{
    public GameObject CanvasPause;
    public GameObject backg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resumee(){
        CanvasPause.SetActive(false);
        Time.timeScale = 1f;
        backg.GetComponent<AudioSource>().Play();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
