using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTT : MonoBehaviour
{
    public Button[] buttons = new Button[9];
    // Start is called before the first frame update
    void Start()
    {
       Board board = new Board();
       board.array[0,0] = 1;
       board.array[1,1] = 1;
       board.array[2,2] = 1;
       print(board.state(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click(int num_button) {

    }

}

public class Board {
    public int[,] array = new int[3,3];
    public int turn;
    public Board() {

    }
    public int state(int player) {
            if(array[0,0] == array[1,1] && array[1,1] == array[2,2] && array[0,0] != 0) {
                if(player == 1 && array[0,0] == 1) {
                    return 1;
                }
                else if(player == -1 && array[0,0] == 1) {
                    return 1;
                }
                else {
                    return -1;
                }
            }
            if(array[0,2] == 1 && array[1,1] == 1 && array[2,0] == 1) {
                return 1;
            }
    }
}