using UnityEngine;
using UnityEngine.EventSystems;

namespace DragItem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Item item;
        private Slot currentSlot;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            item = GetComponent<Item>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (currentSlot != null)
            {
                //Debug.Log("забираем " + currentSlot.GetComponent<Slot>().name);
                currentSlot.GetComponent<Slot>().DelItem();
            }
            //Отключаем физику
            if (item != null)
            {
                item.DisablePhysics();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Перемещение предмета за курсором
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
            rectTransform.localPosition = localPoint;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Проверяем, можно ли положить предмет в слот
            if (currentSlot != null)
            {
                if (currentSlot.CanPlaceItem())
                {
                    currentSlot.PlaceItem(item); // Помещаем предмет в слот
                    item.DisablePhysics();

                }
                else
                {
                    Debug.Log("Слот занят: " + currentSlot.gameObject.name);
                    item.EnablePhysics(); //Включаем физику, если слот занят
                }
            }
            else
            {
                Debug.Log("Нет слота для размещения предмета.");
                item.EnablePhysics(); //Включаем физику, если нет слота
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) //Если предмет над слотом
            {
                currentSlot = other.GetComponent<Slot>(); //Получаем ссылку на слот
                //Debug.Log("Предмет вошел в область слота: " + currentSlot.gameObject.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Slot") && currentSlot != null) //Если предмет покинул слот
            {
                //Debug.Log("Предмет покинул область слота: " + currentSlot.gameObject.name);
                currentSlot = null; //Сбрасываем ссылку на слот
            }
        }
    }
}