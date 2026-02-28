using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.InputSystem;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();

    public GameObject closestEnemyToPlayer;



    public GameObject enemyPrefab;

        public InputAction inputAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAction.IsPressed())
        {
            Instantiate(enemyPrefab);
        }
    }

    private void FixedUpdate() {
        EnemyCloserToPlayer();
    }
    
    public void EnemyCloserToPlayer()
    {


        float minValue = float.MaxValue;
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<ContactEnemy>().distanceToPlayer < minValue)
            {
                minValue = enemy.GetComponent<ContactEnemy>().distanceToPlayer;
                closestEnemyToPlayer = enemy.gameObject;
            }
            
        }
    }



    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
