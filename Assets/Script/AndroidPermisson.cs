using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
using UnityEngine.UI;
#endif


public class AndroidPermisson : MonoBehaviour
{
    GameObject dialog = null;
    public Text Ptext;

    void Start()
    {
        Debug.Log("퍼미션체크");
        Ptext.text = "퍼미션체크1";
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.INTERNET"))
        {
            Debug.Log("퍼미션체크");
            Ptext.text = "퍼미션체크1";
            Permission.RequestUserPermission("android.permission.INTERNET");
            dialog = new GameObject();
        }
        Debug.Log("퍼미션체크");
        Ptext.text = "퍼미션체크1";
#endif
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.INTERNET"))
        {
            Ptext.text = "퍼미션체크2";
            // The user denied permission to use the microphone.
            // Display a message explaining why you need it with Yes/No buttons.
            // If the user says yes then present the request again
            // Display a dialog here.
            dialog.AddComponent<PermissionsDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif

        // Now you can do things with the microphone
    }
}
