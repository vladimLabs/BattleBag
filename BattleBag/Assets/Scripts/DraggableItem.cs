using UnityEngine;
using UnityEngine.EventSystems;

namespace DragItem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private BagFight bagFight; // Ссылка на класс BagFight (если он используется)
        private RectTransform rectTransform; // RectTransform объекта
        private Item item; // Ссылка на компонент Item
        private Slot currentSlot; // Ссылка на текущий слот, если предмет над ним

        private void Start()
        {
            bagFight = FindObjectOfType<BagFight>();
            rectTransform = GetComponent<RectTransform>();
            item = GetComponent<Item>(); // Получаем ссылку на компонент Item
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Отключаем физику
            if (item != null)
            {
                item.DisablePhysics();
                Debug.Log("Физика отключена для предмета: " + item.itemName);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Перемещение предмета за курсором
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
            rectTransform.localPosition = localPoint; // Устанавливаем локальную позицию
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Проверяем, можно ли положить предмет в слот
            if (currentSlot != null)
            {
                Debug.Log("Предмет над слотом: " + currentSlot.gameObject.name);
                if (currentSlot.CanPlaceItem(item))
                {
                    currentSlot.PlaceItem(item); // Помещаем предмет в слот
                    Debug.Log("Предмет помещен в слот: " + currentSlot.gameObject.name);
                    // Не включаем физику для предмета
                }
                else
                {
                    Debug.Log("Слот занят: " + currentSlot.gameObject.name);
                    item.EnablePhysics(); // Включаем физику, если слот занят
                }
            }
            else
            {
                Debug.Log("Нет слота для размещения предмета.");
                item.EnablePhysics(); // Включаем физику, если нет слота
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) // Если предмет над слотом
            {
                currentSlot = other.GetComponent<Slot>(); // Получаем ссылку на слот
                Debug.Log("Предмет вошел в область слота: " + currentSlot.gameObject.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) // Если предмет покинул слот
            {
                Debug.Log("Предмет покинул область слота: " + currentSlot.gameObject.name);
                currentSlot = null; // Сбрасываем ссылку на слот
            }
        }
    }
}