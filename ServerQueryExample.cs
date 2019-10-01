using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

static class Server
{
    public const string baseUrl = "http://18.215.254.153:3000/";
    public const string libName = "jbnu";

    public static string GetSearchUrl(string bookName)
    {
        return baseUrl + libName + "/search?q=" + bookName;
    }

    public static string GetPositionUrl(string bookSymbol)
    {
        return baseUrl + libName + "/pos?q=" + bookSymbol;
    }
}

// ############### Newtonsoft.Json 에셋 추가해야됨 // 라이선스 MIT


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("서버요청중...");
        //StartCoroutine(GetBookList("언론"));

        StartCoroutine(GetShelfPos("070 테스트"));

    }


    IEnumerator GetBookList(string BookTitle) // 책이름->정보
    {
        UnityWebRequest req = UnityWebRequest.Get(Server.GetSearchUrl(BookTitle));
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError) // 서버 요청 오류
        {
            Debug.Log(req.error);
        }
        else
        {
            // 서버 쿼리 성공
            string json = Encoding.Default.GetString(req.downloadHandler.data);

            JArray books = JArray.Parse(json);
            Debug.Log(books.Count); // 카운트

            if (books.Count == 0)
            {
                Debug.Log("검색결과없음");
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    Debug.Log(books[i]["title"]); // 책 제목
                    Debug.Log(books[i]["author"]); // 저자
                    Debug.Log(books[i]["publisher"]); // 출판사
                    Debug.Log(books[i]["symbol"]); // 십진분류법 기호 ===> 나중에 책장위치 쿼리할때 이거 사용함
                    Debug.Log(books[i]["state"]); // 대출가능여부 true=대출가능
                }
            }
        }
    }




    IEnumerator GetShelfPos(string BookSymbol) // 십진분류기호->책장위치
    {
        UnityWebRequest req = UnityWebRequest.Get(Server.GetPositionUrl(BookSymbol));
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError) // 서버 요청 오류
        {
            Debug.Log(req.error);
        }
        else
        {
            // 서버 쿼리 성공
            string json = Encoding.Default.GetString(req.downloadHandler.data);

            JObject info = JObject.Parse(json);
            
            if ((int)info["floor"] == -1)
            {
                Debug.Log("찾을 수 없음");
            }
            else
            {
                Debug.Log("층=       " + info["floor"]);  // 2층 고정
                Debug.Log("책장번호= " + info["shelf"]);  // 5번 책장 고정 (책장 하나만 했음)
                Debug.Log("칸=      " + info["pos"]);    // 1 ~ 66

                int idx, row, col, dir;
                idx = (int)info["pos"];
          
                if (idx <= 66) // left
                {
                    dir = 1; // left
                    row = idx % 6;
                    col = (int)System.Math.Ceiling((double)idx / 6);
                }
                else // right
                {
                    idx -= 66;
                    dir = 2; // right

                    row = idx % 6;
                    col = (int)System.Math.Ceiling((double)idx / 6);
                    col = 11 - col + 1; // 뒤집기
                }

                Debug.Log("row= " + row + ", col= " + col + ", dir= " + dir);
            }
            

        }
    }






    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
    }
}
