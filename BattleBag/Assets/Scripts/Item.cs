using UnityEngine;
using UnityEngine.UI;
using Items;

namespace DragItem
{
    public class Item : MonoBehaviour
    {
        private string KeyName;
        private int itemID;
        public GameItem gameItem { get; set; }

        public void GetInfoItem(string kName)
        {
            //itemID = iId;
            KeyName = kName;
            gameItem = ItemController.instance.GetGameItem(KeyName);
            GetComponent<Image>().sprite = Resources.Load<Sprite>(KeyName);
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