using UnityEngine;

public class ForNoteBulletSpawner : MonoBehaviour
{
    [SerializeField] private ForNoteBulletUpdater bulletPrefab;
    
    public void SpawnBullet(Vector3 arrival, float _lifeTime)
    {
        ANoteUpdater newUpdater = NotePoolManager.Instance.SpawnNote(ENoteType.ForBullet, transform.position, Quaternion.identity, transform);
        newUpdater.SetDestination(transform.position);
        newUpdater.SetArrival(arrival);
        newUpdater.SetArriveTime(_lifeTime);
    }
}