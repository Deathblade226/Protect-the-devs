using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour {

[SerializeField] float fieldOfView = 110f;
[SerializeField] bool playerSeen = false;
[SerializeField] Vector3 sightingLocation;
public float FieldOfView { get => fieldOfView; set => fieldOfView = value; }
public bool PlayerSeen { get => playerSeen; set => playerSeen = value; }
public Vector3 SightingLocation { get => sightingLocation; set => sightingLocation = value; }

private NavMeshAgent nav;
private SphereCollider collider;
private Animator animator;
private GameObject player;
private Vector3 previouseSighting;

private void Awake() {
    nav = GetComponent<NavMeshAgent>();
    collider = GetComponent<SphereCollider>();
    animator = GetComponent<Animator>();
}


}
