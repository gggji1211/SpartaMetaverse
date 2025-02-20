using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camere : MonoBehaviour
{
    public Transform target; // ���� ��� (��: �÷��̾��� Transform�� �Ҵ��ؾ� ��)
    private float offsetX;   // ī�޶�� ��� ���� X�� �Ÿ� ������

    void Start()
    {
        if (target == null) return; // ����� �������� �ʾҴٸ� �� �̻� �������� ����

        // ī�޶�� ��� ���� �ʱ� X ��ġ ���̸� �����Ͽ�, ����� ��ġ�� �����ϵ��� ��
        offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null) return; // ����� ������ �������� ����

        // ���� ī�޶��� ��ġ�� ������
        Vector3 pos = transform.position;

        // ����� X ��ġ�� �������� �������� �����ϸ鼭 ���󰡵��� ����
        pos.x = target.position.x + offsetX;

        // ������Ʈ�� ��ġ�� ī�޶� ����
        transform.position = pos;
    }
}
