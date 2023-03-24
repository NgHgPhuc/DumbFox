using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource StartMusic;
    public GameObject SettingMenu;
    private void Start()
    {
        StartMusic.Play();
        
    }

    // Start is called before the first frame update
    [System.Obsolete]
    private void Update()
    {
        if(SettingMenu.active)
        StartMusic.volume = SettingMenu.GetComponent<SettingMenu>().GetVolMount();
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
}
