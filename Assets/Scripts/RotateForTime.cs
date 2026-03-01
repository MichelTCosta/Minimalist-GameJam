using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RotateForTime : MonoBehaviour
{

    FlameThromePowerUp flameThrowerPowerUp;

    private float durationTimer;
    private float durationTimerCounter;


    private void Awake() 
    {
        flameThrowerPowerUp = GetComponentInChildren<FlameThromePowerUp>();
        durationTimer = flameThrowerPowerUp._flameThrowerDuration;

    }
    
    private void Update() 
    {

    FlamethrowerRotationTimer();

    }

    void FlamethrowerRotationTimer()
    {
            if(durationTimerCounter < durationTimer)
            {   
            durationTimerCounter += Time.deltaTime;
            transform.Rotate(0, 0, flameThrowerPowerUp.rotationSpeed * Time.deltaTime);

                if(durationTimerCounter >= durationTimer)
                {
                    Destroy(this.gameObject);
                }
            }
    }
}
