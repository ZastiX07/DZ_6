using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Mover _mover;
    [SerializeField] private float _cooldown = 2f;
    [SerializeField] private int _count = 1;

    private Vector3 _direction = Vector3.forward;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < _count; i++)
            {
                GameObject gameObject = Instantiate(_prefab, transform.position, Quaternion.identity);

                Enemy enemy = gameObject.GetComponent<Enemy>();

                if (_mover != null && _prefab != null)
                    _mover.Move(enemy, _direction);
            }

            yield return new WaitForSeconds(_cooldown);
        }
    }
}