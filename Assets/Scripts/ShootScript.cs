using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Transform _vodkaSpawnPoint;
    [SerializeField] private Transform _waterSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject spawnedBullet=Instantiate(_bulletPrefab, _waterSpawnPoint.position, Quaternion.Euler(this.transform.rotation.eulerAngles.x+90f, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z));
            spawnedBullet.GetComponent<Bullet>().IsWater = true;
        }
        if(Input.GetMouseButtonDown(1))
        {
            GameObject spawnedBullet = Instantiate(_bulletPrefab, _vodkaSpawnPoint.position, Quaternion.Euler(this.transform.rotation.eulerAngles.x + 90f, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z));
            spawnedBullet.GetComponent<Bullet>().IsWater = false;
        }
    }

    //public void ShootBullet(Transform bulletSpawnPoint)
    //{
        

    //}
}
