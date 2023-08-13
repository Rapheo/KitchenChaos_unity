using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;


    private void Start() {
        KitchenGameManager.Instanse.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instanse.IsGameover()) {
            Show();

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfullRecipesAmount().ToString();
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
