using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
    [SerializeField] Tower owner = null;
    [SerializeField] SphereCollider collider = null;

    private void Start()
    {
        collider.radius = owner.Range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (owner != null && collider != null)
        {
            if (owner.target == null)
            {
                if (other.gameObject.CompareTag("Monster"))
                {
                    owner.target = other.gameObject;
                }
            }
        }
    }
}
