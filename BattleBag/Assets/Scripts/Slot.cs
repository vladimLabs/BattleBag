using UnityEngine;
using UnityEngine.UI;

namespace DragItem
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage; // ����������� �����
        private Color originalColor;
        private bool occupied = false; // ��������� �����

        private void Awake()
        {
            originalColor = slotImage.color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item")) // ���� ������� ��� ������
            {
                // ����������� �������������� �� 10%
                Color color = slotImage.color;
                color.a = 0.1f; // 10% ��������������
                slotImage.color = color;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item")) // ���� ������� ������� ����
            {
                // ������� ��������������
                Color color = slotImage.color;
                color.a = 0f; // 0% ��������������
                slotImage.color = color;
            }
        }

        public bool CanPlaceItem(Item item)
        {
            return !occupied; // ���������, �������� �� ����
        }

        public void PlaceItem(Item item)
        {
            if (!occupied) // ���������, �������� �� ����
            {
                item.transform.position = transform.position; // ���������� ������� � ������� �����
                item.DisablePhysics(); // ��������� ������ � ��������
                SetOccupied(true); // ������������� ���� ��� �������
                Debug.Log("������� ������� � ����: " + gameObject.name);
            }
            else
            {
                Debug.Log("�� ������� ��������� �������, ���� �����: " + gameObject.name);
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