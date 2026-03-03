using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Experience : MonoBehaviour
{
    public float experienceValue = 1;
    public float moveSpeed = .3f;

    public Transform player;
    private Rigidbody2D rb;

    public bool enableMoveToPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerStats>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        MoveToPlayer();
        if(distance < 1)
        {
            player.GetComponent<PlayerStats>().AddExperience(experienceValue);
            Destroy(this.gameObject);
        }
    }

    public void MoveToPlayer()
    {
        if (enableMoveToPlayer)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, moveSpeed));
            
        }
    }
}
