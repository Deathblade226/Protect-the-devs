﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNav : MonoBehaviour {

[SerializeField] float attackCD = 3.0f;
[SerializeField] float attackRange = 2.0f;
[SerializeField] NavigationController nc = null;

public string Target { get; set; } = "";
public bool Active { get; set; } = false;
public NavigationController Nc { get => nc; set => nc = value; }

private float AttackTime = 0;
private bool Attacking = false;

private void Update() {
	if (Target != "" && Active) { 

	var target = AIUtilities.GetNearestGameObject(gameObject, Target, Nc.Range, Nc.Fov, Nc.SeeThroughWalls);
	
	if (target != null) { 
	
	Attacking = ((transform.position - target.transform.position).magnitude <= attackRange && AttackTime <= 0);
	
	if (Attacking) { 
	if (Nc.Animator != null) Nc.Animator.SetTrigger("Attack");  

	transform.LookAt(target.transform);
	AttackTime = attackCD; Nc.Agent.isStopped = true; }

	else if ((transform.position - target.transform.position).magnitude <= attackRange) { Nc.Agent.isStopped = true; AttackTime -= Time.deltaTime; }

	else { Nc.Animator.SetTrigger("StopAttack"); Nc.Agent.SetDestination(target.transform.position); Nc.Agent.isStopped = false; AttackTime -= Time.deltaTime; }

	}        
	}
}

public void StartAttacking() { 
	Active = true;
}

public void StopAttacking() { 
	Active = false;
	Target = "";
}

}