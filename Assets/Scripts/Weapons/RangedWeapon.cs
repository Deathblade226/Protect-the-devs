﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon {

[SerializeField] GameObject projectile = null;
[SerializeField] GameObject spawner = null;
[SerializeField] bool gravity = false;
[SerializeField] float speed = 1.0f;
[SerializeField] float lifeTime = 1.0f;

private void Awake() { Type = "Ranged"; }

public void Attack() {
    GameObject go = Instantiate(projectile, spawner.gameObject.transform.position, Quaternion.identity);
    go.GetComponent<MeleeWeapon>().attack = attack;
    go.GetComponent<Rigidbody>().useGravity = gravity;
    go.GetComponent<SphereCollider>().isTrigger = true;
    go.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
    go.GetComponent<Weapon>().Damage = Damage;
    Destroy(go, lifeTime);
}

private void Update() {
    if (attack != null) { 
    GameObject target = AIUtilities.GetNearestGameObject(spawner.gameObject, attack.Target, xray:true);
    if (target != null) spawner.gameObject.transform.LookAt(target.transform);
    }
}

}
