using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textScroll : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] [TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;
    [SerializeField] private Button nextButton;
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject claveDisplay;

    private int currentDisplayText = 0;
    private bool canGoNext = true;

    private void Start()
    {
        ActivateText();
    }

    public void ActivateText()
    {
        if (canGoNext)
        {
            if (currentDisplayText < itemInfo.Length)
            {
                canGoNext = false;
                nextButton.interactable = false;
                StartCoroutine(AnimateText());

                if (currentDisplayText == itemInfo.Length-1)
                {
                    claveDisplay.SetActive(true);
                }
            }
            else
            {
                SceneManager.LoadScene(nextScene); //"Level1"
            }
        }
       
        
    }
    
   IEnumerator AnimateText()
    {
        for (int i = 0; i< itemInfo[currentDisplayText].Length + 1; i++)
        {
            itemInfoText.text = itemInfo[currentDisplayText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }

        ++currentDisplayText;
        canGoNext = true;
        nextButton.interactable = true;
    }

    public void Skip()
    {
        SceneManager.LoadScene("Level1");
    }
}
