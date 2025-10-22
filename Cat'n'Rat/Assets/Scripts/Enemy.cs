using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int direction = -1;
    public float speed;
    public float JumpSpeed;

    bool isDead = false;
    public float DieTime;
    public int Health;
    public int DieCount = 0;

    private bool Ratjumping = false;
    public int JumpChance = 5;

    public GameObject Spawner;
    private Spawn spawn;

    public GameObject HelpSpawner;
    private HelpSpawn help;

    //private float increaseSpeed = 0;
    
    void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
        spawn = GameObject.Find("Spawner").GetComponent<Spawn>();
        help = GameObject.Find("HelpSpawner").GetComponent<HelpSpawn>();

    }

    void Update()
    {
                                                        //maybe make a random speed variable, and a random chance to jump.

        System.Random random = new System.Random();
        int MayJump = random.Next(1, JumpChance+1);

        if (!isDead)
        {
            //increaseSpeed = increaseSpeed+0.000001f;

            Vector2 pos = transform.position;
            pos.x = pos.x + (speed * Time.deltaTime * direction);
            
            transform.position = pos;

            //speed = speed+increaseSpeed;

            //Debug.Log("The speed is:"+speed);
            //Debug.Log("the speed increase is:"+increaseSpeed);


            if(MayJump == JumpChance && Ratjumping == false)
        {
            //Debug.Log("Jump?");

            Vector2 pos2 = transform.position;
            pos2.y = pos2.y - (JumpSpeed * Time.deltaTime * direction);

            transform.position = pos2;

            //Ratjumping = true;
        }

        }
        else
        {
            DieTime -= Time.deltaTime;
            if (DieTime < 0)
            {
                spawn.DieCount++;
                help.DieCount++;
                //Debug.Log("Dead "+spawn.DieCount);

                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            Ratjumping = false;
        }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            Health--;
                if(Health <= 0)
            {
                isDead = true;
            }
        }
    }
}
