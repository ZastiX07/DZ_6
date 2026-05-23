using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private float _number;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;

            GameObject newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().linearVelocity = direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}