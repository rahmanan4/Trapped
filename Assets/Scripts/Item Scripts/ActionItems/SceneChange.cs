using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject enterText;
    public string levelToLoad;

    void Start()
    {
        enterText.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterText.SetActive(true);
            if(Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterText.SetActive(false);
        }
    }
}
