using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform mTarget;
    [SerializeField] private Vector3 mBoardCenter;
    private Vector3 _mOffset;

    void Start()
    {
        // calculate the offset at the start
        _mOffset = transform.position - mBoardCenter;
    }

    // Update is called once per frame
    void Update()
    {
        // set the movement target to the target's position plus an X and Z offset
        var position = transform.position;

        var targetPosition = mTarget.position;

        var target = new Vector3(targetPosition.x + _mOffset.x,
            position.y,
            targetPosition.z + _mOffset.z);

        // linearly interpolate the position from the current position to the target
        transform.position = Vector3.Lerp(position, target, Time.deltaTime);
    }
}