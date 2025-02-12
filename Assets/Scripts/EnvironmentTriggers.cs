using UnityEngine;

public class EnvironmentTriggers : MonoBehaviour
{
    [SerializeField] private Rigidbody _sword;
    [SerializeField] private Animator[] _weaponsAnim;
    [SerializeField] private GameObject _mount;
    [SerializeField] private GameObject _tunnel;
    [SerializeField] private GameObject[] _hideMountains;
    [SerializeField] private GameObject _tunnelExit;
    [SerializeField] private GameObject _visualEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerWeapons"))
        {
            _sword.useGravity = true;

            for (int i = 0; i < _weaponsAnim.Length; i++)
            {
                _weaponsAnim[i].SetBool("IsStarted", true);
            }
        }

        if (other.CompareTag("TriggerMountains"))
        {
            _mount.SetActive(false);
        }

        if (other.CompareTag("TriggerTunnel"))
        {
            for (int i = 0; i < _hideMountains.Length; i++)
            {
                _hideMountains[i].SetActive(false);
            }

            _visualEffect.SetActive(false);
            _tunnel.SetActive(true);
            _tunnelExit.SetActive(true);

        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("TriggerTunnel"))
    //    {
    //        for (int i = 0; i < _hideMountains.Length; i++)
    //        {
    //            _hideMountains[i].SetActive(true);
    //        }
    //        _tunnel.SetActive(false);
    //    }
    //}
}
