using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;

namespace Fight
{
    public class PanelEndFight : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI winer;
        [SerializeField] private TextMeshProUGUI countWin;
        [SerializeField] private TextMeshProUGUI countLose;
        [SerializeField] private TextMeshProUGUI countFight;

        private int _countFight = 5;

        public void ShowInfo(string lose)
        {
            int w = PlayerPrefs.GetInt("win");
            int l = PlayerPrefs.GetInt("lose");
            switch (lose)
            {
                case "enemy":
                    winer.text = "Вы";
                    w++;
                    PlayerPrefs.SetInt("win", w);
                    break;
                case "person":
                    winer.text = "Враг";
                    l++;
                    PlayerPrefs.SetInt("lose", l);
                    break;
            }

            countWin.text = w.ToString();
            countLose.text = l.ToString();
            countFight.text = (_countFight - w - l).ToString();

            PlayerPrefs.SetFloat("coin", PlayerPrefs.GetFloat("coin") + 100);
            PlayerPrefs.SetFloat("win", 0);
            PlayerPrefs.SetFloat("lose", 0);

        }
    }
}
