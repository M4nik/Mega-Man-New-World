using UnityEngine;
using System.Collections;

public class BoundryMech : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        print("Object Destroyed");
    }
}
