using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class GameProcessController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Controllers;

    [SerializeField]
    private GameObject theEndTest;

    private float cntdnw = 5f;

    private bool isEnded = false;


    private void Update()
    {
        if (isProcess(Controllers) && isEnded == false)
        {
            theEndTest.SetActive(true);
            if (cntdnw > 0)
                cntdnw -= Time.deltaTime;
            else
                SceneManager.LoadScene(0);

        }
    }

    private bool isProcess(GameObject[] controllers)
    {
        foreach (var controller in controllers) {
            if (!controller.GetComponent<ResistanceÑontrol>().completed) {
                return false;
            }
        }
        return true;
    }

}
