using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI countdownText;


    private void Start() {
        KitchenGameManager.Instanse.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instanse.IsCountDownTOStartActive()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Update() {
        countdownText.text = Mathf.Ceil(KitchenGameManager.Instanse.GetCountdownToStartTimer()).ToString();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
