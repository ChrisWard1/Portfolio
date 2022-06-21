/*  ### Final Project Firm Deadline: 5/3/2021 11:59 PM, late submission will NOT be accepted

Grading rubric:
  - This final project has 20 points in total.
  - Grader will run your program at first, if the program could not run successfully, you will lose 5 points at first.
  - Grader will try to debug your program and fix simple errors like (missing symbol or spelling errors); 
  - Three test cases will be applied on your program when grading: including computer win, human win and draw. 
  - Each test case is worth 5 points. Failed test case will lose 5 points. 
  - If you passed all three test cases, you get full 20 points.
  - If you failed all three test cases, you get 0 point.


Before submission please check:
  - Enter all members' Names and WTEmails in the following code cell
  - All your teammates have joined the same group on the WTClass
  - *Each group just need one submission submitted by group leader
  - The program gives expected output without errors
  - If you work in a group, EACH member should submit a Final Project Peer Evaluation Form to WTClass.
  - Submit the replit to the WTClass. If you do it on your computer, just submit this TicTacToe.cs file.
  


 Please enter information of group members below (e.g.: Full Name: WTemail):
    - Member1: Timothy Henry tghenry1@buffs.wtamu.edu
    - Member2: Tyler Bowdry tjbowdry1@buffs.wtamu.edu
    - Member3: Javier Trevino jtrevino1@buffs.wtamu.edu
    - Member4: Christopher Ward cjward1@buffs.wtamu.edu
    - Member5: Niraj Bhakta nsbhakta1@buffs.wtamu.edu


We have 16 questions, and each question has corresponding Piazza post for Q&A. Please share your questions on the Piazza
Here is the Piazza link: https://piazza.com/class/kgzn6ttpyiwoj
*/

using System;
public class TicTacToe {

    //initialize an 3x3 empty 2d-array as game board
    private char[ , ] board = new char[3,3];

    // declare a variable to indicate current player's marker.
    // it should be initialized when creating object with the class constructor in MainClass.
    // when currentPlayerMark ='x', it represents human player, 
    // when currentPlayerMark ='o', it represents computer player.
    private char currentPlayerMark; 
      
    // initialize an 1d-array used to store the row index and col index of a board cell for moving
    int[] move = new int[2];

