using UnityEngine;
using UnityEngine.UI;
using Items;

namespace DragItem
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage;
        private bool occupied = false; //Состояние слота (занят ли)
        private bool upgrade = false; //Состояние слота можно ли улучшить
        [SerializeField] private int index;

        private Color freeSlot;
        private Color choiceSlot;
        private Color upSlot;

        private bool generate = false;

        private void Start()
        {
            freeSlot = new Color(1,1,1,0);
            choiceSlot = new Color(1,1,1,0.2f);
            upSlot = new Color(0,1,0,0.2f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item") && !occupied) //Если предмет над слотом и слот не занят
            {
                ChangeColor(choiceSlot);
            }
            else if (!generate && other.CompareTag("Item") && occupied && ItemController.instance.GetItemName(index) == other.GetComponent<DraggableItem>().GetItemName())
            {
                //если можно улучшить, то подсвечиваем слот зеленым
                ChangeColor(upSlot);
                upgrade = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item")) //Если предмет покинул слот
            {
                ChangeColor(freeSlot);
            }
        }

        public void ChangeColor(Color col)
        {
            //Назначаем непрозрачность
            slotImage.color = col;
        }

        public bool CanPlaceItem()
        {
            return !occupied; //Проверяем, свободен ли слот
        }

        public bool CanUpgradeItem()
        {
            return upgrade; //можно ли улучшить предмет
        }

        public void UpgradeItem()
        {
            upgrade = false;
        }

        //помещаем предмет над выбранным слотом
        public void PlaceItem(Item item)
        {
            if (!occupied) //Проверяем, свободен ли слот
            {
                item.transform.position = transform.position; // Перемещаем предмет в позицию слота
                LoadOccupedSlotsInfo();
                ItemController.instance.SlotOccupied(item.GameItem(), item, index);
            }
            else
            {
                Debug.Log("Не удалось поместить предмет, слот занят: " + gameObject.name);
            }
        }

        public void LoadOccupedSlotsInfo()
        {
            SetOccupied(true); //Устанавливаем слот как занятый
            ChangeColor(freeSlot);
        }

        public void DelItem()
        {
            ItemController.instance.SlotUnOccupied(index);
            SetOccupied(false); //Устанавливаем слот как свободный
        }

        public void SetOccupied(bool value)
        {
            occupied = value;
        }

        public int GetIndex()
        {
            return index;
        }

        public void ChangeGenerate(bool g)
        {
            generate = g;
        }
    }
}