using Unity.VisualScripting;
using UnityEngine;

public class FlameThromePowerUp : MonoBehaviour
{

    public int _damage;
    public float rotationSpeed;
    public float _flameThrowerDuration;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ContactEnemy>().TakeDamage(_damage);
        }

    }
}
