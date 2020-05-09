using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Game : MonoBehaviour {

[SerializeField] NavMeshSurface mesh = null;
[SerializeField] int currency = 100;
[SerializeField] int coreHealth = 100;
[SerializeField] Text currencyDisplay = null;
[SerializeField] GameObject panel = null;
[SerializeField] GameObject pauseMenu = null;

public static Game game;
private bool paused = false;
public static bool Rebuild = false;
public int Currency { get => currency; set => currency = value; }
public bool Paused { get => paused; private set => paused = value; }

private void Start() { game = this; }

void Update() {
    currencyDisplay.text = $"Currency: {currency}";
    if (Input.GetKeyDown(KeyCode.Escape)) { PausePlayGame(); }
    if (!Paused && Input.GetKeyDown(KeyCode.G)) { UpdateNavMesh(); }
    if (!Paused && Rebuild) UpdateNavMesh(); Rebuild = false;
    if (!Paused && Input.GetKeyDown(KeyCode.M)) panel.SetActive((panel.activeSelf) ? false : true);
}

public void PausePlayGame() {
    Paused = (Paused) ? false : true;
    Cursor.lockState = (Paused) ? CursorLockMode.Confined : CursorLockMode.Locked;
    Time.timeScale = (Paused) ? 0: 1;
    pauseMenu.SetActive(Paused);
}

public void UpdateNavMesh() { 
    mesh.BuildNavMesh();
}

}
