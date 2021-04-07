using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth;

    public void OnTakeDamage(int damage)
    {
        health = health - damage;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    // Start is called before the first frame update

}
