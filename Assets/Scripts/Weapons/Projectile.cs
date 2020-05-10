using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

[SerializeField] float damage = 0f;
[SerializeField] string enemyTag = "";
[SerializeField] float LifeTime = 1.0f;
public float WeaponDamage { get => damage; set => damage = value; }
public string EnemyTag { get => enemyTag; set => enemyTag = value; }

private void Start() { Destroy(gameObject, LifeTime); }

private void OnTriggerEnter(Collider other) {
    if (other.tag == EnemyTag) { 
    
    Damagable health = other.GetComponent<Damagable>();
    if (health != null) { 
    health.ApplyDamage(WeaponDamage);
    }
    Destroy(gameObject);
    }       
}

}
