using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        // [SerializeField] - говорит о том, что переменную можно редачить в юнити
        [SerializeField] private float force = 4; // сила выстрела
        [SerializeField] private float damage = 1; // урон от выстрела
        [SerializeField] private GameObject impactPrefab; // префаб эффекта попадания
        [SerializeField] private Transform shootPoint; // точка, отуда идет выстрел
    
        // Стандартный юнити метод Update - вызывается каждый кадр
        private void Update()
        {
            // Если нажимаем левую(0) кнопку мыши
            if (Input.GetMouseButtonDown(0))
            {
                // Выпускаем физический луч (Raycast)
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                {
                    // Выводим название объекта куда попали
                    print(hit.transform.gameObject.name);

                    // Создаём префаб эффекта попадания
                    Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                    // Пытаемся получить из объекта, куда попали DestructibleObject
                    var destructible = hit.transform.GetComponent<DestructibleObject>();
                    // если DestructibleObject есть то
                    if (destructible != null)
                    {
                        // Нанести урон
                        destructible.ReceiveDamage(damage);
                    }
                    
                    // Пытаемся получить из объекта, куда попали Rigidbody
                    var rigidbody = hit.transform.GetComponent<Rigidbody>();
                    // если Rigidbody есть то
                    if (rigidbody != null)
                    {
                        // Добавить отбрасывание
                        // вызываем AddForce, в который нужно передать
                        // 1) направление силы: shootPoint.forward (куда смотрит наше оружие)
                        // умноженное на force (силу)
                        // 2) ForceMode.Impulse - говорит о том, что мы учитываем вес объекта, к
                        // которому добавляем силу
                        rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                    }
                }
            }
        }

        // Юнити метод, который рисует графику для редактора
        // в нём можно обращаться к классу Gizmos
        // Так же вызвается на каждом кадре, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            // Выставляем красный цвет
            Gizmos.color = Color.red;
            
            // Рисуем луч, идущий из позиции нашего объекта shootPoint, направленный в shootPoint.forward
            // длина луча 9999 метров
            Gizmos.DrawRay(shootPoint.position, shootPoint.forward * 9999);
        }
    }
}