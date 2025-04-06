using UnityEngine;
using UnityEngine.EventSystems;

namespace DragItem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private BagFight bagFight; // ������ �� ����� BagFight (���� �� ������������)
        private RectTransform rectTransform; // RectTransform �������
        private Item item; // ������ �� ��������� Item
        private Slot currentSlot; // ������ �� ������� ����, ���� ������� ��� ���

        private void Start()
        {
            bagFight = FindObjectOfType<BagFight>();
            rectTransform = GetComponent<RectTransform>();
            item = GetComponent<Item>(); // �������� ������ �� ��������� Item
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // ��������� ������
            if (item != null)
            {
                item.DisablePhysics();
                Debug.Log("������ ��������� ��� ��������: " + item.itemName);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // ����������� �������� �� ��������
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
            rectTransform.localPosition = localPoint; // ������������� ��������� �������
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // ���������, ����� �� �������� ������� � ����
            if (currentSlot != null)
            {
                Debug.Log("������� ��� ������: " + currentSlot.gameObject.name);
                if (currentSlot.CanPlaceItem(item))
                {
                    currentSlot.PlaceItem(item); // �������� ������� � ����
                    Debug.Log("������� ������� � ����: " + currentSlot.gameObject.name);
                    // �� �������� ������ ��� ��������
                }
                else
                {
                    Debug.Log("���� �����: " + currentSlot.gameObject.name);
                    item.EnablePhysics(); // �������� ������, ���� ���� �����
                }
            }
            else
            {
                Debug.Log("��� ����� ��� ���������� ��������.");
                item.EnablePhysics(); // �������� ������, ���� ��� �����
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) // ���� ������� ��� ������
            {
                currentSlot = other.GetComponent<Slot>(); // �������� ������ �� ����
                Debug.Log("������� ����� � ������� �����: " + currentSlot.gameObject.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) // ���� ������� ������� ����
            {
                Debug.Log("������� ������� ������� �����: " + currentSlot.gameObject.name);
                currentSlot = null; // ���������� ������ �� ����
            }
        }
    }
}