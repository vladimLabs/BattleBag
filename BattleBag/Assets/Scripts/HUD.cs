using Shop;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    [SerializeField] private TextMeshProUGUI coinCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowInfo(float coin)
    {
        coinCount.text = coin.ToString();
    }
}
