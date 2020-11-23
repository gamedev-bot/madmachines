using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void onPressPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void onPressOptions()
    {
        mainMenu.gameObject.active = false;
        optionsMenu.gameObject.active = true;
    }

    public void onPressOptionsBack()
    {
        mainMenu.gameObject.active = true;
        optionsMenu.gameObject.active = false;
    }
}
