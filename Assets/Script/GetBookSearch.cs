using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetBookSearch : MonoBehaviour
{

    public GetBookInfo GetBookforInfo;
    public InputField InputBook;

    public void StartSearch()
    {
        GetBookforInfo.StartSearchCoroutine(InputBook.text.ToString());

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return) && InputBook.text.ToString() != "")
        {
            GetBookforInfo.StartSearchCoroutine(InputBook.text.ToString());
        }
    }
}
