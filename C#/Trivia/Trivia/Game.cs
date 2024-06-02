using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private const int MaxPlayers = 6;
        private const int MinPlayers = 2;

        private static readonly string[] Categories =
        [
            "Pop", "Science", "Sports", "Rock"
        ];

        private readonly List<string> _players;
        private readonly int[] _places;
        private readonly int[] _purses;
        private readonly bool[] _inPenaltyBox;
        private readonly Dictionary<string, List<string>> _categoriesMap;
        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;


        public Game()
        {
            _currentPlayer = 0;
            _players = new List<string>();
            _places = new int[MaxPlayers];
            _purses = new int[MaxPlayers];
            _inPenaltyBox = new bool[MaxPlayers];
            _categoriesMap = new Dictionary<string, List<string>>();
            InitialiseCategories();
        }

        private void InitialiseCategories()
        {
            foreach (var category in Categories)
            {
                _categoriesMap.Add(category, new List<string>());
            }

            for (int i = 0; i < 50; i++)
            {
                foreach (var category in Categories)
                {
                    _categoriesMap[category].Add(category + " " + "Questions" + i);
                }
            }
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= MinPlayers);
        }

        public bool Add(string playerName)
        {
            _players.Add(playerName);
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
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    _places[_currentPlayer] = _places[_currentPlayer] + roll;
                    if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                    Console.WriteLine(_players[_currentPlayer] + "'s new location is " + _places[_currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                _places[_currentPlayer] += roll;
                if (_places[_currentPlayer] > 11) _places[_currentPlayer] -= 12;

                Console.WriteLine(_players[_currentPlayer] + "'s new location is " + _places[_currentPlayer]);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            var category = CurrentCategory();
            var questions = _categoriesMap[category];
            Console.WriteLine(questions.First());
            questions.Remove(questions.First());
        }

        private String CurrentCategory()
        {
            return Categories[_places[_currentPlayer] % 4];
        }

        public bool WasCorrectlyAnswered()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _purses[_currentPlayer]++;
                    Console.WriteLine(_players[_currentPlayer] + " now has " + _purses[_currentPlayer] +
                                      " Gold Coins.");

                    bool winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }
                else
                {
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                _purses[_currentPlayer]++;
                Console.WriteLine(_players[_currentPlayer]
                                  + " now has "
                                  + _purses[_currentPlayer]
                                  + " Gold Coins.");

                bool winner = DidPlayerWin();
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return _purses[_currentPlayer] != 6;
        }
    }
}