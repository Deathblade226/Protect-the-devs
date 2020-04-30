﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

public AttackNav attack { get; set; }

private bool hit = false;

public void Attack() { hit = false; }

private void Update() {
    GameObject go = AIUtilities.GetNearestGameObject(gameObject, attack.Target, 0, attack.Nc.Fov, attack.Nc.SeeThroughWalls);
    if (go != null && !hit) { 
    hit = true; 
    go.GetComponent<Damagable>().ApplyDamage(Damage);    
    }   
}

}