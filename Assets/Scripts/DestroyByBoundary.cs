using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
    }
}
