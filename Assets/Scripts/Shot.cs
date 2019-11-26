using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float shotScale; // A value to multiply the shot by to scale up or down the power
    public float maxShotValue; // the cap on the power of the shot.
    public float degenValue; // rate at which the shot power degens
    public float timeUntilDegen; // how long until shot strength will start to degenerate

    private ParticleSystem chargedParticleBurst; // the particles to spawn whilst at maximum charge
    private float timeOfLastInput; // last time that the player scrolled
    private float shotPower; // current value of the shot
    private float particleThreshold;

    // Start is called before the first frame update
    void Start()
    {
        chargedParticleBurst = GetComponentInChildren<ParticleSystem>();
        particleThreshold = maxShotValue * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        DegenerateShot();
    }

    // if some amount of time has elapsed, degenerate the shot strength.
    private void DegenerateShot()
    {
        if (Time.time > timeOfLastInput + timeUntilDegen)
        {
            if (shotPower > 0)
            {
                shotPower -= degenValue * Time.deltaTime;
            }
            else
            {
                shotPower = 0;
            }
        }
    }

    public void IncrementShot(float val)
    {
        timeOfLastInput = Time.time;
        if (shotPower < maxShotValue)
        {
            if(shotPower > particleThreshold)
            {
                chargedParticleBurst.Play();
            }
            shotPower += val * shotScale * Time.deltaTime;
        }
        else
        {
            shotPower = maxShotValue;
            chargedParticleBurst.Play();
        }
    }

    public void shotTaken()
    {
        shotPower = 0;
    }

    public float GetShotPower()
    {
        return shotPower;
    }
}
