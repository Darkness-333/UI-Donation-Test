public class WindowModel {
    public WindowDataSO windowData;

    public WindowModel(WindowDataSO data) {
        windowData = data;
    }

    public float GetDiscountedPrice() {
        return windowData.discount > 0 ? windowData.price * (1 - windowData.discount / 100) : windowData.price;
    }

    public bool HasDiscount() {
        return windowData.discount > 0;
    }
}
