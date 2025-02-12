using UnityEngine;

public class WeaponStarts : MonoBehaviour
{
    [SerializeField] private Rigidbody _sword;
    [SerializeField] private Animator[] _weaponsAnim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerWeapons"))
        {
            _sword.useGravity = true;

            for (int i = 0; i < _weaponsAnim.Length; i++)
            {
                _weaponsAnim[i].SetBool("IsStarted", true);
            }
        }
    }
}
