using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTD : MonoBehaviour {

[SerializeField] string towerName ;
[SerializeField] Damagable fortitude = null;
[SerializeField] float range = 1.0f;
[SerializeField] float rate = 1.0f;
[SerializeField] int cost = 0;
[SerializeField] float damage = 0.0f;
[SerializeField] DefenceAgro agro = null;
[SerializeField] string enemyTag = "";
[SerializeField] ParticleSystem particles = null;
public ParticleSystem Particles { get => particles; set => particles = value; }
public Damagable Fortitude { get => fortitude; set => fortitude = value; }
public float Range { get => range; set => range = value; }
public float Rate { get => rate; set => rate = value; }
public int Cost { get => cost; set => cost = value; }
public float Damage { get => damage; set => damage = value; }
public DefenceAgro Agro { get => agro; set => agro = value; }
public string EnemyTag { get => enemyTag; set => enemyTag = value; }
public float WaitTime { get; set; }
public bool Placed { get; set; } = false;
public string TowerName { get => towerName; set => towerName = value; }
}
