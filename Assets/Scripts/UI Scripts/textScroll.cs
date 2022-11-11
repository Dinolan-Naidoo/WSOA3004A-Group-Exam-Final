using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textScroll : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] [TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;

    private int currentDisplayText = 0;

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }
    
   IEnumerator AnimateText()
    {
        for (int i = 0; i< itemInfo[currentDisplayText].Length + 1; i++)
        {
            itemInfoText.text = itemInfo[currentDisplayText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
