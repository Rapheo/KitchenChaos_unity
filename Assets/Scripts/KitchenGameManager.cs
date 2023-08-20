using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour {

    public static KitchenGameManager Instanse {get; private set;}

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;


    private enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        Gameover,
    }

    private State state;
    private float waitingtoStartTimer = 1f;
    private float countdowntoStartTimer = 3f;
    private float gamePlayingtTimer;
    private float gamePlayingtTimerMax = 15f;
    private bool isGamePaused = false;

    private void Awake() {
        Instanse = this;
        state = State.WaitingToStart;
    }

    private void Start() {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e) {
        TogglePauseGame();
    }

    private void Update() {
        switch (state) {
            case State.WaitingToStart:
                waitingtoStartTimer -= Time.deltaTime;
                if (waitingtoStartTimer < 0f) {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdowntoStartTimer -= Time.deltaTime;
                if (countdowntoStartTimer < 0f) {
                    state = State.GamePlaying;
                    gamePlayingtTimer = gamePlayingtTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingtTimer -= Time.deltaTime;
                if (gamePlayingtTimer < 0f) {
                    state = State.Gameover;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.Gameover:
                break;
        }

        Debug.Log(state);
    }

    public bool IsGamePlaying(){
        return state == State.GamePlaying;
    }

    public bool IsCountDownTOStartActive() {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer() {
        return countdowntoStartTimer;
    }

    public bool IsGameover() {
        return state == State.Gameover;
    }

    public float GetGamePlayingTimerNormalized() { 
        return 1 - (gamePlayingtTimer/gamePlayingtTimerMax);
    }

    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;

        if (isGamePaused) {
            Time.timeScale = 0f;

            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);

        }
    }

}
