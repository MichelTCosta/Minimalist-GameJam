using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AreaOfDamagePowerup : MonoBehaviour
{
    public int damage;
    public float radius;

    public float timeToDamage;
    private float timeToDamageCounter;

    private bool _areaDamage;

    private CircleCollider2D circleCollider2D;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       circleCollider2D = GetComponent<CircleCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    { 
        circleCollider2D.radius = radius * 2;
        transform.localScale = new Vector3(radius, radius, 0);

        if(timeToDamageCounter < timeToDamage)
        {
            timeToDamageCounter +=  Time.deltaTime;
            if(timeToDamageCounter >= timeToDamage)
            {
                _areaDamage = true;
                timeToDamageCounter = 0;
            }
        }
    }



    void OnTriggerStay2D(Collider2D other) 
    {
        if(_areaDamage == false) return;
        
        
        if(other.CompareTag("Enemy"))
        {

            other.GetComponent<ContactEnemy>().TakeDamage(damage);
        }
        _areaDamage = false;
    }




}
