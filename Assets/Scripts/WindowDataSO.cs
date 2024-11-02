using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WindowData", menuName = "ScriptableObjects/WindowData", order = 2)]
public class WindowDataSO : ScriptableObject {
    public string titleText; // ����� ���������
    [TextArea] public string descriptionText; // ����� ��������
    public List<ItemData> items; // ������ ��������� (�������� � ����������)
    public float price; // ����
    public float discount; // ������
    public IconDataSO bigIcon; // ������� ������ ����
}

[System.Serializable]
public class ItemData {
    public IconDataSO itemIcon; // ������ ��������
    public int quantity; // ���������� ���������
}
