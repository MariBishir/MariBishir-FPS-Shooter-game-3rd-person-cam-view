using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float health = 100;
    public Text healthText;

    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = health.ToString() + " HP";

        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

}
