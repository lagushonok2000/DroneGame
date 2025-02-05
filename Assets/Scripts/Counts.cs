using TMPro;
using UnityEngine;

public class Counts : MonoBehaviour
{
    [SerializeField] private TMP_Text _countsText;
    private int _count;

    public void AddCount(int add)
    {
        _count += add;
        _countsText.text = _count.ToString() + "/50";
    }
}
