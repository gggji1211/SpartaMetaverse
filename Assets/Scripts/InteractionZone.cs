using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �÷��̾ �������� ���� ����
        {
            Debug.Log("Ư�� ������ ���Խ��ϴ�!");
            // ���⿡ ���ϴ� �̺�Ʈ �߰� (��: ��ȭ ����, �̴ϰ��� ���� ��)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ư�� �������� �������ϴ�!");
        }
    }
}
