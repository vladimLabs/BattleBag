using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Items;

namespace DragItem
{
    public class Item : MonoBehaviour
    {
        public string KeyName;
        private GameItem gameItem;
        Rigidbody2D rb;


        [SerializeField] private TextMeshProUGUI levelItem;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void GetInfoItem(string kName)
        {
            KeyName = kName;
            gameItem = ItemController.instance.GetGameItem(KeyName);
            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName+gameItem.Level.ToString());
            levelItem.text = gameItem.Level.ToString();
        }

        public void LoadInfoItem(string kName, float level)
        {
            KeyName = kName;
            gameItem.Level = level;

            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName + gameItem.Level.ToString());
            levelItem.text = gameItem.Level.ToString();
        }

        public GameItem GameItem()
        {
            return gameItem;
        }

        public void UpgradeLevel()
        {
            gameItem.Level++;
            levelItem.text = gameItem.Level.ToString();
            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName + gameItem.Level.ToString());
        }

        public void DisablePhysics()
        {
            if (rb != null)
            {
                rb.isKinematic = true; // Устанавливаем в кинематический режим
            }
        }

        public void EnablePhysics()
        {
            if (rb != null)
            {
                rb.isKinematic = false; // Устанавливаем в режим, реагирующий на физику
            }
        }
    }
}