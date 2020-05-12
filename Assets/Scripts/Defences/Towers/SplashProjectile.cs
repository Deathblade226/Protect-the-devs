using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProjectile : Projectile
{
    public float radius = 10f;

    Vector3 direction;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag != "Monster")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
        }
        else
        {
            if (Particles != null) { 
            GameObject particles = Instantiate(Particles, transform.position, Quaternion.identity);
            ParticleSystem ps = particles.GetComponent<ParticleSystem>();
            ps.Play();
            Destroy(particles.gameObject, 1.5f);
            }

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
