using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRapidProjectile : MonoBehaviour
{
    public float speed = 5.0f;
    public float damage = 1.0f;
    public GameObject target = null;
    public float lifeTimer = 3.0f;

    Vector3 direction;

    public TowerRapidProjectile(GameObject target)
    {
        this.target = target;
    }

    public TowerRapidProjectile(GameObject target, float damage, float speed)
    {
        this.target = target;
        this.damage = damage;
        this.speed = speed;
    }

    private void Start()
    {
        direction = target.transform.position - transform.position;
    }

    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        Vector3 movementVector = rotation * Vector3.forward;

        transform.rotation = rotation;

        transform.position += (new Vector3(movementVector.x * speed, movementVector.y + 0.2f, movementVector.z * speed) * Time.deltaTime);

        lifeTimer = lifeTimer - Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            //Get monster component that contains health and change it depending on projectile damage
            //Delete projectile

            other.gameObject.GetComponent<Damagable>().ApplyDamage(damage);

            Destroy(gameObject);
        }
    }
}
