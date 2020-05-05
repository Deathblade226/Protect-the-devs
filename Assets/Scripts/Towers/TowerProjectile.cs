using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public float speed = 5.0f;
    public float damage = 1.0f;
    public GameObject target = null;

    public TowerProjectile(GameObject target)
    {
        this.target = target;
    }

    public TowerProjectile(GameObject target, float damage, float speed)
    {
        this.target = target;
        this.damage = damage;
        this.speed = speed;
    }

    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        Vector3 movementVector = rotation * Vector3.forward;

        transform.rotation = rotation;

        transform.position += (movementVector * speed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            //Get monster component that contains health and change it depending on projectile damage
            //Delete projectile
        }
    }
}
