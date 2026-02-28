using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]public float speed;
    [HideInInspector]public int damage;
    public Vector2 enemyPosition;
    private Rigidbody2D rb;
    bool checkEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10);
        StartCoroutine(DestroyIfEnemyDead());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkEnemy)
        {
            if(rb.linearVelocity == Vector2.zero)
            {        
                Destroy(this.gameObject);
            }
        }

        rb.MovePosition(Vector2.MoveTowards(transform.position, enemyPosition , speed));
    }

    void FixedUpdate() 
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ContactEnemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyIfEnemyDead()
    {
        yield return new WaitForSeconds(0.1f);
        checkEnemy = true;

    }
}
