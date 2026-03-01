using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]public float speed;
    [HideInInspector]public int damage;
    public GameObject enemyPosition;
    private Rigidbody2D rb;
    Vector2 bulletChecker;

    Vector2 bulletCheker2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10);

    }

    // Update is called once per frame
    void Update()
    {

        if(enemyPosition == null)
        {
            Destroy(this.gameObject);
        }
        if(enemyPosition != null)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, enemyPosition.transform.position, speed));
        }

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




}
