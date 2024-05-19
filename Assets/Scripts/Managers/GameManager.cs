using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameModel config;
    private string _currentCategory;
    private List<int> _askedQuestionsId = new List<int>();

    public QuestionModel getQuestionCategory(string categoryName)
    {
        CategoryModel categoryModel = config.categories
        .FirstOrDefault(category => category.categoryName == categoryName);
        if (categoryModel != null)
        {
            int randomIndex = Random.Range(0, categoryModel.questions.Count);
            while (categoryModel.questions.Count > _askedQuestionsId.Count
            && _askedQuestionsId.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, categoryModel.questions.Count);
            }
            _askedQuestionsId.Add(randomIndex);
            return categoryModel.questions[randomIndex];
        }
        return null;
    }

    public void SetCurrentCategory(string category)
    {
        _currentCategory = category;
        _askedQuestionsId.Clear();
    }

    public string GetCurrentCategory()
    {
        return _currentCategory;
    }
}
