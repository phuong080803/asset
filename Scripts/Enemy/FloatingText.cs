using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float destroyTime = 1f;
    private TextMeshProUGUI textComponent;
    private Transform targetTransform;

    void Start()
    {
        // Tìm TextMeshPro component bên trong prefab
        textComponent = GetComponentInChildren<TextMeshProUGUI>();

        // Đặt text biến mất sau một khoảng thời gian
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // Di chuyển text lên trên
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        // Cập nhật vị trí của text theo vị trí của đối tượng mục tiêu
        if (targetTransform != null)
        {
            transform.position = targetTransform.position;
        }
    }

    public void SetText(string text, Transform target)
    {
        if (textComponent != null)
        {
            textComponent.text = text;
        }
        targetTransform = target;
    }
}
