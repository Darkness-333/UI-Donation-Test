using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class WindowView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI titleText; // ���� ��� ���������
    [SerializeField] private TextMeshProUGUI descriptionText; // ���� ��� ��������
    [SerializeField] private Transform itemsContainer; // ��������� ��� ���������
    [SerializeField] private GameObject itemPrefab; // ������ ��� ����������� ���������
    [SerializeField] private TextMeshProUGUI priceText; // ���� ��� ����
    [SerializeField] private TextMeshProUGUI discountPriceText; // ���� ��� ���� �� �������
    [SerializeField] private Image bigIconImage; // ����������� ������� ������
    [SerializeField] private GameObject discountLabel; // ����� ��� ����������� ������
    [SerializeField] private TextMeshProUGUI discountAmountText; // ����� ��� ����������� ������

    private List<GameObject> itemObjects = new List<GameObject>();

    public void UpdateView(WindowModel model) {

        titleText.text = model.windowData.titleText;
        descriptionText.text = model.windowData.descriptionText;

        // ������� ���������� ���������
        foreach (GameObject item in itemObjects) {
            Destroy(item);
        }
        itemObjects.Clear();

        // ����������� ���������
        
        foreach (ItemData itemData in model.windowData.items) {
            GameObject itemObject = Instantiate(itemPrefab, itemsContainer);
            itemObject.transform.Find("Icon").GetComponent<Image>().sprite = itemData.itemIcon.iconSprite;
            itemObject.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = itemData.quantity.ToString();
            itemObjects.Add(itemObject);
        }

        // ���������� ����
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


        // ���������� ������� ������
        bigIconImage.sprite = model.windowData.bigIcon.iconSprite;
    }
}
