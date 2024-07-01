using System.Collections;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupTextPrefab;
    [SerializeField] private Canvas popupCanvas;

    public void ShowPopup(Vector3 position, string message)
    {
        // Tạo một instance của popupTextPrefab
        TextMeshProUGUI popupTextInstance = Instantiate(popupTextPrefab, popupCanvas.transform);

        // Đặt vị trí của popup
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(position);
        popupTextInstance.transform.position = screenPosition;

        // Thiết lập text của popup
        popupTextInstance.text = message;

        // Hủy popup sau một thời gian nhất định
        Destroy(popupTextInstance.gameObject, 2f); // 2 giây
    }
}
