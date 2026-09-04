using UnityEngine;

//This is important for Input System Usage
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
                //This allows you to assign a FirePoint in the inspector (invisible object for direction of bullet travel)
   public Transform FirePoint;

    PlayerInput playerInput;
    InputAction ShootPistol;

   [SerializeField] private GameObject bulletPrefab;

                //This references the ReticleScript so that the method can be called in Shooting()
   ReticleScript reticleScript;

    void Start()
    {
        
        playerInput = GetComponent<PlayerInput>();

        //Searching witin the InputActionSystem for the Action Labeled -ShootPistol-
        ShootPistol = playerInput.actions.FindAction("ShootPistol");


        reticleScript = GetComponentInChildren<ReticleScript>();

    }

    
    void Update()
    {
        if (ShootPistol != null && ShootPistol.WasPressedThisFrame())
        {
            Shooting();
        }

//============== 
    if (ShootPistol == null)
    {
        Debug.Log("ShootPistol is NULL");
        return;
    }

    if (ShootPistol.WasPressedThisFrame())
    {
        Debug.Log("Mouse Click Detected");
    }
        //===============
    }

    public void Shooting()
    {

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

    }
}
