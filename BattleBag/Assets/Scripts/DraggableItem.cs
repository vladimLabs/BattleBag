using UnityEngine;
using UnityEngine.EventSystems;
using Items;

namespace DragItem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Item item;
        private Slot currentSlot;

        //private bool drag = false;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            item = GetComponent<Item>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //drag = true;
            if (currentSlot != null)
            {
                currentSlot.GetComponent<Slot>().DelItem();
            }
            //Отключаем физику, чтобы он не падал, когда несем
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
                if (currentSlot.CanPlaceItem()) //вызываем у слота, над которым держим предмет, метод, который говорит свободен ли слот
                {
                    currentSlot.PlaceItem(item); // Помещаем предмет в слот
                    item.DisablePhysics();
                }
                else if (currentSlot.CanUpgradeItem() && IsCanMergeItems(currentSlot.GetIndex(), GetComponent<Item>().GameItem().Level))
                {
                    ItemController.instance.UpgradeItem(currentSlot.GetIndex());
                    Destroy(gameObject);    
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
            //drag = false;
        }

        //Проверка можно ли поднять уровень объекта
        private bool IsCanMergeItems(int index, float level)
        {
            return GameBag._gameSlotsItem[index].Level == level && level < 3;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) //Если предмет над слотом
            {
                currentSlot = other.GetComponent<Slot>(); //Получаем ссылку на слот
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Slot") && currentSlot != null) //Если предмет покинул слот
            {
                currentSlot = null; //Сбрасываем ссылку на слот
            }
        }

        public string GetItemName()
        {
            return item.KeyName;
        }

    }
}