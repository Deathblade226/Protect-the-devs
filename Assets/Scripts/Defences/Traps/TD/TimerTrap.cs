using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrap : TrapTD
{
    public float timer = 5f;
    public float currentTimer = 0f;

    void Update()
    {
        if (currentTimer <= 0)
        {
            currentTimer = timer;
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, Range);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Monster"))
                {
                    collider.GetComponent<Damagable>().ApplyDamage(Damage);
                }
            }
        }
        else { 
        currentTimer = currentTimer - Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        if (currentTimer <= 0)
        {
            Gizmos.DrawWireSphere(gameObject.transform.position, 2.4f);
        }
    }
}
