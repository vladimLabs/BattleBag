using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    /*private void Start()
    {
        if(PlayerPrefs.GetInt("win") > 0 || PlayerPrefs.GetInt("lose") > 0)
        {
            panelMenu.SetActive(false);
        }
        else
        {
            panelMenu.SetActive(true);
        }
    }*/
    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("coin", 100);
        HUD.instance.ShowInfo(PlayerPrefs.GetFloat("coin"));
    }
}
