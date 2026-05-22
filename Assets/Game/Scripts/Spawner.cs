using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    [SerializeField] private int _count = 1;

    public void Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);
        }
    }
}