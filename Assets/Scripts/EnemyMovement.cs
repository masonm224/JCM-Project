using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    public float moveSpeed = 2f;
    public float preferredDistance = 8f; // How far-close the enemy wants to be from the player
    public float directionChangeTime = 2f; //How often enemy picks a new direction to walk in
    public float strafeChangeTime = 4f;
    public float strafeAmount = 0.5f; //How strong the strafing will be

    [SerializeField] private Transform targetForEnemy;

    private Vector3 moveDirection;
    private float directionTimer;
    private float strafeTimer;
    private float strafeDirection;

    void Start()
    {
        ChooseNewDirection();

        strafeDirection = Random.value > 0.5f ? 1f : -1f;
    }

    void Update()
    {
        directionTimer -= Time.deltaTime;
        strafeTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
        {
            ChooseNewDirection();
        }

        if(strafeTimer <= 0f)
        {
            ChooseStrafeDirection();
        }
        
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    //this whole function basically has the enemy move to be X meters from the player
    void ChooseNewDirection()
    {
        Vector3 directionToPlayer = targetForEnemy.position - transform.position;
        directionToPlayer.y = 0f;

        float distanceToPlayer = directionToPlayer.magnitude;

        
        if (distanceToPlayer > preferredDistance)
        {
            //Too far move towards player
            float randomAngle = Random.Range(-45f, 45f);

            Vector3 towardPlayer = Quaternion.Euler(0f, randomAngle, 0f) * directionToPlayer.normalized;

            //Clockwise or counter clockwise
            Vector3 sideways = Vector3.Cross(Vector3.up, towardPlayer) * strafeDirection;

            moveDirection = (towardPlayer + sideways * strafeAmount).normalized;
        }
        
        else
        {
            //Too close move away player
            float randomAngle = Random.Range(-45f, 45f);

            Vector3 awayFromPlayer = Quaternion.Euler(0f, randomAngle, 0f) * -directionToPlayer.normalized;  
            
            //Clockwise or Counter Clockwise
            Vector3 sideways = Vector3.Cross(Vector3.up, awayFromPlayer) * strafeDirection;

            moveDirection = (awayFromPlayer + sideways * strafeAmount).normalized;
        }

        directionTimer = directionChangeTime;
    }

    void ChooseStrafeDirection()
    {
        strafeDirection = Random.value > 0.5f ? 1f : -1f;
        strafeTimer = strafeChangeTime;
    }
}
