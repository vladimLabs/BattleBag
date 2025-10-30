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

        public void ShowInfo(string loser)
        {
            int win = PlayerPrefs.GetInt("win");
            int lose = PlayerPrefs.GetInt("lose");
            switch (loser)
            {
                case "enemy":
                    winer.text = "Вы";
                    win++;
                    PlayerPrefs.SetInt("win", win);
                    break;
                case "person":
                    winer.text = "Враг";
                    lose++;
                    PlayerPrefs.SetInt("lose", lose);
                    break;
            }

            countWin.text = win.ToString();
            countLose.text = lose.ToString();
            countFight.text = (_countFight - win - lose).ToString();

            if(_countFight <= 0 || lose >= 3)
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            PlayerPrefs.SetInt("win", 0);
            PlayerPrefs.SetInt("lose", 0);
        }
    }
}
