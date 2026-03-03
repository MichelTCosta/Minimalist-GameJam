using System.Collections;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health = 1;
    public float iframes = .1f;
    public bool canTakeDamage = true;
    public Color playerColor;
    Renderer playerRenderer;

    [Header("Player Level Up")]

    public float experienceNeededForUp = 25;
    public float currentExperience = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material.color = playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        if(canTakeDamage == false) return;
        health -= damage;
        StartCoroutine(TakeDamgeColorChange());
        canTakeDamage = false;
        StartCoroutine(ResetIframes());
        if(health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("You Died!");
    }

    public void AddExperience(float experienceToAdd)
    {
        currentExperience += experienceToAdd;
    }

    public void LevelUp()
    {
        if(currentExperience >= experienceNeededForUp)
        {
            experienceNeededForUp *= 1.5f;
        }
    }
    IEnumerator ResetIframes()
    {
        yield return new WaitForSeconds(iframes);
        canTakeDamage = true;
    }
    IEnumerator TakeDamgeColorChange()
    {

        playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerRenderer.material.color = playerColor;

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Experience"))
        {
            other.GetComponent<Experience>().enableMoveToPlayer = true;
        }   
    }

}
