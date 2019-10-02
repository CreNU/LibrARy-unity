using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("서버요청중...");


        StartCoroutine(GetBookList("언론"));

    }


    IEnumerator GetBookList(string BookTitle) // 책이름->정보
    {
        UnityWebRequest req = UnityWebRequest.Get("http://106.10.36.117:31415/jbnu?q=" + BookTitle);
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError) // 서버 요청 오류
        {
            Debug.Log(req.error);
            Debug.Log("서버에 연결할 수 없습니다 ㅠㅠ");
        }
        else // 쿼리 성공
        {
            string json = Encoding.Default.GetString(req.downloadHandler.data);
            JArray books = JArray.Parse(json);

            if (books.Count == 0)
            {
                Debug.Log("검색결과없음");
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    string title     = books[i]["title"].ToString();     // 제목
                    string author    = books[i]["author"].ToString();    // 저자
                    string publisher = books[i]["publisher"].ToString(); // 출판사
                    string symbol    = books[i]["symbol"].ToString();    // 십진분류법 기호
                    bool canBorrow   = (bool)books[i]["canBorrow"]; // 대출가능여부 (true=대출가능)
                    bool success     = (bool)books[i]["success"];   // AR 사용가능여부
                    int floor, shelf, pos, dir, col, row; // 책 위치 정보

                    // success가 false이면 DB에서 책 위치를 찾을 수 없음
                    // 즉, AR에서 보여줄 수 없음. 아직 위치등록안된 책이 많음

                    // 쿼리날릴때 책 제목을 "언론"으로 날리셈
                    // 등록된것도 있거 아닌것도 있고 테스트하기 좋음

                    Debug.Log(title);
                    Debug.Log(canBorrow);
                    
                    if (success) // AR 이용가능
                    {
                        floor = (int)books[i]["floor"];
                        shelf = (int)books[i]["shelf"];
                        pos   = (int)books[i]["pos"];

                        if (pos <= 66) // left
                        {
                            dir = 1; // left
                            row = pos % 6;
                            col = (int)System.Math.Ceiling((double)pos / 6);
                        }
                        else // right
                        {
                            pos -= 66;
                            dir = 2; // right

                            row = pos % 6;
                            col = (int)System.Math.Ceiling((double)pos / 6);
                            col = 11 - col + 1; // 뒤집기
                        }

                        // dir은 왼쪽/오른쪽 구분
                        // 왼쪽이 1이고 오른쪽이 2임
                        
                        Debug.Log("row= " + row + ", col= " + col + ", dir= " + dir);
                    }
                }
            }
        }
    }


   

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test");
    }
}
