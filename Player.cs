using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public int health;

    public int MaxHealth = 100;

    public HealthBar hb;

    // Start is called before the first frame update

    private void Start()
    {
        health = MaxHealth;
        hb.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hb.SetHealth(health);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        ShowFloatingText();
        FindObjectOfType<GameManager>().EndGame();
       
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab);
    }

}
