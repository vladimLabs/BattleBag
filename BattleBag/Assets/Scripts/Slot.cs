using UnityEngine;
using UnityEngine.UI;
using Items;

namespace DragItem
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage;
        private bool occupied = false; //Состояние слота (занят ли)
        [SerializeField] private int index;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item") && !occupied) //Если предмет над слотом
            {
                ChangeColor(0.1f);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item") && !occupied) //Если предмет покинул слот
            {
                ChangeColor(0);
            }
        }

        public void ChangeColor(float parametr)
        {
            //Назначаем непрозрачность
            Color color = slotImage.color;
            color.a = parametr;
            slotImage.color = color;
        }

        public bool CanPlaceItem()
        {
            return !occupied; //Проверяем, свободен ли слот
        }

        public void PlaceItem(Item item)
        {
            if (!occupied) //Проверяем, свободен ли слот
            {
                item.transform.position = transform.position; // Перемещаем предмет в позицию слота
                SetOccupied(true); //Устанавливаем слот как занятый
                ChangeColor(0);
                ItemController.instance.SlotOccupied(item.gameItem, index);
                Debug.Log("Предмет помещен в слот: " + gameObject.name);
            }
            else
            {
                Debug.Log("Не удалось поместить предмет, слот занят: " + gameObject.name);
            }
        }

        public void DelItem()
        {
            ItemController.instance.SlotUnOccupied(index);
            SetOccupied(false); //Устанавливаем слот как свободный
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