using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
