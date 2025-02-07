using Unity.Cinemachine;
using UnityEngine;

public class DeathFromWeapon : MonoBehaviour
{
    [SerializeField] private PlayerMovement _PlayerMovementClass;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private DronExplosion _dronExplosionClass;
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private CameraTarget _nullTarget;
    //[SerializeField] private AudioManager _audioClass;

    private void Start()
    {
        //_camera.Target = _nullTarget;
        //_death.transform.position = transform.position;
        //_dronExplosionClass.Explode();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _camera.Target = _nullTarget;
            _death.transform.position = transform.position;
            _dronExplosionClass.Explode();
            //_death.Play();
            //_audioClass.FlySound();
        }
    }
}
