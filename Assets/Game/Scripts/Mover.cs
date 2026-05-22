using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    
    public void Move(Enemy enemy, Vector3 direction)
    {
        if (enemy.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.linearVelocity = direction * _speed;
        }
    }
}