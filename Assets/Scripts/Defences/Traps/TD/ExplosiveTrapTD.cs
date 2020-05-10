﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplosiveTrapTD : TrapTD {

void Update() {
    
    if (ResetTime <= 0) { 

    GameObject enemy = AIUtilities.GetNearestGameObject(gameObject, EnemyTag, TriggerRange, xray:true);
    if (enemy != null) { 
    ResetTime = Rate;
    GameObject[] monsters = AIUtilities.GetGameObjects(gameObject, EnemyTag, Range);
    monsters.ToList().ForEach(m => m.GetComponent<Damagable>().ApplyDamage(Damage));
    
    }

    } else { ResetTime -= Time.deltaTime; }
}

}