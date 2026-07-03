using UnityEngine;
using TMPro;

public class DropdownSync : MonoBehaviour
{
    private void Start()
    {
        TMP_Dropdown myDropdown = GetComponent<TMP_Dropdown>();
        int savedValue = PlayerPrefs.GetInt("diff_key", 0);

        myDropdown.SetValueWithoutNotify(savedValue);
    }
}