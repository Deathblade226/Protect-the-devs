using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] float Damage = 0.0f;
    public float Range = 0.0f;
    [SerializeField] float Rate = 0.0f;
    private float timer = 0.0f;
    [SerializeField] Damagable Fortitude = null;
    [SerializeField] GameObject Ammo = null;

    [SerializeField] RangeFinder rangeFinder;

    public GameObject target;
    [SerializeField] List<GameObject> Barrels;
    [SerializeField] Transform barrelTransform = null;
    [SerializeField] GameObject projectile = null;

    private void Start()
    {
        timer = Rate;
        projectile.GetComponent<TowerProjectile>().damage = Damage;
        projectile.GetComponent<TowerProjectile>().speed = 5f;
    }

    private void Update()
    {
        if (target != null)
        {
            Debug.Log(target.name);
            projectile.GetComponent<TowerProjectile>().target = target;
            AimBarrel(target);
            Fire(target);
            Debug.Log((target.transform.position - rangeFinder.transform.position).magnitude);
            if (!CheckEnemyRange(target))
            {
                target = null;
            }
        }
    }


    private void AimBarrel(GameObject target)
    {
        foreach (GameObject barrel in Barrels)
        {
            //Create vector between the taget and source position 
            Vector3 v = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(v, Vector3.up);
            Vector3 moveDirection = rotation * Vector3.forward;

            barrel.transform.rotation = rotation;
        }
    }

    private bool CheckEnemyRange(GameObject target)
    {
        float distance = (target.transform.position - rangeFinder.transform.position).magnitude;

        if (distance > Range + 3)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Fire(GameObject target)
    {
        //Instantiate Projectile
        if (target != null)
        {
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {
                GameObject projectileClone = projectile;
                Instantiate(projectileClone, barrelTransform);
                timer = Rate;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rangeFinder.transform.position, Range);
    }
}
