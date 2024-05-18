using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameModel config;

    public QuestionModel getQuestionCategory(string categoryName)
    {
        CategoryModel categoryModel = config.categories.FirstOrDefault(category => category.categoryName == categoryName);
        if (categoryModel != null)
        {
            return categoryModel.questions[0];
        }
        return null;
    }
}
