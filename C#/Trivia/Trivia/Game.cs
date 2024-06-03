using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private const int MaxPlayers = 6;
        private const int MinPlayers = 2;

        private readonly List<Player> _players = new();
        private readonly Questions _questions = new Questions();

        private int _currentPlayerIndex = 0;
        private bool _isGettingOutOfPenaltyBox;

        private Player CurrentPlayer()
        {
            return _players[_currentPlayerIndex];
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= MinPlayers);
        }

        public bool Add(string playerName)
        {
            if (!IsPlayable())
            {
                Console.WriteLine("Cannot Add more players");
                return false;
            }

            _players.Add(new Player(playerName));
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            var currentPlayer = CurrentPlayer();
            Console.WriteLine(currentPlayer.GetName() + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (currentPlayer.IsInPenaltyBox())
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;
                    Console.WriteLine(currentPlayer.GetName() + " is getting out of the penalty box");
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayerIndex] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                    return;
                }
            }

            NextMove(roll);
        }

        private void NextMove(int roll)
        {
            var currentPlayer = CurrentPlayer();
            currentPlayer.MovePlace(roll);
            Console.WriteLine(currentPlayer.GetName() + "'s new location is " + currentPlayer.GetPlace());
            Console.WriteLine("The category is " + _questions.GetCurrentCategory(currentPlayer));
            AskQuestion();
        }

        private void AskQuestion()
        {
            var questions = _questions.GetQuestions(CurrentPlayer());
            Console.WriteLine(questions.First());
            questions.Remove(questions.First());
        }

        public bool WasCorrectlyAnswered()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            if (currentPlayer.IsInPenaltyBox())
            {
                if (!_isGettingOutOfPenaltyBox)
                {
                    NextPlayer();
                    return true;
                }
            }

            CorrectAnswer();
            bool winner = DidPlayerWin();
            NextPlayer();
            return winner;
        }

        private void NextPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }

        private void CorrectAnswer()
        {
            var currentPlayer = CurrentPlayer();
            Console.WriteLine("Answer was correct!!!!");
            currentPlayer.AddCoin();

            Console.WriteLine(currentPlayer.GetName() + " now has " + currentPlayer.GetPurse() +
                              " Gold Coins.");
        }

        public bool WrongAnswer()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayerIndex] + " was sent to the penalty box");
            currentPlayer.PutInJail();

            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
            return true;
        }

        private bool DidPlayerWin()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            return currentPlayer.GetPurse() != 6;
        }
    }
}
