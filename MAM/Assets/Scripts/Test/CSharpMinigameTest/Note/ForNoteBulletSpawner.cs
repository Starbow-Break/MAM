using UnityEngine;

public class ForNoteBulletSpawner : MonoBehaviour
{
    [SerializeField] private ForNoteBulletUpdater bulletPrefab;

    public void SpawnBullet(float speed, float lifeTime)
    {
        ForNoteBulletUpdater newUpdater = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newUpdater.SetSpeed(speed);
        newUpdater.SetLifeTime(lifeTime);
    }
}
