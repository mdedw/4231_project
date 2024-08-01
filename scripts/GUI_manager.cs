using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUI_manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_txt;
    [SerializeField] private TextMeshProUGUI finalScore_txt;
    [SerializeField] private Image healthbar_img;
    [SerializeField] private Image treebar_img;
    [SerializeField] private TextMeshProUGUI seed_txt;
    [SerializeField] private TextMeshProUGUI seed2_txt;
    [SerializeField] private TextMeshProUGUI seed3_txt;

    private int score;
    private int seeds;

    public static GUI_manager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy (gameObject);
        }
    }


    private void Start() {
        score = 0;
        seeds = 0;
        SetScoreDisplay();
        SetSeedDisplay();
    }


    private void SetScoreDisplay() {
        score_txt.text = score.ToString();
    }


    private void FinalScoreDisplay() {
        finalScore_txt.text = score.ToString();
    }


    public void SetSeedDisplay() {
        seed_txt.text = (GameManager.instance.seedAmount / 2).ToString();
        seed2_txt.text = (GameManager.instance.seed2Amount / 2).ToString();
        seed3_txt.text = (GameManager.instance.seed3Amount / 2).ToString();
    }

    public void ChangeScore(int value) {
        score += value;
        SetScoreDisplay();
        FinalScoreDisplay();
    }

    public void ChangeSeeds(int value) {
        seeds += value;
        SetSeedDisplay();
    }


    public void updateHealthBar (float health_percentage) {
        healthbar_img.fillAmount = health_percentage;
    }


    public void updateTreeBar (float health_percentage) {
        treebar_img.fillAmount = health_percentage;
    }
}
