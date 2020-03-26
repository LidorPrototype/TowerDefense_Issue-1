using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100f;
    private float health;
    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;
    public HealthBar _healthBar;
    public Gradient gradient;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        _healthBar.SetMaxHealth(1);//not sure if needed yet
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = (health / startHealth);
        healthBar.color = gradient.Evaluate(health / startHealth);
        _healthBar.SetHealth(health / startHealth);

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = (startSpeed * (1f - pct));
    }

    void Die()
    {
        isDead = true;

        PlayerStates.Money += worth;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
