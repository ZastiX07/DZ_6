using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Mover _mover;
    [SerializeField] private int _count = 1;

    private Vector3 _direction = Vector3.forward;

    public void Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            Enemy enemy = Instantiate(_prefab, transform.position, Quaternion.identity);

            if (_mover != null && _prefab != null)
                _mover.Move(enemy, _direction);
        }
    }
}