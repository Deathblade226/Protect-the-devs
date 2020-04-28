using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game : MonoBehaviour {

[SerializeField] NavMeshSurface mesh = null;

public static Game game = new Game();
public static bool Rebuild = false;

void Start() {
}
void Update() {
    if (Input.GetKeyDown(KeyCode.G)) { UpdateNavMesh(); }
    if (Rebuild) UpdateNavMesh(); Rebuild = false;
}

public void UpdateNavMesh() { 
    mesh.BuildNavMesh();
}

}
