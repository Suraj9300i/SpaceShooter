using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header(header:"Enemy")]
    [SerializeField] int EnemyHealth = 300;
    [SerializeField] GameObject particleEffect;
    [SerializeField] int ScoreOfEnemyDeath = 58;

    [Header(header:"Laser Bullet")]
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] float laserSpeed = 12f;
    [SerializeField] float ShootTime;
    [SerializeField] float minTimeBtwnShoot = 0.3f;
    [SerializeField] float maxxTimeBtwnShoot = 2f;

    [Header(header: "Audio")]
    [SerializeField] AudioClip DeathSound;
    [SerializeField] float DeathVolume = 1f;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] float ShootVolume = 0.2f;

    GameSession gameSession;
    private void Start()
    {
        ShootTime = Random.Range(minTimeBtwnShoot, maxxTimeBtwnShoot);
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        onShoot();
    }


    public void onShoot()
    {
        ShootTime -= Time.deltaTime;
        if (ShootTime <= 0)
        {
            Fire();
            ShootTime = Random.Range(minTimeBtwnShoot, maxxTimeBtwnShoot);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeed);
        AudioSource.PlayClipAtPoint(ShootSound, Camera.main.transform.position, ShootVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        EnemyHealth -= damageDealer.getDamage();
        damageDealer.onHit();
        if (EnemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject pp = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(pp, 2f);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, DeathVolume);
        gameSession.AddtoScore(ScoreOfEnemyDeath);
    }
}
