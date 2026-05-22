using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Enemy enemy, Vector3 direction)
    {
        Rigidbody rigidbody = enemy.GetComponent<Rigidbody>();

        rigidbody.linearVelocity = direction * _speed;
    }
}