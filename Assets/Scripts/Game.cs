using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Game : MonoBehaviour {

[SerializeField] NavMeshSurface mesh = null;
[SerializeField] int currency = 100;
[SerializeField] Text currencyDisplay = null;
[SerializeField] GameObject panel = null;

public static bool Rebuild = false;
public int Currency { get => currency; set => currency = value; }

void Update() {
    currencyDisplay.text = $"Currency: {currency}";
    if (Input.GetKeyDown(KeyCode.G)) { UpdateNavMesh(); }
    if (Rebuild) UpdateNavMesh(); Rebuild = false;
    if (Input.GetKeyDown(KeyCode.M)) panel.SetActive((panel.activeSelf) ? false : true);
}

public void UpdateNavMesh() { 
    mesh.BuildNavMesh();
}

}
