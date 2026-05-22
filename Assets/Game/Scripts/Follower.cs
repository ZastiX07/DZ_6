using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Target _target;

    private void Update()
    {
        Follow();
    }

    public void Follow()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }


    public void SetTarget(Target target)
    {
        _target = target;
    }
}