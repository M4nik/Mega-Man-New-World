using UnityEngine;
using System.Collections;

public class ShootPowerupMech : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
