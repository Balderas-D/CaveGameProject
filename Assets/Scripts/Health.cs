using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public int teamId = 0;
    public Image gameOver;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);

        }
    }
}
