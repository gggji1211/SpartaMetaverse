using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionZone : MonoBehaviour
{
    public string PlappyPlane;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) // �÷��̾ �������� ���� ����
        {
            SceneManager.LoadScene(PlappyPlane);

        }
    }

}
