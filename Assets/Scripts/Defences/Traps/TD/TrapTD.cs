using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTD : DefenseTD {

//Area for trap to trigger. The base rage is the aoe that i can do damage. Larger then this`.
[SerializeField] float triggerRange = 0.0f;

public float TriggerRange { get => triggerRange; set => triggerRange = value; }
protected float ResetTime { get; set; }

private void OnDrawGizmos() {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(gameObject.transform.position, TriggerRange);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(gameObject.transform.position, Range);
}

}
