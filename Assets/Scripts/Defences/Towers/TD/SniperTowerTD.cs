using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTowerTD : TowerTD {

private void Update() { 
    GameObject enemy = AIUtilities.GetNearestGameObject(VisionCheck, EnemyTag, Range);
    
    if (enemy != null) { 
    Barrel.transform.LookAt(enemy.transform.position + Vector3.up);
    if (WaitTime <= 0) { 
    
    GameObject shot = Instantiate(Projectile, Barrel.transform.position + Barrel.transform.forward, Barrel.transform.rotation);
    shot.GetComponent<MeleeWeapon>().Damage = Damage;
    Rigidbody rb = shot.GetComponent<Rigidbody>();
    rb.AddForce(Barrel.transform.forward * ShotSpeed);
    rb.useGravity = false;
    WaitTime = Rate;

    } else { WaitTime -= Time.deltaTime; }

    }
}

}
