using UnityEngine;
using UnityEngine.UI;
using Items;

namespace DragItem
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage;
        private bool occupied = false; //��������� ����� (����� ��)
        [SerializeField] private int index;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item") && !occupied) //���� ������� ��� ������
            {
                ChangeColor(0.1f);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item") && !occupied) //���� ������� ������� ����
            {
                ChangeColor(0);
            }
        }

        public void ChangeColor(float parametr)
        {
            //��������� ��������������
            Color color = slotImage.color;
            color.a = parametr;
            slotImage.color = color;
        }

        public bool CanPlaceItem()
        {
            return !occupied; //���������, �������� �� ����
        }

        public void PlaceItem(Item item)
        {
            if (!occupied) //���������, �������� �� ����
            {
                item.transform.position = transform.position; // ���������� ������� � ������� �����
                SetOccupied(true); //������������� ���� ��� �������
                ChangeColor(0);
                ItemController.instance.SlotOccupied(item.gameItem, index);
                Debug.Log("������� ������� � ����: " + gameObject.name);
            }
            else
            {
                Debug.Log("�� ������� ��������� �������, ���� �����: " + gameObject.name);
            }
        }

        public void DelItem()
        {
            ItemController.instance.SlotUnOccupied(index);
            SetOccupied(false); //������������� ���� ��� ���������
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