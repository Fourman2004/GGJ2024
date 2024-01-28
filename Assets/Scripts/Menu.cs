using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
//using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button StartButton, QuitButton, BackButton, Controls;
    public Text ControlInfo;
    public AudioClip BadJoke;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.visible = true;
       AudioSource.PlayClipAtPoint(BadJoke,ControlInfo.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

   public void quitGame() 
    { 
        Application.Quit(); 
    }

    public void ShowControlScreen()
    {
        ControlInfo.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(true);
        Controls.gameObject.SetActive(false);
    }
    public void back()
    {
        ControlInfo.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(true);
        Controls.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);

    }

}
