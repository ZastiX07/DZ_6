using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private float _number;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;

            Rigidbody newBullet = Instantiate(_rigidbody, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.linearVelocity = direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}