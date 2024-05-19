using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUI : MonoBehaviour
{
    public TextMeshProUGUI QuestionLabel;
    public TextMeshProUGUI Answer1Label;
    public TextMeshProUGUI Answer2Label;
    public TextMeshProUGUI Answer3Label;
    public TextMeshProUGUI Answer4Label;

    public void PopulateQuestion(QuestionModel questionModel)
    {
        QuestionLabel.text = questionModel.question;
        Answer1Label.text = questionModel.answerA;
        Answer2Label.text = questionModel.answerB;
        Answer3Label.text = questionModel.answerC;
        Answer4Label.text = questionModel.answerD;
    }
}
