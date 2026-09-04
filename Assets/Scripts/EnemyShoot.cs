using UnityEngine;

public class EnemyShoot : MonoBehaviour
{



    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private GameObject TargetForEnemy;
    


    void Start()
    {
        
    }

    





    void Update()
    {
        
    }

    public void Shooting()
    {

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

    }   


}
