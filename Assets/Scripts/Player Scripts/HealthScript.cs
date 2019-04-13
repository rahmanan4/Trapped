using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private NavMeshAgent navAgent;

    public float health = 100f;

    public bool is_Player;

    private bool is_Dead;

    private PlayerStats player_Stats;

    // Start is called before the first frame update
    void Awake()
    {
        if(is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
        {
            return;
        }

        health -= damage;

        if (is_Player)
        {
            //displays the anxiety bar
            player_Stats.Display_HealthStats(health);
        }

        if (health <= 0f)
        {
            PlayerDied();
            is_Dead = true;
        }
    }

    void PlayerDied()
    {
        if (is_Player)
        {
            // all npcs in the game
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // simulates player has died
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
}
