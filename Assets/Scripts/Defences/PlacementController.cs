using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour {

[SerializeField] Camera PlayerCam = null;
[SerializeField] Camera BuildCam = null;
[SerializeField] List<GameObject> placeableObjects = new List<GameObject>();

private GameObject currentObject = null;
private float rotation;
private int currentTower = -1;

private void Update() {
    CreatePlacable();

    if (!Game.game.Paused) Cursor.lockState = (BuildCam.gameObject.activeSelf) ? CursorLockMode.None : CursorLockMode.Locked;

    if (Input.GetKeyDown(KeyCode.T)) { 
    BuildCam.gameObject.SetActive(PlayerCam.gameObject.activeSelf == true);
    PlayerCam.gameObject.SetActive(BuildCam.gameObject.activeSelf != true);
    }

    if (currentObject != null) {
    MovePlaceableToMouse();
    RotatePlaceable();
    SpawnObject();
    }
}
private void SpawnObject() {
    if (Input.GetMouseButtonDown(0) && Game.game.Currency >= currentObject.GetComponent<Cost>().BuildCost && Game.game.Currency - currentObject.GetComponent<Cost>().BuildCost >= 0) {
    Game.game.Currency -= currentObject.GetComponent<Cost>().BuildCost;
    currentObject.layer = 0;
    currentObject = null;
    Game.Rebuild = true;
    }
}

private void RotatePlaceable() {
    rotation += Input.mouseScrollDelta.y;
    currentObject.transform.Rotate(Vector3.up, rotation * 10f);
}

private void MovePlaceableToMouse() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo)) {
    if (hitInfo.collider.tag != "Defence") { 
    currentObject.transform.position = hitInfo.point;
    currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
    }
    }
}

private void CreatePlacable() {
    for (int i = 0; i < placeableObjects.Count; i++) {

    if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i)) { 

    if (Pressed(i)) { 
    Destroy(currentObject); 
    currentTower = -1; 
    
    } else { 
    
    if (currentObject != null) { 
    Destroy(currentObject); 
    }    
    currentObject = Instantiate(placeableObjects[i]);
    currentTower = i;
    }
    break;
    }
    }
}

private bool Pressed(int i) {
return currentObject != null && currentTower == i;
}

}
