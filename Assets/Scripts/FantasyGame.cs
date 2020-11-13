﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FantasyGame : MonoBehaviour {
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;



    State state;

    // Start is called before the first frame update
    void Start() {
        state = startingState;
        textComponent.text = state.GetStateStory();

    }

    // Update is called once per frame
    void Update() {
        ManageState();
        QuitGame();
    }

    private void QuitGame() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }

    private void ManageState() {
        var nextStates = state.GetNextStates();
        for (int index = 0; index < nextStates.Length; index++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index)) {
                state = nextStates[index];
            }
        }

        /*       if (Input.GetKeyDown(KeyCode.Alpha1)) {
                   state = nextStates[0];
               } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                   state = nextStates[1];
               } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                   state = nextStates[2];
               }
       */

        textComponent.text = state.GetStateStory();
    }

}
