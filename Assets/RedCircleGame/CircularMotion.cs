using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField] private Transform centerObject; // Объект, вокруг которого будет происходить вращение
    [SerializeField] private float radius = 5f; // Радиус круга
    public float Speed = 1f; // Скорость движения по кругу

    private float angle; // Текущий угол

    private void Update()
    {
        // Увеличиваем угол с течением времени
        angle += Speed * Time.deltaTime;

        // Обеспечиваем бесконечное вращение, ограничивая угол значениями от 0 до 2*PI
        angle %= 2 * Mathf.PI;

        // Рассчитываем новую позицию объекта относительно центра вращения
        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;

        // Применяем позицию к объекту
        transform.position = new Vector2(x, y);
    }
    
}
