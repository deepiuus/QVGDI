using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameModel config;
    private string _currentCategory;
    private List<int> _askedQuestionsId = new List<int>();

    private void OnEnable()
    {
        PanelEvents.OnWheelScreenRequested += ShowWheelScreen;
    }

    private void OnDisable()
    {
        PanelEvents.OnWheelScreenRequested -= ShowWheelScreen;
    }


    private void ShowWheelScreen()
    {
        PanelManager.Instance.ShowPanel("WheelScreen");
    }

    public QuestionModel getQuestionCategory(string categoryName)
    {
        CategoryModel categoryModel = config.categories
        .FirstOrDefault(category => category.categoryName == categoryName);
        if (categoryModel != null)
        {
            int nextIndex = _askedQuestionsId.Count;
            if (nextIndex < categoryModel.questions.Count)
            {
                _askedQuestionsId.Add(nextIndex);
                return categoryModel.questions[nextIndex];
            }
            else
            {
                PanelManager.Instance.ShowPanel("WheelScreen", PanelShowBehaviour.HIDE_PREVIOUS);
                FindObjectOfType<Audiomanager>().Stop("Question theme");
                FindObjectOfType<Audiomanager>().Play("Wheel theme");
                return null;
            }
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
