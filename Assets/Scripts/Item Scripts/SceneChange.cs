using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject enterText;
    public string levelToLoad;

    public string centralReroute;

    void Start()
    {
        if (enterText != null)
        {
            enterText.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterText.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                Pause();
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(5);
    }

    public void CentralReroute()
    {
        Pause();
        SceneManager.LoadScene(centralReroute);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && enterText != null)
        { 
            enterText.SetActive(false);
        }
    }
}
