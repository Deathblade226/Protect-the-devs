using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerTD : TowerTD {

private void Update() { 
    GameObject enemy = AIUtilities.GetNearestGameObject(VisionCheck, EnemyTag, Range);
    
    if (enemy != null) { 
    Barrel.transform.LookAt(enemy.transform.position + Vector3.up);
    if (WaitTime <= 0) { 
    
    GameObject shot = Instantiate(Projectile, Barrel.transform.position + Barrel.transform.forward, Barrel.transform.rotation);
    Projectile projectile = shot.GetComponent<Projectile>();
    projectile.WeaponDamage = Damage;
    projectile.EnemyTag = EnemyTag;
    Rigidbody rb = shot.GetComponent<Rigidbody>();
    rb.AddForce(Barrel.transform.forward * (ShotSpeed * 10));
    rb.useGravity = false;
    WaitTime = Rate;

    } else { WaitTime -= Time.deltaTime; }

    }
}

}
