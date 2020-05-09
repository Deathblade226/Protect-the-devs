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

private void Start() { game = this; }

void Update() {
    currencyDisplay.text = $"Currency: {currency}";
    if (Input.GetKeyDown(KeyCode.Escape)) { PausePlayGame(); }
    if (!paused && Input.GetKeyDown(KeyCode.G)) { UpdateNavMesh(); }
    if (!paused && Rebuild) UpdateNavMesh(); Rebuild = false;
    if (!paused && Input.GetKeyDown(KeyCode.M)) panel.SetActive((panel.activeSelf) ? false : true);
}

public void PausePlayGame() {
    paused = (paused) ? false : true;
    if (paused) Cursor.lockState = CursorLockMode.None;
    else Cursor.lockState = CursorLockMode.Locked;
    Time.timeScale = (paused) ? 0: 1;
    pauseMenu.SetActive(paused);
}

public void UpdateNavMesh() { 
    mesh.BuildNavMesh();
}

}
