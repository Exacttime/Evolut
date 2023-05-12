using UnityEngine;

public class Jump : MonoBehaviour
{    
    private PlayerController playerController;
    public bool IsGrounded()
    {   
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down, out hit, playerController.ray, playerController.floorLayer))
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}
