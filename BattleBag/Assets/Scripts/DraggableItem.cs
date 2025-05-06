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
                //Debug.Log("�������� " + currentSlot.GetComponent<Slot>().name);
                currentSlot.GetComponent<Slot>().DelItem();
            }
            //��������� ������
            if (item != null)
            {
                item.DisablePhysics();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            //����������� �������� �� ��������
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
            rectTransform.localPosition = localPoint;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //���������, ����� �� �������� ������� � ����
            if (currentSlot != null)
            {
                if (currentSlot.CanPlaceItem())
                {
                    currentSlot.PlaceItem(item); // �������� ������� � ����
                    item.DisablePhysics();

                }
                else
                {
                    Debug.Log("���� �����: " + currentSlot.gameObject.name);
                    item.EnablePhysics(); //�������� ������, ���� ���� �����
                }
            }
            else
            {
                Debug.Log("��� ����� ��� ���������� ��������.");
                item.EnablePhysics(); //�������� ������, ���� ��� �����
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Slot")) //���� ������� ��� ������
            {
                currentSlot = other.GetComponent<Slot>(); //�������� ������ �� ����
                //Debug.Log("������� ����� � ������� �����: " + currentSlot.gameObject.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Slot") && currentSlot != null) //���� ������� ������� ����
            {
                //Debug.Log("������� ������� ������� �����: " + currentSlot.gameObject.name);
                currentSlot = null; //���������� ������ �� ����
            }
        }
    }
}