using TMPro;
using UnityEngine;

public class CreditsCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentCredits;

    public void Init(int currentCredits)
    {
        ChangeCreditsCount(currentCredits);
    }

    public void ChangeCreditsCount(int currentCredits)
    {
        _currentCredits.text = currentCredits.ToString();
    }
}