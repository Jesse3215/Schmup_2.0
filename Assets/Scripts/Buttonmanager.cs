using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{
    public void ChangeScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
