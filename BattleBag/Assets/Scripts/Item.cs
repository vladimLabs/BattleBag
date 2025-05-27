using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Items;

namespace DragItem
{
    public class Item : MonoBehaviour
    {
        public string KeyName;
        public int Level { get; set; }
        public GameItem gameItem { get; set; }

        [SerializeField] private TextMeshProUGUI levelItem;

        public void GetInfoItem(string kName, int level)
        {
            Level = level;
            KeyName = kName;
            gameItem = ItemController.instance.GetGameItem(KeyName);
            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName);
            levelItem.text = Level.ToString();
        }

        public void UpgradeLevel()
        {
            Level++;
            levelItem.text = Level.ToString();
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