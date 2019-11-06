using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetBookSearch : MonoBehaviour
{

    public GetBookInfo GetBookforInfo;
    public InputField InputBook;
    public InputField InputBook2;

    public void StartSearch()
    {
        if (InputBook2.text == "")
        {
            GetBookforInfo.StartSearchCoroutine(InputBook.text.ToString());
        }else
        {
            GetBookforInfo.StartSearchCoroutine(InputBook2.text.ToString());
        }


    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return) && InputBook.text.ToString() != "")
        {
            GetBookforInfo.StartSearchCoroutine(InputBook.text.ToString());
        }
    }
}
