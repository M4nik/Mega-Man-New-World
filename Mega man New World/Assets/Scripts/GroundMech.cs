using UnityEngine;
using System.Collections;

public class GroundMech : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bbullet")
        {
            Destroy(other.gameObject);
        }
    }
}