    // Set the game board with all empty values (blank space ' ').
    private void initializeBoard() {
        // set all game board values to blank space ' '
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                board[i,j] = ' ';
            }
        }
    }

	/*
      Do NOT change ABOVE code. Your answers goes from here:
  */



    /* 
        Question: Class Constructor TicTacToe
        When creating an object of this class, call initializeBoard() method to initialize the game board with blank space,
        and assign currentPlayerMark value to class variable this.currentPlayerMark 
    */

    public TicTacToe(char currentPlayerMark) {
      initializeBoard();
      this.currentPlayerMark = currentPlayerMark;

    }
	

    /*
        Question: printBoard
        Print values of 2d array: board in a 3x3 game board, the game board could contain mark 'x' or 'o', or just an empty board (if 2d array board is empty), for example:
                -------------           -------------
                |   |   | o |           |   |   |   |
                -------------           -------------
                |   | x |   |    OR     |   |   |   |
                -------------           -------------   
                |   |   |   |           |   |   |   | 
                -------------           -------------
    */
    public void printBoard() {
      Console.WriteLine("-------------");
      for(int i = 0; i < 3; i++)
      {
        Console.Write("| ");
        for(int j = 0; j < 3; j++)
        {
          Console.Write(board[i,j] + " | ");
        }
        Console.WriteLine();
        Console.WriteLine("-------------");
      }


    }
	


    /*
        Question: isBoardFull
        Check if the game board is full 
            - if the borad is full (no value equal to blankspace), return true
            - else return false
        Hint: iterate values of 2d array: borad; if one of vale equals ' ' (blankspace), return false; else return true
    */ 
    public bool isBoardFull() {
      for(int i = 0; i < 3; i++){
        for (int j = 0; j < 3; j++){
          if(board[i,j] == ' '){
            return false;
          }
        }
      }

      return true;
    }
	

	  /* 
        Question: checkThreeValues
        Check if all three cells have the same characters (and not empty). Return true if they are same; otherwise return false.
        This method will be used by following checking-for-win methods

        Hint: check if c1, c2, c3 they are equal and they are not blankspace ' '
    */
      private bool checkThreeValues(char c1, char c2, char c3){
      if(c1 == c2 && c2==c3 && c1 != ' '){
        return true;
      }else{
        return false;
      }
      


    }


	
    /* 
        Question: checkRowForWin
        Iterate all rows in the board to check if there is a win. If there is a win on row (three cells in the same row have the same mark ('x' or 'o')), return true; otherwise, return false. E.g.:
                -------------  
                | x | x | x |  
                -------------  
                |   |   |   |  
                -------------  
                |   |   |   |  
                -------------  
    */
    private bool checkRowForWin() {
       // put your answer below
      for (int row = 0; row < 3; row++) {     
       if(checkThreeValues(board[row,0], board[row,1], board[row,2]) == true){ 
                return true;
                }
         
      }   
      return false;
    }
	
    /* 
        Question: checkColForWin
        Iterate all columns in the board to check if there is a win. If there is a win on column (three cells in the same column have the same mark), return true; otherwise, return false. E.g.:

                -------------  
                | x |   |   |  
                -------------  
                | x |   |   |  
                -------------  
                | x |   |   |  
                -------------  
    */
    private bool checkColForWin() {
     for (int col = 0; col < 3; col++) {     
       if(checkThreeValues(board[0,col], board[1,col], board[2,col]) == true){ 
                return true;
                }
      }   return false;
    }
    
          
	
	/* 
        Question: checkDiagonalForWin
        Check the two diagonals to see if either is a win. Return true if either wins, else return false. E.g.:

                -------------           -------------
                |   |   | x |           | x |   |   |
                -------------           -------------
                |   | x |   |    OR     |   | x |   |
                -------------           -------------   
                | x |   |   |           |   |   | x | 
                -------------           -------------
    */
   private bool checkDiagonalForWin() {        
      // put your answer below
      if (checkThreeValues(board[0,0], board[1,1], board[2,2])){
        return true; 
      } else if (checkThreeValues(board[0,2], board[1,1], board[2,0])){
        return true;
      }else{
        return false;
      }
    }
  
    /* 
        Question: checkForWin
        Check a win condition in game board; Returns true if there is a win on rows, columns or diagonals, false otherwise.
        Hint: This method calls above three win check methods to check the entire board. If one of method return true, this checkForWin method returns true. All three methods are false, this method returns false
    */
    public bool checkForWin()
    {
      // put your answer below
      return(checkColForWin() || checkRowForWin() ||checkDiagonalForWin());

      //Human Player Wins! Print Statement
      //Computer Player Wins! Print Statment
    }


	
	/* 
        Question: changePlayer
        Change player marks back and forth. This method is used to switch players. 
        After a human player placed a mark, it changes to computer player.
        After a computer player placed a mark, it changes to human player.
    */
    public void changePlayer() {
      // put your answer below

      if (this.currentPlayerMark == 'x') {
        this.currentPlayerMark = 'o';
      }
      else{
        this.currentPlayerMark = 'x';
      }


    }
	
    /* 
        Question: movePlayer
        Ask the human player to input the row index and col index from keyboard for placing marker on the game board.
        Check if the value of index is valid ( the index should be within [0,2])
        If valid, save the row index and column into the 1d array: move and return true;
        else, ask human user to input valid index again.
        Hint: use Console.ReadLine() and Convert.ToInt32() to get int value as from keyboard as index
    */    
   public bool movePlayer() {
  Console.Write("Input Row Num (0-2): ");
  int rowIndexInput = Convert.ToInt32(Console.ReadLine()); 
  Console.Write("Input Col Num (0-2): ");
  int colIndexInput = Convert.ToInt32(Console.ReadLine());
	// **add code to check if index is valid
  while(rowIndexInput > 2)
  {
    Console.Write("Please insert a number for Row between 0 and 2: ");
    rowIndexInput = Convert.ToInt32(Console.ReadLine());
  }
  while(colIndexInput > 2)
  {
    Console.Write("Please insert a number for Column between 0 and 2: ");
    colIndexInput = Convert.ToInt32(Console.ReadLine());
  }
  for(int i = 0; i < 3; i++){
    for (int j = 0; j < 3; j++){
      if (board[rowIndexInput,colIndexInput] != ' '){
        Console.WriteLine("That spot has been taken.");
        Console.Write("Input Row Num (0-2): ");
        rowIndexInput = Convert.ToInt32(Console.ReadLine()); 
        Console.Write("Input Col Num (0-2): ");
        colIndexInput = Convert.ToInt32(Console.ReadLine());
      }
    }
  }
  move[0] = Convert.ToInt32(rowIndexInput);
  move[1] = Convert.ToInt32(colIndexInput);
  Console.WriteLine($"Human (x) moves: {move[0]},{move[1]}");
  return true;
    }
    /* 
        Question: placeMark
        Places a mark for current player at the cell specified by row index and col index saved in 1d array: move.
        Return true after placing a marker.
        Hint: placing marker means: board[row, col] = currentPlayerMark;
    */
     public bool placeMark(int[] move) {
        int row= move[0];
        int col= move[1];
        if(board[row,col] == ' '){
          board[row,col] = currentPlayerMark;
        } else {
          moveRandom();
        }
      return true;

    }
    
    
    
    
    /* 
        Question: moveToBlock
        When computer player make a move, it should check if human player will win in next move.
        if human player will win after placing a marker on a cell in next step
        computer player should return the row/col index of that cell within a 1d-array.
        if computer player can not find cell to stop human player, return null

        E.g: In the follwoing situation, the computer player should place a marker on cell (1,1) to blcok human player's win.
                                    -------------
                                    | x |   |   |
                                    -------------
                                    |   |   |   |
                                    -------------   
                                    | o |   | x | 
                                    ------------- 

        Hint: to check human player's win in next move, you can iterate each empty cell and assume that human player will place the mark on that empty cell. Then use checkForWin to see if human player places a marker on that empty cell will get a win. E.g:

        In the follwoing situation, the computer player iterate empty cell one by one, and put human player's makrer on the empty cell (here marker E indicate the human player's next move). Then run checkForWin and see if human player will win. In this example, we test empty cells from E1 to E4. human player will win until we place a marker on E4. So return the E4's index
                                    -------------
                                    | x |E1 |E2 |
                                    -------------
                                    |E3 |E4 |   |
                                    -------------
                                    | o |   | x |
                                    ------------- 

    */
      private int checkForBlock(char c1, char c2, char c3){
      if(c1 == c2 && c3 == ' ' && c1 != ' ' && c1 != 'o'){
        return 3;
      }else if(c1 == c3 && c2 == ' ' && c1 != ' ' && c1 != 'o'){
        return 2;
      }else if(c2 == c3 && c1 == ' ' && c2 != ' ' && c2 != 'o'){
        return 1;
      }else {
        return 4;
      }
      }

    public int [] moveToBlock(){
      // put your answer below
      

      if(isBoardFull() == true || checkForWin() == true){
        return null;
      } else {
        for (int row = 0; row < 3; row++) {     
          if(checkForBlock(board[row,0], board[row,1], board[row,2]) == 1){
            board[row,0] = currentPlayerMark;
            changePlayer();
          } else if(checkForBlock(board[row,0], board[row,1], board[row,2]) == 2){
            board[row,1] = currentPlayerMark;
            changePlayer();
          } else if(checkForBlock(board[row,0], board[row,1], board[row,2]) == 3){
            board[row,2] = currentPlayerMark;

            changePlayer();
          }
        }
        if (currentPlayerMark == 'o'){
        for (int col = 0; col < 3; col++) {     
          if(checkForBlock(board[0,col], board[1,col], board[2,col]) == 1) {
            board[0,col] = currentPlayerMark;
            changePlayer();
          } else if(checkForBlock(board[0,col], board[1,col], board[2,col]) == 2) {
            board[1,col] = currentPlayerMark;
            changePlayer();
          } else if(checkForBlock(board[0,col], board[1,col], board[2,col]) == 3) {
            board[2,col] = currentPlayerMark;
            changePlayer();
          }
        }
        }
        if (currentPlayerMark == 'o'){
          if (checkForBlock(board[0,0], board[1,1], board[2,2]) == 1){
              board[0,0] = currentPlayerMark;
              changePlayer();
          } else if (checkForBlock(board[0,0], board[1,1], board[2,2]) == 2){
              board[1,1] = currentPlayerMark;
              changePlayer();
          } else if (checkForBlock(board[0,0], board[1,1], board[2,2]) == 3){
              board[2,2] = currentPlayerMark;
              changePlayer();
          }
           
           if (checkForBlock(board[0,2], board[1,1], board[2,0]) == 1){
              board[0,2] = currentPlayerMark;
              changePlayer();
          } else if (checkForBlock(board[0,2], board[1,1], board[2,0]) == 2){
              board[1,1] = currentPlayerMark;
              changePlayer();
          } else if (checkForBlock(board[0,2], board[1,1], board[2,0]) == 3){
              board[2,0] = currentPlayerMark;
              changePlayer();
          }

          }
         
        if (checkForWin() == true){
            changePlayer();
        }
     // if computer player can not find cell to stop human player, return null
        return null;
    }
    }

    
    /* 
      Question: moveToWin
      When computer player make a move, it should check if it will win after placing a marker on an empty cell.
      if computer player will win after placing a marker on a cell, computer player should return the index of that cell within 1d-array; Else, computer player can not find cell to win, return null
  

      E.g: In the follwoing situation, the computer player should place a marker on cell (0,2) to get a win.

      Hint: the logic to find a win move is similiar to the moveToBlock. But in this method, we will test a win with marker of computer player.
                                  -------------
                                  | x |   | E |
                                  -------------
                                  | x | o |   |
                                  -------------   
                                  | o |   | x | 
                                  ------------- 
    */
    private int checkForWinMove(char c1, char c2, char c3){
      if(c1 == c2 && c3 == ' ' && c1 != ' ' && c1 != 'x'){
        return 3;
      }else if(c1 == c3 && c2 == ' ' && c1 != ' ' && c1 != 'x'){
        return 2;
      }else if(c2 == c3 && c1 == ' ' && c2 != ' ' && c2 != 'x'){
        return 1;
      }else {
        return 4;
      }
      }


    public int [] moveToWin(){
      if(isBoardFull() == true){
        return null;
      } else {
        for (int row = 0; row < 3; row++) {     
          if(checkForWinMove(board[row,0], board[row,1], board[row,2]) == 1){
            board[row,0] = currentPlayerMark;
            changePlayer();
          } else if(checkForWinMove(board[row,0], board[row,1], board[row,2]) == 2){
            board[row,1] = currentPlayerMark;
            changePlayer();
          } else if(checkForWinMove(board[row,0], board[row,1], board[row,2]) == 3){
            board[row,2] = currentPlayerMark;
            changePlayer();
          }
        }
        if (currentPlayerMark == 'o'){
        for (int col = 0; col < 3; col++) {     
          if(checkForWinMove(board[0,col], board[1,col], board[2,col]) == 1) {
            board[0,col] = currentPlayerMark;
            changePlayer();
          } else if(checkForWinMove(board[0,col], board[1,col], board[2,col]) == 2) {
            board[1,col] = currentPlayerMark;
            changePlayer();
          } else if(checkForWinMove(board[0,col], board[1,col], board[2,col]) == 3) {
            board[2,col] = currentPlayerMark;
            changePlayer();
          }
        }
        }
        if (currentPlayerMark == 'o'){
          if (checkForWinMove(board[0,0], board[1,1], board[2,2]) == 1){
              board[0,0] = currentPlayerMark;
              changePlayer();
          } else if (checkForWinMove(board[0,0], board[1,1], board[2,2]) == 2){
              board[1,1] = currentPlayerMark;
              changePlayer();
          } else if (checkForWinMove(board[0,0], board[1,1], board[2,2]) == 3){
              board[2,2] = currentPlayerMark;
              changePlayer();
          }
           
           if (checkForWinMove(board[0,2], board[1,1], board[2,0]) == 1){
              board[0,2] = currentPlayerMark;
              changePlayer();
          } else if (checkForWinMove(board[0,2], board[1,1], board[2,0]) == 2){
              board[1,1] = currentPlayerMark;
              changePlayer();
          } else if (checkForWinMove(board[0,2], board[1,1], board[2,0]) == 3){
              board[2,0] = currentPlayerMark;
              changePlayer();
          }

          }
    
      if (checkForWin() == true){
            changePlayer();
        }



      // if computer player can not find cell to win, return null
        return null;
    }
    }

    /* 
        Question: moveRandom
        If computer player could not find a move for block or win. Then return the index of the first empty cell as a random move.
        
        E.g: In the follwoing situation, the row/col index of next move for the computer player ('o') should be (0,1). Assign (0,1) to 1d-arrya: move and return it
                                    -------------
                                    | x | E |   |
                                    -------------
                                    |   | o |   |
                                    -------------   
                                    |   |   | x | 
                                    ------------- 
    */
    private int[] moveRandom(){
    if (checkForWin() == false){
     if (isBoardFull() == false){
      if (currentPlayerMark == 'o'){
      bool roll = true;
      while (roll == true){
      int [] PositionToRandom = new int [2];
        Random rd = new Random();
         int i = rd.Next(0,3);
         int j = rd.Next(0,3);
          if(board[i,j] == ' ' && board[i,j] != 'x' && board[i,j] != 'o'){
            PositionToRandom[0] = i;
            PositionToRandom[1] = j;
            roll = false;
            return PositionToRandom;
           }
     }
      }
     }
    }
       return null;
    }
       // put your answer below


    /* 
        Question: moveAI
        Make a move for the computer player. Check the:
            1. moveToWin
            2. moveToBlock
            3. moveRandom
        if moveToWin return index of cell for a win, assign the returned index to 1d-arry: move
        else check moveToBlock for a cell to block human player's win and assign the returned index to 1d-arry: move
        otherwise, use the random move from moveRandom and assign the returned index to 1d-arry: move

        Finally, print index of computer player's move. E.g.: Computer Player (o) moves: 2,0

    */
    public void moveAI(int[] move)
    {
      // put your answer below
      int[] toWin = moveToWin();
      int[] toBlock = moveToBlock();
      int[] toRandom = moveRandom();

      if(toWin!=null){
        move[0]=toWin[0];
        move[1]=toWin[1];
   
      }
      
      if(toBlock!=null && checkForWin() == false){
        move[0]=toBlock[0];
        move[1]=toBlock[1];
     
      }
    
      if(toRandom!=null){
        move[0]=toRandom[0];
        move[1]=toRandom[1];
     
  
    }
}


    /* 
        Question: Play
        After creating an object of TicTacToe in MainClass, call this Play() method to strat game.
        Follow the code comments to implement this method

    */

    public void Play(){
      // Print initial game board with printBoard()

       printBoard();

      // use a loop to keep game running until a player win, or there is a tie (when the board is full and no play wins).
      while(true) 
      {
        // print out which player goes first, 
        // if computer player goes fist, print: === Computer Player (o) ===; and make a move for computer by calling moveAI
        // else: print ## Human Player (x) ## and call movePlayer()
          
          Console.WriteLine("## Human Player (x) ##");
          movePlayer();

          placeMark(move);
          if (currentPlayerMark == 'x'){
            if(checkForWin() == true){
              printBoard();
              Console.WriteLine("Human Player Win!");
              break;
            }
            changePlayer(); 
          }
            printBoard();
          
          
          if (checkForWin() != true){
            Console.WriteLine("=== Computer Player (o) ===");
            moveAI(move);
          }
            placeMark(move);    
           if (currentPlayerMark == 'o'){               
            if(checkForWin() == true){
              printBoard();
              Console.WriteLine("Computer Player Win!");
              break;
           }
            changePlayer(); 
          }
        printBoard();
        if(checkForWin() == true){
          if(currentPlayerMark == 'x'){
            Console.WriteLine("Human Player Win!");
          } else {
            Console.WriteLine("Computer Player Win!");
          }
          break;
        }
        if(isBoardFull() == true){
          Console.WriteLine("Appears we have a draw!");
          break;
        }
        
        

        // call placeMark to place a marker based on the 1d-array: move
        



        // Print gameboard if(currentPlayerMark == 'o'){

   
        // Do we have a winner ?! Call checkForWin to decide a winner
        // if we have a winner, break the loop and stop the game
        // print computer or human player win (based on the value of currentPlayerMark)
         
         



        

        // It is a draw ?! (check if board is full), break the loop and stop the game
        // print  Appears we have a draw!
        
        


        // if No winner or a draw => call changePlayer() to switch players and go next round 

    }

    }

}