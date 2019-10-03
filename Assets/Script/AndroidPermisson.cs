using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif


public class AndroidPermisson : MonoBehaviour
{
    GameObject dialog = null;

    void Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.INTERNET"))
        {
            Permission.RequestUserPermission("android.permission.INTERNET");
            dialog = new GameObject();
        }
#endif
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.INTERNET"))
        {
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
