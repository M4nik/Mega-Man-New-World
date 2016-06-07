using UnityEngine;
using System.Collections;

public class ControllerMech : MonoBehaviour {

    public GameObject Boss;
    public GameObject BossSpawn;
    BossTriggerMech BossTrigger;
	

	void Start () {
        BossTrigger = FindObjectOfType<BossTriggerMech>();
	}
	
	// Update is called once per frame
	void Update () {
        if(BossTrigger.BossToggle == true)
        {
            Invoke("BossSpawn1", 1f);
        }
	}

    void BossSpawn1()
    {
        Instantiate(Boss, BossSpawn.transform.position, transform.rotation);
    }
}
