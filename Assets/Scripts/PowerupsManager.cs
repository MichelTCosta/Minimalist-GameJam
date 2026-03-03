using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PowerupsManager : MonoBehaviour
{
    public InputAction inputAction;
    public GameObject player;

    [Header("Shooting Triangle Powerup")]
    public GameObject[] triangleSpawns;
    public GameObject shootingTrianglePrefab;

    [Header("Flamethrower Powerup")]

    public GameObject flameThrowerPrefab;

    public int flameThrowerDamage;

    public float timerToSpawnFlame;
    private float counterToSpawnFlame;


    [Header("Area Damage Powerup")]

    public GameObject areaOfDamagePrefab;

    public int areaDamage;
    public float areaRadius;
    public float areaTimeToDamage;
    
    private bool areaIsActive;

    private GameObject areaOfDamageSpawned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnEnable() 
    {
        inputAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {


        if(counterToSpawnFlame < timerToSpawnFlame)
        {
            counterToSpawnFlame += Time.deltaTime;

            if(counterToSpawnFlame >= timerToSpawnFlame)
            {
                SpawnFlameThrower();
                counterToSpawnFlame = 0;
            }
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

    public void SpawnFlameThrower()
    {

        GameObject flameThrower = Instantiate(flameThrowerPrefab, player.transform);
        flameThrower.GetComponentInChildren<FlameThromePowerUp>()._damage = flameThrowerDamage;
    }

    public void SpawnAreaOfDamage()
    {
        if(areaIsActive == false)
        {
            areaOfDamageSpawned = Instantiate(areaOfDamagePrefab, player.transform);
                    
        }
    }

    public void UpdateAreaOfDamage()
    {
        areaOfDamageSpawned.GetComponent<AreaOfDamagePowerup>().damage = areaDamage;
        areaOfDamageSpawned.GetComponent<AreaOfDamagePowerup>().radius = areaRadius;
        areaOfDamageSpawned.GetComponent<AreaOfDamagePowerup>().timeToDamage = areaTimeToDamage;
    }



}
