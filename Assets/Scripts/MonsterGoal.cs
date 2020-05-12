using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonsterGoal : MonoBehaviour {

[SerializeField] float range = 1.0f;
[SerializeField] string monster = "Monster";
void Update() {
    GameObject[] gameObjects = AIUtilities.GetGameObjects(gameObject, monster, range);
    if (gameObjects.Length > 0) {

    foreach(GameObject monster in gameObjects) {
    TravelNav tn = monster.GetComponent<TravelNav>();
    Game.game.CoreHealth -= tn.Value;
    Destroy(monster);
    }

    }
}

private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, range);
}

}
