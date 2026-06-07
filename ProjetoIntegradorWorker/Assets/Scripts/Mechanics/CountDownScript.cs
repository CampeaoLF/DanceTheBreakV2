using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float musicTime;
    [SerializeField] GameObject derrotaScreen;
    [SerializeField] GameObject vitoriaScreen;
    public AudioController audioController;
    [SerializeField] GameManager gameManager;
    [SerializeField] private TextMeshProUGUI pointsText;

    void Update()
    {
        if (gameManager == null)
            return;

        if (!gameManager.Ready)
            return;


        musicTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(musicTime / 60);
        int seconds = Mathf.FloorToInt(musicTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (musicTime <= 0 && gameManager.score < 200)
        {
            pointsText.text = gameManager.score.ToString();
            derrotaScreen.SetActive(true);
            audioController.audioSource.enabled = false; 
            gameManager.progressBar.gameObject.SetActive(false);
        }

        if (gameManager.score >= 200)
        {
            pointsText.text = gameManager.score.ToString();
            vitoriaScreen.SetActive(true);
            audioController.audioSource.enabled = false;
            gameManager.progressBar.gameObject.SetActive(false);
        }

    }
}
