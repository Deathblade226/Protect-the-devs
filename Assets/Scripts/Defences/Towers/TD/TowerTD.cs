using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTD : DefenseTD {

[SerializeField] GameObject projectile = null;
[SerializeField] GameObject barrel = null;
[SerializeField] float shotSpeed = 1.0f;
[SerializeField] GameObject visionCheck = null;
public GameObject Projectile { get => projectile; set => projectile = value; }
public GameObject Barrel { get => barrel; set => barrel = value; }
public float ShotSpeed { get => shotSpeed; set => shotSpeed = value; }
public GameObject VisionCheck { get => visionCheck; set => visionCheck = value; }
}
