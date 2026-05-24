using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        WaitForSeconds wait = new WaitForSeconds(_timeWaitShooting);
        
        while (isWork)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;

            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            newBullet.Initialize(direction, _speed);

            yield return wait;
        }
    }
}