﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : Navigation {

[SerializeField] AttackNav attackNav = null;
[SerializeField] TravelNav travelNav = null;
[SerializeField] WanderNav wanderNav = null;
public AttackNav AttackNav { get => attackNav; set => attackNav = value; }

private NavMeshPath navPath ;

void Start() {
    attackNav.Nc = this;
    wanderNav.Nc = this;
    travelNav.Nc = this;
    navPath = new NavMeshPath();
}

void Update() {
    if (Animator != null) Animator.SetFloat("Speed", Agent.velocity.magnitude);

    GameObject objective = AIUtilities.GetNearestGameObject(gameObject, travelNav.TargetTag, xray:true);

    if (CheckPath(travelNav.Target.transform)) { 
    
    attackNav.Target = "Defence"; attackNav.StartAttacking();

    } else if (attackNav.Target != "" && !attackNav.Active) { travelNav.Moving = false; wanderNav.StopWander(); attackNav.StartAttacking(); 
    } else if (objective != null && !travelNav.Moving && !attackNav.Active) { wanderNav.StopWander(); travelNav.StartTravel();  
    } else if (!wanderNav.Active && !travelNav.Moving && !attackNav.Active) wanderNav.StartWander(); travelNav.Moving = false;

}

public bool CheckPath(Transform target) { 
    Agent.CalculatePath(target.position, navPath);
    if (navPath.status != NavMeshPathStatus.PathComplete) { return false; }
return true;}

}
