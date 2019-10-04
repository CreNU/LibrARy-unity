using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDownEvent : MonoBehaviour
{

    public void NextScense()
    {

        SceneManager.LoadScene("LibARIMG");
    }

}
