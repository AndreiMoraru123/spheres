using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = System.Numerics.Vector3;

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
        Vector2 movement = context.ReadValue<Vector2>(); // callback for hitting arrow keys
        _mRollingMovement.mMovementDirection = new UnityEngine.Vector3(movement.x, 0f, movement.y);
    }
}
