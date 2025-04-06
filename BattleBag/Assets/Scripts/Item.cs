using UnityEngine;

namespace DragItem
{
    public class Item : MonoBehaviour
    {
        public string itemName;
        public int itemID;

        public void DisablePhysics()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // ������������� � �������������� �����
            }
        }

        public void EnablePhysics()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // ������������� � �����, ����������� �� ������
            }
        }
    }
}