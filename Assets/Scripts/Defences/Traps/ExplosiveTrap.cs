using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTrap : MonoBehaviour
{
    public float damage = 0;
    public float radius = 2;
    bool triggered = false;

    private void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster") && !triggered)
        {
            triggered = true;
            other.gameObject.GetComponent<Damagable>().ApplyDamage(damage);

            //If particle system will be used, do so here

            Destroy(gameObject, 1f);
        }
    }
}
