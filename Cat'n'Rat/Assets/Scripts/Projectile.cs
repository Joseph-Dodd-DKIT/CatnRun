using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int ShotSpeed = 3;
    public bool Powered;

    Rigidbody2D rbody;
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rbody.AddForce(direction * force * ShotSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Powered == false)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 15);
        }
    }
    
}
