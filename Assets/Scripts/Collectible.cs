using UnityEngine;

public class Collectible : MonoBehaviour
{
    private const float Range = 0.4f;
    private Vector3 _mStartPosition;

    void Start()
    {
        _mStartPosition = transform.position;
    }
    
    void OnTriggerStay(Collider other)
    {
        // if the other GameObject has a Score component, increment it
        other.gameObject.GetComponent<Score>().IncrementScore();

        // move the position of the collectible to a new random position within the board bounds
        transform.position = new Vector3(
            Random.Range(-Range, Range), 
            transform.position.y,
            Random.Range(-Range, Range)
            );
    }

    public void ResetPosition()
    {
        transform.position = _mStartPosition;
    }
}