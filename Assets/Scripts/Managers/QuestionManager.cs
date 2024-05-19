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
    public Transform JPImage;
    public List<Transform> SacrificeImages = new List<Transform>();
    public QuestionUI question;
    private GameManager _gameManager;
    private string _currentCategory;
    private QuestionModel _currentQuestion;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _currentCategory = _gameManager.GetCurrentCategory();
        FindObjectOfType<Audiomanager>().Stop("Main theme");
        FindObjectOfType<Audiomanager>().Stop("Wheel theme");
        FindObjectOfType<Audiomanager>().Play("Question theme");
        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        _currentQuestion = _gameManager.getQuestionCategory(_currentCategory);
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
            JPImage.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
            SacrificeImages.ForEach(image => image.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
            FindObjectOfType<Audiomanager>().Play("Right Answer");
        }
        else
        {
            TweenResult(WrongImage);
            FindObjectOfType<Audiomanager>().Play("Wrong answer");
            Sequence result = DOTween.Sequence();
            result.Append(JPImage.DORotate(new Vector3(0, 0, 30), 0.5f, RotateMode.Fast));
            result.Append(JPImage.DORotate(new Vector3(0, 0, -30), 0.5f, RotateMode.Fast));
            result.Append(JPImage.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast));
            SacrificeImages.ForEach(image => image.DOScale(0f, 0.2f).SetEase(Ease.Linear));
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
