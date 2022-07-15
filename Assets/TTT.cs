using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTT : MonoBehaviour {
    public Button[] buttons = new Button[9];
    public Board board = new Board();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click(int num_button) {
        Button b = buttons[num_button];
        TMP_Text buttontext = (TMP_Text)b.gameObject.GetComponentsInChildren(typeof(TMP_Text), false)[0];
        if(board.turn%2 == 0) {
            if(buttontext.text != "O" && buttontext.text != "X") {
                buttontext.text = "X";
                board.array[num_button/3, num_button%3] = 1;
            }
            else {
                board.turn = board.turn-1;
            }
        }
        else {
            if(buttontext.text != "X" && buttontext.text != "O") {
                buttontext.text = "O";
                board.array[num_button/3, num_button%3] = -1;
            }
            else {
                board.turn = board.turn-1;
            }

        }
        print(board.state(1));
        print(board.avail());
    }
}

public class Board {
    public int[,] array = new int[3,3];
    public int turn = 0;
    public Board() {

    }
    public Board copy() {
        Board cboard = new Board();
        for(int i = 0; i<3; i++) {
            for(int j = 0; j<3; j++) {
                cboard.array[j,i] = array[j,i];
            }
        }
        int cturn = turn;
        cboard.turn = cturn;
        return cboard;
    }
    public List <int[]> avail() {
        List <int[]> location = new List<int[]>();
        for(int i = 0; i<3; i++) {
            for(int j = 0; j<3; j++) {
                if(array[j,i] == 0) {
                    Debug.Log(j+" "+i);
                    location.Add(new int[] {j,i});
                }
            }
        }
        return location;
    }
    public int minimax(int player){
        if(state(player) == 1) {
            return 1;
        }
        if(state(player) == -1) {
            return -1;
        }
        if(state(player) == 0) {
            return 0;
        }
        List <int[]> av = avail();
        Board c = copy();
        int p = 0;
        for(int h = 0; h<av.Count; h++) {
            if(c.turn%2 == 0){
                p = 1;
            }
            else{
                p = -1;
            }
            c.array[av[h][0], av[h][1]] = p;
            Board new_move = c; 
            c.turn++;
        }

    }
    public int state(int player) {
            if(array[0,0] == array[1,1] && array[1,1] == array[2,2] && array[0,0] != 0) {
                if(player == array[0,0]) {
                    return 1;
                }
                else {
                    return -1;
                }
            }
            if(array[0,2] == array[1,1] && array[1,1] == array[2,0] && array[0,2] != 0) {
                if(player == array[0,2]) {
                    return 1;
                }
                else {
                    return -1;
                }
            }
            for(int i = 0; i<3; i++) {
                if(array[0,i] == array[1,i] && array[1,i] == array[2,i] && array[0,i] != 0) {
                    if(player == array[0,i]) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                } 
            }
            for(int j = 0; j<3; j++) {
                if(array[j,0] == array[j,1] && array[j,1] == array[j,2] && array[j,0] != 0) {
                    if(player == array[j,0]) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                }
            }
            Debug.Log(turn);
            if(avail().Count ==0){
                return 0;
            }
            else{
                return 2;
            }
        }
}
