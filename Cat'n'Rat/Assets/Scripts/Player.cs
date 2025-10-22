using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float JumpHeight;
    private bool jumping = false;
    private Animator animator;

    private bool isPowerUp = false;
    private float PowerTime = 5;
    public float DefaultPowerUpTime = 5;
    private float PowerUpTimeRemain = 5;

    public float fireTimer = 0.5f;
    public float fireCountdown = 0;
    public GameObject ProjectilePrefad;
    int direction = 1;

    public bool Powered = false;

    private Vector2 startPosition;

    

    public int Lives = 3;
    public Image PowerTimer;
    [SerializeField] private UI_Manager ui;


        //Start function.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        ui = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
        //Update function.
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;

        if(position.y < -8.5)
        {
            position = startPosition;
        }
        else
        {
            position.x = position.x+(speed * Time.deltaTime * move);   
        }
        
        transform.position = position;

        //Update Animation.
        updateAnimation(move);

        if(Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(new Vector2(0, Mathf.Sqrt(-2 * Physics2D.gravity.y * JumpHeight)), ForceMode2D.Impulse);
            jumping = true;
        }


            //Fire function.
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject Projectile = Instantiate(ProjectilePrefad,
            rb.position, Quaternion.identity);
            Projectile pr = Projectile.GetComponent<Projectile>();
            pr.Powered = Powered;
            pr.Launch(new Vector2(animator.GetInteger("Direction"), 0), 300);
        }


                    //power up
        if (isPowerUp)
        {
            PowerUpTimeRemain -= Time.deltaTime;

            ui.PowerTimer.fillAmount = PowerUpTimeRemain / DefaultPowerUpTime;

            if(PowerUpTimeRemain < 0)
            {
                isPowerUp = false;
                PowerUpTimeRemain = DefaultPowerUpTime;
                Powered = false;
                animator.speed /= 2;
            }
        }

    }



            //more Animation.
    private void updateAnimation(float Move)
    {
        animator.SetFloat("Move", Move);
        if(Move > 0)
        {
        animator.SetInteger("Direction", 1);
        }
        else if (Move < 0)
        {
            animator.SetInteger("Direction", -1);
        }
    }

            //Jump Check.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;

        //Loss of life.
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT");
            Lives--;
            
            ui.UpdateLives(Lives);
            if(Lives <= 0)
        {
            SceneManager.LoadScene("StartScene");
        }
            transform.position = startPosition;
        }
    }


            //Collision Boost for Item
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boost")
        {
            Destroy(collision.gameObject);
            Powered = true;
            isPowerUp = true;
            animator.speed *= 2;

            //PowerTimer.enabled = true;
        }
        
    }



        public void fire()
        {
            if (fireCountdown < 0)
            {
                fireCountdown = fireTimer;
                GameObject Projectile = Instantiate(ProjectilePrefad, GetComponent<Rigidbody2D>().position, Quaternion.identity);
                Projectile script = Projectile.GetComponent<Projectile>();
                script.Launch(new Vector2(direction, 0), 300);
            }

        }


}
