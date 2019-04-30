using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    private NavMeshAgent navAgent;

    public float health = 0f;
    public float anxiety = 5f;

    public bool is_Player;

    private bool is_Dead;

    private PlayerStats player_Stats;

    private string central_Reroute;

    // Start is called before the first frame update
    void Awake()
    {
        if(is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();
        }
    }

    void Update()
    {
        if (health <= 100f)
        {
            ApplyAnxiety();
        }
    }

    public void ApplyAnxiety()
    {
        /*
        if (is_Dead)
        {
            return;
        }
        */
        if (is_Player)
        {
            //displays the anxiety bar
            player_Stats.Display_HealthStats(health);
        }

        if (health >= 100f)
        {
            PlayerDied();
            is_Dead = true;
            RestartGame();
        }
        if (health < 100f)
        {
            health += (anxiety / 2f) * Time.deltaTime;
            player_Stats.Display_HealthStats(health);
        }
    }

    void PlayerDied()
    {
        if (is_Player)
        {
            // all npcs in the game
            GameObject[] npcs = GameObject.FindGameObjectsWithTag("Interactable Object");
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].GetComponent<EnemyController>().enabled = false;
                //npcs[i].SetActive(false);
            }

            // simulates player has died
            GetComponent<PlayerMovement>().enabled = false;
        }

        if(tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }

        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(central_Reroute);
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
}
