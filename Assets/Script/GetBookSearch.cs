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
}
