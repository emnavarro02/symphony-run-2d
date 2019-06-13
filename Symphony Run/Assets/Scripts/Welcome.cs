using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    [SerializeField]
    private readonly int delay = 0;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))

        if (Input.GetKeyDown(KeyCode.Space))
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) 
        {
            print("Clicked");
            LoadMainScreen();
        }
    }

    private void LoadMainScreen()
    {
        SceneManager.LoadScene(0);
    }
}
