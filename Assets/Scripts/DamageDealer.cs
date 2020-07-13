using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int DamageOfLaser = 100;

    public int getDamage()
    {
        return DamageOfLaser;
    }

    public void onHit()
    {
        Destroy(gameObject);
    }
}
