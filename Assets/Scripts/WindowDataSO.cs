using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WindowData", menuName = "ScriptableObjects/WindowData", order = 2)]
public class WindowDataSO : ScriptableObject {
    public string titleText; // Текст заголовка
    [TextArea] public string descriptionText; // Текст описания
    public List<ItemData> items; // Список предметов (название и количество)
    public float price; // Цена
    public float discount; // Скидка
    public IconDataSO bigIcon; // Большая иконка окна
}

[System.Serializable]
public class ItemData {
    public IconDataSO itemIcon; // Иконка предмета
    public int quantity; // Количество предметов
}
