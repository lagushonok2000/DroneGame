using UnityEngine;

public class DeathFromWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private AudioManager _audioClass;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            gameObject.SetActive(false);
            _death.transform.position = transform.position;
            _death.Play();
            _audioClass.FlySound();
        }
    }
}
