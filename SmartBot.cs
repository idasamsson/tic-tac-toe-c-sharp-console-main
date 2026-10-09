record PositionScore(int Position, int Score);

// TODO: Only offensive

static class SmartBot
{
    static public void MakeMove(Board board)
    {
        char myColor = board.CurrentMarker;
        int scoreBefore = CalculateScore(board, myColor);
        List<PositionScore> scores = new List<PositionScore>();


        // loop through all positions (1 - 9) 
        // calculate score before and after 
        // what do I gain by making a certain move
        for(int move = 1; move <=9; move++)
        {
            // try a move, if not possible, try next move directly
            if(!board.PlaceMarker(move))
            { continue; }
            // get score after tried/potential move
            scores.Add(new PositionScore(move, CalculateScore(board, myColor) - scoreBefore));
            // undo move
            board.RemoveMarker(move);
        }

        // sort the scores list
        scores.Sort((a, b) => a.Score.CompareTo(b.Score));
        // make the move with highest score
        board.PlaceMarker(scores[scores.Count()-1].Position);

    }

   static public int CalculateScore(Board board, char myColor)
    {
        int score = 0;
        char opponentColor = myColor == 'X' ? 'O' : 'X';
        
        foreach(int[][] combo in WinCheck.WinCombos)
        {
            // loop through the positions in one combo
            string colors = "";
            foreach(int [] position in combo)
            {
                int row = position[0];
                int col = position[1];
                colors += board.Matrix[row][col];
            }
            // if the opponent has at least one marker in the combo - no points
            if (colors.Contains(opponentColor))
            {

                continue;
            }
            // three in a row

            if(colors[0] == myColor && colors[1] == myColor && colors[2]  == myColor)
            {
                score += 100;
            }

            // two in same combo
            else if(colors.Contains(myColor) && colors.IndexOf(myColor) != colors.LastIndexOf(myColor))
            {
                score += 10;
            } 

            else if (colors.Contains(myColor))
            {
                score += 1;
            }
        }
        return score;
    }
}