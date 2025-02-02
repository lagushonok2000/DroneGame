using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _launchForce;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private float _bulletsFrequency;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    public  IEnumerator Attack()
    {
        while (true)
        {
          CreateAndAttack();
          yield return new WaitForSeconds(_bulletsFrequency);
        }
    }

    public IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet); 
    }

    private void CreateAndAttack()
    {
        GameObject obj = Instantiate(_bullet);
        obj.transform.position = _spawner.transform.position;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(_spawner.forward * _launchForce, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(obj, _bulletLifetime));
    }
}
