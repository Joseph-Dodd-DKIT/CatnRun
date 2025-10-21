using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    int direction = -1;
    public float speed;

    bool isDead = false;
    public float DieTime;
    public int Health;

    private bool Ratjumping = false;
    public int JumpChance;
    public float JumpHeight;
    
    void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
                                                        //maybe make a random speed variable, and a random chance to jump.

        System.Random random = new System.Random();
        int MayJump = random.Next(0, JumpChance);

        if(MayJump == JumpChance && Ratjumping == false)
        {
            Debug.Log("Jump?");

            rb.AddForce(new Vector2(0, Mathf.Sqrt(-2 * Physics2D.gravity.y * JumpHeight)), ForceMode2D.Impulse);
            Ratjumping = true;
        }


        if (!isDead)
        {
            Vector2 pos = transform.position;
            pos.x = pos.x + (speed * Time.deltaTime * direction);
            transform.position = pos;
        }
        else
        {
            DieTime -= Time.deltaTime;
            if (DieTime < 0)
            {
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
