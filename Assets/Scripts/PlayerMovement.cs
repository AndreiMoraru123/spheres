using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private RollingMovement _mRollingMovement;
    
    void Start()
    {
        // Gather components
        _mRollingMovement = GetComponent<RollingMovement>();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Get the movement vector and apply it to the RollingMovement component
        var  movement = context.ReadValue<Vector2>(); // callback for hitting arrow keys
        _mRollingMovement.mMovementDirection = new Vector3(movement.x, 0f, movement.y);
    }
}
