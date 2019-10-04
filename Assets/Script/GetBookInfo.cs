using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System;

public class GetBookInfo : MonoBehaviour
{
    public GameObject Parent;
    public GameObject ScrollView;
    public GameObject ParentCont;
    public GameObject BtnItem;
    GameObject ContentClone;
    public GameObject lodingObject;

    public static int BooksCount = 0;
    public static List<string> BooksTitle = new List<string>();
    public static List<int> BooksDir = new List<int>();
    public static List<int> BooksRow = new List<int>();
    public static List<int> BooksCol = new List<int>();
    public static List<bool> BooksAR = new List<bool>();

    public void StartSetColne()
    {
        ContentClone = Instantiate(Parent, ParentCont.transform);
        ContentSizeFitter CloneContentSize = ContentClone.GetComponent<ContentSizeFitter>();
        CloneContentSize.enabled = true;

        VerticalLayoutGroup CloneVerticalLayoutGroup = ContentClone.GetComponent<VerticalLayoutGroup>();
        CloneVerticalLayoutGroup.enabled = true;

        RectTransform ScrollrecTrans = ContentClone.GetComponent<RectTransform>();
        ScrollView.GetComponent<ScrollRect>().content = ScrollrecTrans;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSetColne();
    }


    public void StartSearchCoroutine(string Text)
    {
        Destroy(ContentClone);
        StartSetColne();
        lodingObject.SetActive(true);
        StartCoroutine(GetBookList(Text));
    }


    IEnumerator GetBookList(string BookTitle) // 책이름->정보
    {
        GameObject name = BtnItem.transform.GetChild(0).gameObject;
        GameObject writer = BtnItem.transform.GetChild(1).gameObject;
        GameObject publish = BtnItem.transform.GetChild(2).gameObject;
        GameObject check = BtnItem.transform.GetChild(3).gameObject;

        JArray Books = new JArray();
        UnityWebRequest WebReq = UnityWebRequest.Get("http://106.10.36.117:31415/jbnu?q=" + BookTitle);
        bool IsError = false;
        yield return WebReq.SendWebRequest();

        if (WebReq.isNetworkError || WebReq.isHttpError) // 서버 요청 오류
        {
            Debug.Log(WebReq.error);
            Debug.Log("서버에 연결할 수 없습니다 ㅠㅠ");
        }
        else
        {
            try
            {
                string JSON = Encoding.Default.GetString(WebReq.downloadHandler.data);
                Books = JArray.Parse(JSON);
            }
            catch (Exception e)
            {
                IsError = true;
                Debug.Log(WebReq.downloadHandler.data);
                Debug.Log(e);
            }

            if (IsError == true)
            {
                Debug.Log("JSON 파싱 오류. 이거 뜨면 깃헙 이슈 남겨주셈");
            }
            else if (Books.Count == 0)
            {
                Debug.Log("검색 결과 없음");
            }
            else
            {
                BooksCount = Books.Count;
                for (int i = 0; i < Books.Count; i++)
                {

                    BtnItem.name = i.ToString();
                    name.GetComponent<Text>().text = Books[i]["title"].ToString();     // 제목
                    writer.GetComponent<Text>().text = Books[i]["author"].ToString();    // 저자
                    publish.GetComponent<Text>().text = Books[i]["publisher"].ToString(); // 출판사
                    string symbol = Books[i]["symbol"].ToString();    // 십진분류법 기호
                    bool canBorrow = (bool)Books[i]["canBorrow"]; // 대출가능여부 (true=대출가능)
                    BooksAR.Insert(i,(bool)Books[i]["arAvailable"]);   // AR 사용가능여부
                    BooksTitle.Insert(i,Books[i]["title"].ToString());


                    if (BooksAR[i]) // AR 이용가능
                    {
                        BooksDir.Insert(i,(int)Books[i]["dir"]);
                        BooksRow.Insert(i, (int)Books[i]["row"]);
                        BooksCol.Insert(i, (int)Books[i]["col"]);
                        check.SetActive(true);
                    }
                    else
                    {
                        BooksDir.Insert(i,-1);
                        BooksRow.Insert(i,-1);
                        BooksCol.Insert(i,-1);
                        check.SetActive(false);
                    }

                    Instantiate(BtnItem, ContentClone.transform);

                }
            }

            lodingObject.SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
    }
}
