using UnityEngine;
using UnityEngine.UI;

public class IceManager : MonoBehaviour
{
    public static IceManager Instance { get; private set; }
    [SerializeField]
    Text iceText;
    int ice = 0;
    public int Ice
    {
        get => ice;
        set
        {
            ice = value;
            iceText.text = $"{ice}";
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}