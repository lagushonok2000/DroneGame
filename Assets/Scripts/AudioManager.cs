using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _flySound;

    public void DeathSound()
    {
        _deathSound.Play();
    }

    public void FlySound()
    {
        _flySound.Play();
    }
}
