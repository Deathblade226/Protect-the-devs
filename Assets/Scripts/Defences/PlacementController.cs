using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour {

[SerializeField] GameObject player = null;
[SerializeField] GameObject placeableObject = null;
[SerializeField] private KeyCode spawnHotkey = KeyCode.Alpha1;

private GameObject currentObject = null;
private float rotation;

    private void Update() {
    CreatePlacable();

    if (currentObject != null) {
    MovePlaceableToMouse();
    RotatePlaceable();
    SpawnObject();
    }
}
private void SpawnObject() {
    if (Input.GetMouseButtonDown(0)) { 
    currentObject = null;
    Game.Rebuild = true;
    }
}

private void RotatePlaceable() {
    if (Input.GetKey(KeyCode.E)) rotation += 0.1f;
    if (Input.GetKey(KeyCode.Q)) rotation -= 0.1f;
    rotation = Input.mouseScrollDelta.y;
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
    if (Input.GetKeyDown(spawnHotkey)) { 
    if (currentObject == null) { 
    currentObject = Instantiate(placeableObject);
    } else { 
    Destroy(currentObject);        
    }
    }
}

}
