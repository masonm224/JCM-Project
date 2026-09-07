using UnityEngine;

//Important for running the Co
using System.Collections;

public class EnemyShoot : MonoBehaviour
{

        //This allows you to assign a FirePoint in the inspector (invisible object for direction of bullet travel)
    public Transform FirePoint;

    //Prefab Variant of player bullet
    [SerializeField] private GameObject EnemyBullet;

    //This is an empty that is a child to the player
    private Transform TargetForEnemy;
    
    void Start()
    {
        //This makes every new enemy with this script know players location without needing to assign in inspector everytime
        TargetForEnemy = GameObject.FindGameObjectWithTag("Player").transform;

        //this will move to be activated and deactivated by room starting later
        StartCoroutine(EnemyShootCoroutine());
    }

    IEnumerator EnemyShootCoroutine()
    {
        while (true)
        {
            EnemyShooting();

            yield return new WaitForSeconds(2f);
        }
    }

    void Update()
    {
        EnemyAim();
    }

    public void EnemyAim()
    {
        if (TargetForEnemy != null)
        {
            //rotates the enemy to aim at the player 
            Vector3 direction = TargetForEnemy.position - FirePoint.position;

            direction.y = 0;

            transform.forward = direction;

            //Debug log line to show where the bullet is aiming 
            Debug.DrawRay(FirePoint.position, FirePoint.forward * 15f, Color.red);
        }
        
        else
        {
        Debug.Log("TargetForEnemyNotFound");
        }
    }

    public void EnemyShooting()
    {

        Instantiate(EnemyBullet, FirePoint.position, FirePoint.rotation);

    }   
}
