using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TravelNav : MonoBehaviour {

[SerializeField] string targetTag = "Objective";
[SerializeField] NavigationController nc = null;
public bool Moving { get; set; }
public string TargetTag { get => targetTag; set => targetTag = value; }
public NavigationController Nc { get => nc; set => nc = value; }

private GameObject target = null;

void Start() { target = AIUtilities.GetNearestGameObject(gameObject, TargetTag, xray:true); }
public void StartTravel() {
    Moving = true; 
    nc.Agent.SetDestination(target.transform.position);
}

}
