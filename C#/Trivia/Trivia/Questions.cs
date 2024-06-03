namespace Trivia;

public class Questions
{
    private readonly Dictionary<string, List<string>> _categoriesMap = new();
    private readonly List<string> _categories =  Enum.GetNames(typeof(Categories)).ToList();
    
    public Questions()
    {
        InitialiseCategories();
    }
    
    private void InitialiseCategories()
    {
        foreach (var category in _categories)
        {
            _categoriesMap.Add(category, new List<string>());
        }

        for (int i = 0; i < 50; i++)
        {
            foreach (var category in _categories)
            {
                _categoriesMap[category].Add(category + " " + "Questions " + i);
            }
        }
    }

    public List<string> GetQuestions(Player player)
    {
        var category = GetCurrentCategory(player);
        return _categoriesMap[category];
    }
    
    public string GetCurrentCategory(Player player)
    {
        return _categories[player.GetPlace() % 4];
    }
}
