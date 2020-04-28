using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : Navigation {

[SerializeField] AttackNav attackNav = null;
[SerializeField] TravelNav travelNav = null;
[SerializeField] WanderNav wanderNav = null;
public AttackNav AttackNav { get => attackNav; set => attackNav = value; }

void Start() {
    attackNav.Nc = this;
    wanderNav.Nc = this;
    travelNav.Nc = this;
}

void Update() {
    if (Animator != null) Animator.SetFloat("Speed", Agent.velocity.magnitude);

    GameObject objective = AIUtilities.GetNearestGameObject(gameObject, travelNav.TargetTag, xray:true);

    if (attackNav.Target != "" && !attackNav.Active) { travelNav.Moving = false; wanderNav.StopWander(); attackNav.StartAttacking(); 
    } else if (objective != null && !travelNav.Moving && !attackNav.Active) { wanderNav.StopWander(); travelNav.StartTravel();  
    } else if (!wanderNav.Active && !travelNav.Moving && !attackNav.Active) wanderNav.StartWander(); travelNav.Moving = false;

}

}
