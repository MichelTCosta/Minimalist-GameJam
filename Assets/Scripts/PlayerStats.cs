using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health = 1;
    public float iframes = .1f;
    public bool canTakeDamage = true;
    public Color playerColor;
    Renderer playerRenderer;
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
    

}
