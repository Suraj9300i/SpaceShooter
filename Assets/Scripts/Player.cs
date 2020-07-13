using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speedOfPlayer = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 200;

    [Header("Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float timeIntervalBtwnLaser = 0.1f;

    [Header(header: "Audio")]
    [SerializeField] AudioClip DeathSound;
    [SerializeField] [Range(0,1)] float DeathSoundVolume = 1f;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] [Range(0, 1)] float ShootSoundVolume = 0.3f;


    float minX;
    float maxX;
    float minY;
    float maxY;
    Level level;
    Coroutine laserCoroutine;
    private void Start()
    {
        SetUpBoundaries();
        level = FindObjectOfType<Level>();
    }
    private void Update()
    {
        move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.getDamage();
        damageDealer.onHit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, DeathSoundVolume);
        level.LoadGameOver();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           laserCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(laserCoroutine);
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject playerLaserBullet = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            playerLaserBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(ShootSound, Camera.main.transform.position, ShootSoundVolume);
            yield return new WaitForSeconds(timeIntervalBtwnLaser);
        }
    }

    public int getPlayerHealth()
    {
        return health;
    }

    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speedOfPlayer;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speedOfPlayer;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);
        transform.position = new Vector2(newXPos, transform.position.y);
        transform.position = new Vector2(transform.position.x, newYPos);

    }
}
