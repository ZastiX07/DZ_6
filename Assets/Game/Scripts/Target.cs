using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;

    [SerializeField] private float _speed = 1.0f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float time = Mathf.PingPong(Time.time * _speed, 1f);

        Vector3 newPosition = Vector3.Lerp(_pointA.transform.position, _pointB.transform.position, time);

        transform.position = newPosition;
    }
}