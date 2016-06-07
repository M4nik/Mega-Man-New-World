using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMech : MonoBehaviour {

    Rigidbody2D PlayerRBD;
    public int JumpPower;
    public int SpeedMuti;
    float speed;
    public bool faceRight = true;
    public LayerMask jumplayers;
    public Transform grndCheckPos;
    bool onGround;
    public GameObject ElectricShot;
    Animator PlayerAnim;
    bool PlayerShoot;
    public bool BossToggle;
    public float PlayerAttackSec;
    bool PlayerWalking;
    float TimerAnim;        // to keep track of time
    public float TimerAnimShoot; // how long to keep gun out for
    public bool ShootPowerUp;
    public GameObject PowerShot;
    public int PowerShots;
    public int Health = 100;
    bool speedLess;
    bool speedMore;

	void Start () {
        PlayerRBD = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        speedMore = false;
        speedLess = false;
        BossToggle = false;
	}
	
	
	void Update () {
        GroundRayCast();
        Shoot();
        Powershot();
        WalkAttack();
        speed = Input.GetAxis("Horizontal") * SpeedMuti;
        PlayerAnim.SetFloat("speed", speed);
        switch (PlayerShoot)
        {
            case false:
                PlayerAnim.SetBool("Attack", false);
                break;
            case true:
                PlayerAnim.SetBool("Attack", true);
                break;
        }
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        if(PowerShots == 0)
        {
            ShootPowerUp = false;
        }
        if(Input.GetButtonDown("A") && onGround == true)
        {
            Jump();
        }

        if (PlayerShoot)
        {
            if(TimerAnim < TimerAnimShoot)
            {
                TimerAnim += Time.deltaTime;
            }
            else
            {
                TimerAnim = 0f;
                PlayerShoot = false;
            }
        }
    }


    void FixedUpdate()
    {
        PlayerRBD.velocity = new Vector2(speed, PlayerRBD.velocity.y);
    }


    void Jump()
    {
        PlayerRBD.velocity = new Vector2(PlayerRBD.velocity.x, JumpPower);
    }


    void GroundRayCast()
    {
        RaycastHit2D ground = Physics2D.Raycast(grndCheckPos.position, -Vector2.up, .1f, jumplayers);
        if (ground)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }


    void FlipSprite()
    {
        faceRight = !faceRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    void Shoot()
    {
        if (speed > 0 && !faceRight)
        {
            PlayerWalking = true;
            speedMore = true;
            FlipSprite();
        }
        if (speed < 0 && faceRight)
        {
            PlayerWalking = true;
            speedLess = true;
            FlipSprite();
        }
        if (PlayerWalking)
        {
            if (Input.GetButtonDown("B") && faceRight && !ShootPowerUp)
            {
                TimerAnim = 0f;
                PlayerShoot = true;
                Instantiate(ElectricShot, new Vector2(transform.position.x + 0.6f, transform.position.y + 0.4f), transform.rotation);
            }
            if (Input.GetButtonDown("B") && !faceRight && !ShootPowerUp)
            {
                TimerAnim = 0f;
                PlayerShoot = true;
                Instantiate(ElectricShot, new Vector2(transform.position.x + -0.8f, transform.position.y + 0.4f), transform.rotation);
            }
        }
    }
    void Powershot()
    {
        if(PlayerWalking == true)
        {
            if (Input.GetButtonDown("B") && faceRight && ShootPowerUp)
            {
                PowerShots--;
                TimerAnim = 0f;
                PlayerShoot = true;
                Instantiate(PowerShot, new Vector2(transform.position.x + 0.6f, transform.position.y + 0.4f), transform.rotation);
            }
            if (Input.GetButtonDown("B") && !faceRight && ShootPowerUp)
            {
                PowerShots--;
                TimerAnim = 0f;
                PlayerShoot = true;
                Instantiate(PowerShot, new Vector2(transform.position.x + -0.8f, transform.position.y + 0.4f), transform.rotation);
            }
        }
       
    }
    void WalkAttack()
    {
        switch(PlayerShoot && speedLess && speedMore)
        {
            case true:
                if (!PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("PlayerWalkAttack"))
                {
                    PlayerAnim.SetTrigger("WalkAttack");
                }
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ShootPowerup")
        {
            ShootPowerUp = true;
            PowerShots = 5;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EBullet")
        {
            Destroy(other.gameObject);
            Health = Health - 10;
        }
        if(other.gameObject.tag == "Bbullet")
        {
            Health = Health - 30;
            Destroy(other.gameObject);
        }

    }
}
