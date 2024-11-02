using UnityEngine;

public class WindowController : MonoBehaviour {
    public WindowElement[] windows; // ћассив окон, содержащий и View, и Data

    private WindowModel[] models; // ћассив моделей дл€ каждого окна

    void Start() {
        InitializeAllWindows(); // »нициализаци€ всех окон при старте
    }

    private void InitializeAllWindows() {
        models = new WindowModel[windows.Length];

        for (int i = 0; i < windows.Length; i++) {
            var windowData = windows[i].data;
            var windowView = windows[i].view;

            if (windowData == null || windowView == null) {
                Debug.LogWarning($"ќкно {i} не было инициализировано из-за отсутстви€ данных или представлени€.");
                continue;
            }

            // —оздаем модель и обновл€ем вид
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
