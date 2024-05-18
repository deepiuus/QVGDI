using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerUI : MonoBehaviour
{
    public Image CorrectImage;

    public Image WrongImage;

    public int answerIndex;

    private bool _canBeClicked = true;

    private void OnEnable()
    {
        QuestionManager.OnNewQuestionLoaded += ResetValues;
        QuestionManager.OnAnswerProvided += AnswerProvided;
    }

    private void OnDisable()
    {
        QuestionManager.OnNewQuestionLoaded -= ResetValues;
        QuestionManager.OnAnswerProvided -= AnswerProvided;
    }

    public void OnAnswerClicked()
    {
        if (_canBeClicked)
        {
            bool result = QuestionManager.Instance.AnswerQuestion(answerIndex);
            if (result)
            {
                CorrectImage.DOFade(1, 0.5f);
            }
            else
            {
                WrongImage.DOFade(1, 0.5f);
            }
        }
    }

    private void AnswerProvided()
    {
        _canBeClicked = false;
    }

    void ResetValues()
    {
        CorrectImage.DOFade(0, 0.2f);
        WrongImage.DOFade(0, 0.2f);
        _canBeClicked = true;
    }
}
