using UnityEngine;
using UnityEngine.UI;

namespace DragItem
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage; // Изображение слота
        private Color originalColor;
        private bool occupied = false; // Состояние слота

        private void Awake()
        {
            originalColor = slotImage.color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item")) // Если предмет над слотом
            {
                // Увеличиваем непрозрачность до 10%
                Color color = slotImage.color;
                color.a = 0.1f; // 10% непрозрачности
                slotImage.color = color;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item")) // Если предмет покинул слот
            {
                // Убираем непрозрачность
                Color color = slotImage.color;
                color.a = 0f; // 0% непрозрачности
                slotImage.color = color;
            }
        }

        public bool CanPlaceItem(Item item)
        {
            return !occupied; // Проверяем, свободен ли слот
        }

        public void PlaceItem(Item item)
        {
            if (!occupied) // Проверяем, свободен ли слот
            {
                item.transform.position = transform.position; // Перемещаем предмет в позицию слота
                item.DisablePhysics(); // Отключаем физику у предмета
                SetOccupied(true); // Устанавливаем слот как занятый
                Debug.Log("Предмет помещен в слот: " + gameObject.name);
            }
            else
            {
                Debug.Log("Не удалось поместить предмет, слот занят: " + gameObject.name);
            }
        }

        public bool IsOccupied()
        {
            return occupied;
        }

        public void SetOccupied(bool value)
        {
            occupied = value;
        }
    }
}