using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using Unity.Burst.Intrinsics;
using System.Reflection.Emit;

public class ContactEnemy : MonoBehaviour
{
    public GameObject player;
    public int contactDamage;
    public float speed;
    public Rigidbody2D rb;
    private bool canMove = true;

    public float knockbackDuration;
    public float knockbackForce;
    private bool isKnockbacked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed));
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(contactDamage);
            ApplyKnockBack(player.transform);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(contactDamage);
            ApplyKnockBack(player.transform);
        }
    }

    public void ApplyKnockBack(Transform damageSource)
    {
        Vector2 knockbackDir = (transform.position  - player.transform.position).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

        if (!isKnockbacked)
        {
            StartCoroutine(KnockbackTimer());
        }

    }

    IEnumerator KnockbackTimer()
    {
        isKnockbacked = true;
        canMove = false;

        yield return new WaitForSeconds(knockbackDuration);

        isKnockbacked = false;
        canMove = true;
    }


}