using UnityEngine;
using UnityEngine.InputSystem;

public class ReticleScript : MonoBehaviour
{
    private Camera mainCamera;

    //This makes a layer mask that we can assign in the inspector, helps with aiming the reticle
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
                  //important same as calling the camera component     Reference video if needed
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMousePosition();
        Aim();
    }

                  //Method to have object follow the mouse 
    private (bool success, Vector3 position) FollowMousePosition()
    { 
                 //This cast a ray from the camera to the mouses current position
        var ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());          
       
                
                 //as a side note this functions nicely for preventing the reticle from leaving the player area
                 //reticle only moves if the layer is ground, make sure to change when importing completed ground 
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundLayer))
        {
                //The raycast hit something, returns the position
            return (success: true, position: hitInfo.point);
        }
        else
        {
                //The Raycast did not hit anything
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = FollowMousePosition();
        if (success)
        {
                //calculate direction
            var direction = position - transform.position;

                // This makes it so the reticle does not move up while aiming
            direction.y = 0;

                //Make the transform look in the direction
            transform.forward = direction;
        }
    
    }  
}
