using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

[SerializeField] List<Wave> waves = new List<Wave>();
[SerializeField] float waveCD = 0;
[SerializeField] bool PlayerRan = false;
private float waveTimer = 0;
private int waveNumber = 0;
public int WaveNumber { get => waveNumber; }
public bool GameRunning { get; set; } = false;

private void Start() {
    if (waveCD == 0) PlayerRan = true;
}

private void Update() {
    GameObject[] spawned = AIUtilities.GetGameObjects(gameObject, "Monster");
    if (GameRunning && !PlayerRan) { 
    if (spawned.Length == 0) { 
    if (waveTimer <= 0) { StartWave(); } else { waveTimer -= Time.deltaTime; }            
    }
    } else if (spawned.Length == 0 && PlayerRan){ GameRunning = false; }

    if (Input.GetKeyDown(KeyCode.H) && !GameRunning) { 
    GameRunning = true;
    StartWave();
    }        
}
public void StartWave() { 
    waveTimer = waveCD;
    if (waveNumber >= waves.Count) { waves[waves.Count - 1].SpawnWave(); }
    else { waves[WaveNumber].SpawnWave(); waveNumber++; }
}

}
