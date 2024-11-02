using UnityEngine;

public class WindowController : MonoBehaviour {
    public WindowElement[] windows; // ������ ����, ���������� � View, � Data

    private WindowModel[] models; // ������ ������� ��� ������� ����

    void Start() {
        InitializeAllWindows(); // ������������� ���� ���� ��� ������
    }

    private void InitializeAllWindows() {
        models = new WindowModel[windows.Length];

        for (int i = 0; i < windows.Length; i++) {
            var windowData = windows[i].data;
            var windowView = windows[i].view;

            if (windowData == null || windowView == null) {
                Debug.LogWarning($"���� {i} �� ���� ���������������� ��-�� ���������� ������ ��� �������������.");
                continue;
            }

            // ������� ������ � ��������� ���
            models[i] = new WindowModel(windowData);
            windowView.UpdateView(models[i]);
        }
    }
}

[System.Serializable]
public class WindowElement {
    public WindowView view;   
    public WindowDataSO data; 
}
