using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform mTarget;

    [SerializeField] private float mRetargetingSPeed = 2f;

    private RollingMovement _mRollingMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Gather components
        _mRollingMovement = GetComponent<RollingMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // point the direction vector towards the target
        var mTargetDirection = mTarget.position - transform.position;

        // if the sphere is close, set the retarget speed to be high
        // otherwise, use the typical retargeting speed
        var retargetSpeed = Vector3.SqrMagnitude(mTargetDirection) < 0.1f ? 1000f : mRetargetingSPeed;

        // linearly interpolate the movement vector from the current direction to the target
        // where (T) is fixed delta time multiplied by the retargeting speed
        _mRollingMovement.mMovementDirection = Vector3.Lerp(_mRollingMovement.mMovementDirection,
            mTargetDirection.normalized, Time.fixedDeltaTime * retargetSpeed);
    }
}