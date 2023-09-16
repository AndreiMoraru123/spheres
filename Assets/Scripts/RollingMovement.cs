using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    [SerializeField] private float mSpeed = 1f;
    private Rigidbody _mRigidbody;
    [HideInInspector] public Vector3 mMovementDirection;
    private Vector3 _mStartPosition;
    
    void Start()
    {
        // Gather components and variables that will be needed later
        _mRigidbody = GetComponent<Rigidbody>();
        _mStartPosition = transform.position; // need the starting position for when we reset the game
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Every physics tick, add a force equal to the movement vector multiplied by speed
        _mRigidbody.AddForce(mMovementDirection * mSpeed);
    }

    public void ResetPosition()
    {
        // Reset the velocity to zero and set the position back to start
        _mRigidbody.velocity = Vector3.zero; // not moving
        _mRigidbody.angularVelocity = Vector3.zero;
        transform.position = _mStartPosition; // go back to starting position
    }
}
