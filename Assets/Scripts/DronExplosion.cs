using UnityEngine;

public class DronExplosion : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Rigidbody _mainRB;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode()
    {
        for(int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
            _rigidbodies[i].AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 3, ForceMode.Impulse);
        }
        _mainRB.useGravity = true;
        _mainRB.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 3, ForceMode.Impulse);
    }

    
}
