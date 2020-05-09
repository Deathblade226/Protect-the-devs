using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour {

[SerializeField] int buildCost = 100;
public int BuildCost { get => buildCost; set => buildCost = value; }
}
