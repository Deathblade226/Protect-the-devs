using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmovement : MonoBehaviour {

[SerializeField] float movecd = 5.0f;
[SerializeField] NavMeshAgent agent = null;

private float moveTimer = 0.0f;

void Update() {

    if (moveTimer <= 0.0f) { 
    agent.SetDestination(new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11)));
    moveTimer = movecd;
    }

    if (moveTimer > 0.0f) { moveTimer -= Time.deltaTime; }
        
}

}
