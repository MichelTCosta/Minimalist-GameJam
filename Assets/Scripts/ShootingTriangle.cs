using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ShootingTriangle : MonoBehaviour
{
    public EnemyManager enemyManager;

    private GameObject closestEnemy;

    private Rigidbody2D rb;
    public float timerToShoot;
    private float counter;
    
    public GameObject bullet;
    public float bulletSpeed;
    public int bulletDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            ShootingTimer();
            LookAtEnemy();
    }

    void LookAtEnemy()
    {
        if(enemyManager.closestEnemyToPlayer != null)
        {
            closestEnemy = enemyManager.closestEnemyToPlayer;
            Vector2 direction = closestEnemy.transform.position - transform.position;
            transform.up = direction;
            
            
        }
    }

    void ShootingTimer()
    {
        if(counter < timerToShoot)
        {
            counter += Time.deltaTime;
            if(counter >= timerToShoot )
            {
                counter = 0;
                if(closestEnemy == null) return;
                GameObject spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
                Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();
                bulletScript.enemyPosition = closestEnemy.transform.position;
                bulletScript.speed = bulletSpeed;
                bulletScript.damage = bulletDamage;
            }    
        }
    }


}
