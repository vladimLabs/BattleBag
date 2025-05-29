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

        [SerializeField] private TextMeshProUGUI levelItem;

        public void GetInfoItem(string kName)
        {
            //Level = level;
            KeyName = kName;
            gameItem = ItemController.instance.GetGameItem(KeyName);
            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName+gameItem.Level.ToString());
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
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // Устанавливаем в кинематический режим
            }
        }

        public void EnablePhysics()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // Устанавливаем в режим, реагирующий на физику
            }
        }
    }
}