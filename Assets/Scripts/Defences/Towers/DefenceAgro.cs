using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceAgro : MonoBehaviour {

[SerializeField] float agro = 1.0f;

private bool destroyed = false;
public float Agro { get => agro; set => agro = value; }

private void Update() {
    if (!destroyed) { 
    GameObject[] enemies = AIUtilities.GetGameObjects(gameObject, "Monster", Agro);
    foreach(GameObject enemy in enemies) { 
    //Debug.Log(enemy);
    NavigationController nc = enemy.GetComponent<NavigationController>();
    if (nc != null && nc.AttackNav.Target != gameObject.tag) nc.AttackNav.Target = gameObject.tag; }
    }
}

private void OnDestroy() {
    GameObject[] enemies = AIUtilities.GetGameObjects(gameObject, "Monster", Agro);
    destroyed = true;
    foreach(GameObject enemy in enemies) { 
    NavigationController nc = enemy.GetComponent<NavigationController>();
    nc.Agent.isStopped = false;
    nc.AttackNav.Target = "";
    nc.AttackNav.Active = false; }
    Game.Rebuild = true;
}

private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, Agro);
}

}
