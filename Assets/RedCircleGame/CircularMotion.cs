using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField] private Transform centerObject; // ������, ������ �������� ����� ����������� ��������
    [SerializeField] private float radius = 5f; // ������ �����
    public float Speed = 1f; // �������� �������� �� �����

    private float angle; // ������� ����

    private void Update()
    {
        // ����������� ���� � �������� �������
        angle += Speed * Time.deltaTime;

        // ������������ ����������� ��������, ����������� ���� ���������� �� 0 �� 2*PI
        angle %= 2 * Mathf.PI;

        // ������������ ����� ������� ������� ������������ ������ ��������
        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;

        // ��������� ������� � �������
        transform.position = new Vector2(x, y);
    }
    
}
