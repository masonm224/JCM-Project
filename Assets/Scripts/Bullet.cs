using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    //How long bullet will go before it gets destroyed
    public float lifeTime = 2f;


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
        Destroy(gameObject);
    }
}
