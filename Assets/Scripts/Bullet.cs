using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public float lifeTime = 2f;

    public float damage = 10f;

    //Health Functions
    private Health health;

    void Start()
    {
        //First is object destroyed in defined "lifetime"
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //checks Wall tag
        if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        //checks Enemy tag
        if(other.CompareTag("Enemy"))
        {        
            //this checks the value assigned to the object in the inspector
            health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            // tag or not gets destroyed
                Destroy(gameObject);
        }

        //Checks Player tag
        if(other.CompareTag("Player"))
        {
            health = other.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }

        }
        // leave wall tag in for effects. Just add more tag interference if needed with more if statements

        //Anything else with a collider just makes the bullet die
        Destroy(gameObject);
    }
}
