using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    public void Startfirstlevel()
    {
        SceneManager.LoadScene(1);
    }
    public void loadmainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
