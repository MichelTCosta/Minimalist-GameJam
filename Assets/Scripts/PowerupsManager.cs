using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerupsManager : MonoBehaviour
{

    [Header("Shooting Triangle Powerup")]
    public GameObject[] triangleSpawns;
    public GameObject shootingTrianglePrefab;

    public InputAction inputAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnShootingTriangle();
    }

    void OnEnable() 
    {
        inputAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputAction.WasPressedThisFrame())
        {
            SpawnShootingTriangle();
        }
    }




    public void SpawnShootingTriangle()
    {
        foreach (GameObject GO in triangleSpawns)
        {
            if(GO.GetComponent<TriangleSpawnedChecker>().hasTriangle == false)
            {
                Instantiate(shootingTrianglePrefab, GO.transform);
                GO.GetComponent<TriangleSpawnedChecker>().hasTriangle = true;
                return;
            }
            
        }
    }


}
