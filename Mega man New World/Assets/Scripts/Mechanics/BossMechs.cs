using UnityEngine;
using System.Collections;

public class BossMechs : MonoBehaviour {

    public float ehealth;
    public GameObject explosion;
    public bool canshoot;
    public GameObject ebullet;
    Rigidbody2D eRBD;
    public float speed;
    bool canAccelerate = true;
    PlayerMechs pms;
    bool travelUp = false;

    void Start()
    {
        eRBD = GetComponent<Rigidbody2D>();
        pms = FindObjectOfType<PlayerMechs>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.transform.position.x <= 5)
        {
            if (canAccelerate)
            {
                canAccelerate = false;
                InvokeRepeating("shoot", 1f, 1f);
                travelUp = true;
                eRBD.velocity = new Vector2(0, 0);
            }
        }

        if (gameObject.transform.position.y >= 3.5f)
        {
            travelUp = false;
        }

        if (gameObject.transform.position.y <= -3.5f)
        {
            travelUp = true;
        }

        switch (travelUp)
        {
            case true:
                goinUp();
                break;
            case false:
                goinDown();
                break;
        }

        fight();
        death();
    }

    void FixedUpdate()
    {
        if (canAccelerate)
        {
            eRBD.velocity = new Vector2(-5, gameObject.transform.position.y);
            eRBD.AddForce(speed * transform.up);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pbullet")
        {
            ehealth--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "pbullet2")
        {
            ehealth -= 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "pbullet3")
        {
            ehealth -= 3;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "pbullet4")
        {
            ehealth -= 4;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet" && pms.attack)
        {
            ehealth -= 3;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet2" && pms.attack)
        {
            ehealth -= 4;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet3" && pms.attack)
        {
            ehealth -= 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet4" && pms.attack)
        {
            ehealth -= 6;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet" && pms.speedy)
        {
            ehealth -= 0.5f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet2" && pms.speedy)
        {
            ehealth -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet3" && pms.speedy)
        {
            ehealth -= 1.5f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "pbullet4" && pms.speedy)
        {
            ehealth -= 2;
            Destroy(other.gameObject);
        }


    }

    void goinUp()
    {
        eRBD.velocity = new Vector2(0, 10);
        eRBD.AddForce(speed * transform.right);
    }

    void goinDown()
    {
        eRBD.velocity = new Vector2(0, -10);
        eRBD.AddForce(speed * -transform.right);
    }

    void death()
    {
        if (ehealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    void fight()
    {
        if (pms.killedEnemies == 30)
        {
            Debug.Log("I've spawned!");
            gameObject.SetActive(true);
        }
    }

    void shoot()
    {
        Vector2 BulletSpawnPoints = new Vector2(gameObject.transform.position.x, Random.Range(gameObject.transform.position.y + 3, gameObject.transform.position.y - 3));
        Instantiate(ebullet, BulletSpawnPoints, Quaternion.identity);
    }
}
