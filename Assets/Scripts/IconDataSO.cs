using UnityEngine;

[CreateAssetMenu(fileName = "IconData", menuName = "ScriptableObjects/IconData", order = 1)]
public class IconDataSO : ScriptableObject {
    public string iconName; // Название иконки
    public Sprite iconSprite; // Изображение иконки
}
