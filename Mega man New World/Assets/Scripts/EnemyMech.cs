using UnityEngine;
using System.Collections;

public class EnemyMech : MonoBehaviour
{
    bool CanTurn;
    public int Cooldown;
    public int Speed;
    Rigidbody2D EnemyRBD;
    public bool faceRight = true;
    public int EnemyHealth;
    public GameObject ShootPowerUp;
    Transform PlayerTransform;
    public GameObject EBullet;
    float TDifference;
    public bool CanShoot;
    CameraMech Camera;



    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMech>();
        CanTurn = true;
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyRBD = GetComponent<Rigidbody2D>(); 
        if(Speed > 0)
        {
            if (CanTurn)
            {
                InvokeRepeating("Walk", 1, Cooldown);
            }
        }
    }               

    void Update()
    {
        if (Camera.PlayerDestroy == false)
        {
            TDifference = transform.position.x - PlayerTransform.position.x;
            if (TDifference < 12)
            {
                CancelInvoke("Walk");
                if (CanShoot)
                {
                    InvokeRepeating("Shoot", 1f, 1f);
                    CanShoot = false;
                }
            }
        }
        
        if(EnemyHealth == 0)
        {
            Destroy(gameObject);
        }
        ShootPowerup();
    }
    void Walk()
    {
        if(Speed > 0)
        {
            if (EnemyRBD.velocity.x > 0)
            {
                EnemyRBD.velocity = new Vector2(-Speed, 0);
                FlipSprite();
                return;
            }

            if (EnemyRBD.velocity.x <= 0)
            {
                EnemyRBD.velocity = new Vector2(Speed, 0);
                if (!faceRight)
                {
                    FlipSprite();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "pBullet")
        {
            Destroy(other.gameObject);
            EnemyHealth = EnemyHealth - 10;
        }
        if(other.gameObject.tag == "PowerShot")
        {
            EnemyHealth = EnemyHealth - 20;
        }
    }
    void FlipSprite()
    { 
            faceRight = !faceRight;
            Vector2 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
    }
    void ShootPowerup()
    {
        if(EnemyHealth == 0)
        {
            Instantiate(ShootPowerUp, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }
    }
    void Shoot()
    {
        Instantiate(EBullet, transform.position, transform.rotation);
    }
}