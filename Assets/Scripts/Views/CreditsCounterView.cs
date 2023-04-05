using TMPro;
using UnityEngine;

public class CreditsCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentCredits;
    [SerializeField] private TMP_Text _topCredits;

    public void Init(int currentCredits)
    {
        ChangeCurrentCreditsCount(currentCredits);
        ChangeTopCreditsCount(0);
    }

    public void ChangeCurrentCreditsCount(int currentCredits)
    {
        _currentCredits.text = currentCredits.ToString();
    }
    public void ChangeTopCreditsCount(int currentCredits)
    {
        _topCredits.text = currentCredits.ToString();
    }
    
    
}
