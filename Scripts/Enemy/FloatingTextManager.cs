using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    public void ShowFloatingText(string text, Transform target)
    {
        Vector3 position = target.position;
        GameObject floatingText = Instantiate(floatingTextPrefab, position, Quaternion.identity);
        FloatingText textComponent = floatingText.GetComponent<FloatingText>();
        textComponent.SetText(text, target);
        Debug.Log("hello");
    }
}
