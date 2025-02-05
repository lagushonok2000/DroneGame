using UnityEngine;

public class Kristall : MonoBehaviour
{
    [SerializeField] private Counts _countsClass;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
            _countsClass.AddCount(1);
        }
    }
}
