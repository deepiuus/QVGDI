using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestionManager : Singleton<QuestionManager>
{
    public static Action OnNewQuestionLoaded;
    public static Action OnAnswerProvided;
    public Transform CorrectImage;
    public Transform WrongImage;
    public QuestionUI question;
    public string categoryName;
    private GameManager _gameManager;
    private QuestionModel _currentQuestion;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        _currentQuestion = _gameManager.getQuestionCategory(categoryName);
        if (_currentQuestion != null)
        {
            question.PopulateQuestion(_currentQuestion);
        }
        OnNewQuestionLoaded?.Invoke();
    }

    public bool AnswerQuestion(int answerIndex)
    {
        OnAnswerProvided?.Invoke();
        bool isCorrect = _currentQuestion.correctAnswer == answerIndex;

        if (isCorrect)
        {
            TweenResult(CorrectImage);
        }
        else
        {
            TweenResult(WrongImage);
        }
        return isCorrect;
    }
    
    private void TweenResult(Transform image)
    {
        Sequence result = DOTween.Sequence();
        result.Append(image.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
        result.AppendInterval(1f);
        result.Append(image.DOScale(0f, 0.2f).SetEase(Ease.Linear));
        result.AppendCallback(LoadNextQuestion);
    }
}
