using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDownEvent : MonoBehaviour
{

    public GameObject search;
    public GameObject popUp;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (search.activeSelf == true)
                {
                    if (popUp.activeSelf == true)
                    {
                        popUp.SetActive(false);
                    }
                    else
                    {
                        search.SetActive(false);
                    }
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }

    public void NextScense()
    {
        SceneManager.LoadScene("LibARIMG");
    }

}
