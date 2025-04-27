using UnityEngine;

public class ForNoteBulletSpawner : MonoBehaviour
{
    [SerializeField] private ForNoteBulletUpdater bulletPrefab;
    
    public void SpawnBullet(Vector3 arrival, float _lifeTime)
    {
        ForNoteBulletUpdater newUpdater = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
        newUpdater.SetDestination(transform.position);
        newUpdater.SetArrival(arrival);
        newUpdater.SetArriveTime(_lifeTime);
    }
}