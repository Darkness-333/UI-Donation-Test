using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class WindowView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI titleText; // Поле для заголовка
    [SerializeField] private TextMeshProUGUI descriptionText; // Поле для описания
    [SerializeField] private Transform itemsContainer; // Контейнер для предметов
    [SerializeField] private GameObject itemPrefab; // Префаб для отображения предметов
    [SerializeField] private TextMeshProUGUI priceText; // Поле для цены
    [SerializeField] private TextMeshProUGUI discountPriceText; // Поле для цены со скидкой
    [SerializeField] private Image bigIconImage; // Изображение большой иконки
    [SerializeField] private GameObject discountLabel; // Метка для отображения скидки
    [SerializeField] private TextMeshProUGUI discountAmountText; // Метка для отображения скидки

    private List<GameObject> itemObjects = new List<GameObject>();

    public void UpdateView(WindowModel model) {

        titleText.text = model.windowData.titleText;
        descriptionText.text = model.windowData.descriptionText;

        // Очистка предыдущих предметов
        foreach (GameObject item in itemObjects) {
            Destroy(item);
        }
        itemObjects.Clear();

        // Отображение предметов
        
        foreach (ItemData itemData in model.windowData.items) {
            GameObject itemObject = Instantiate(itemPrefab, itemsContainer);
            itemObject.transform.Find("Icon").GetComponent<Image>().sprite = itemData.itemIcon.iconSprite;
            itemObject.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = itemData.quantity.ToString();
            itemObjects.Add(itemObject);
        }

        // Обновление цены
        //priceText.text = model.windowData.price.ToString("F3");
        if (model.HasDiscount()) {
            discountLabel.SetActive(true);
            discountAmountText.text = "-" + model.windowData.discount.ToString() + "%";
            priceText.text = "<s>$" + model.windowData.price.ToString("F2");

        }
        else {
            discountLabel.SetActive(false);
            priceText.gameObject.SetActive(false);
        }
        discountPriceText.text = "$" + model.GetDiscountedPrice().ToString("F2");


        // Обновление большой иконки
        bigIconImage.sprite = model.windowData.bigIcon.iconSprite;
    }
}
