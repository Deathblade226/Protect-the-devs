using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProjectile : Projectile
{
    public float radius = 10f;

    Vector3 direction;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Monster")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
        }
        else
        { 
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Monster"))
                {
                    collider.GetComponent<Damagable>().ApplyDamage(WeaponDamage);
                }
            }

            Destroy(gameObject);
        }
    }
}
