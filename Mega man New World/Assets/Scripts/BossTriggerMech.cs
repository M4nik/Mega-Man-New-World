using UnityEngine;
using System.Collections;

public class BossTriggerMech : MonoBehaviour {

    public bool BossToggle;

	void Start () {
        BossToggle = false;
	}
	
	
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            BossToggle = true;
            Destroy(gameObject);
        }
    }
}
