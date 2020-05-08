using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

[SerializeField] List<GameObject> items = new List<GameObject>();

public void SpawnWave() {
    if (items.Count > 0) { 
    foreach(GameObject item in items) { 
    Vector3 offset = new Vector3(Random.Range(-2,3),0, Random.Range(-2, 3));
    GameObject go = Instantiate(item, gameObject.transform.position + offset, Quaternion.identity, gameObject.transform);}
    }
}

}
