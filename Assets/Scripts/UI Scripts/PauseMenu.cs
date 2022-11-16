using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    private PlayerController playerController;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private string currentLayer;
    [SerializeField] private TextMeshProUGUI currentLayerText;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite pausedSprite;
    [SerializeField] private Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        playerController = FindObjectOfType<PlayerController>();
        pauseButton.image.sprite = pauseSprite;
    }

   /* // Update is called once per frame
    void Update()
    {
        
    }*/

    public void Pause()
    {
        if (paused)
        {
            pausePanel.SetActive(false) ;
            paused = false;
            playerController.PausePlayer(false);
            pauseButton.image.sprite = pauseSprite;
        }
        else
        {
            //Debug.Log("clicked");
            pausePanel.SetActive(true);
            paused = true;
            playerController.PausePlayer(true);
            currentLayerText.text = "Current Layer: " + currentLayer;
            pauseButton.image.sprite = pausedSprite;
        }
    }
}
