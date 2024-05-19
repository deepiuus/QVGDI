using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class WheelUI : MonoBehaviour
{
    public List<string> Categories;
    public Transform PlayButton;
    public Transform Wheel;
    public TextMeshProUGUI PlayText;
    public TextMeshProUGUI SpinText;
    public float RotateDuration;
    public int AmountRotations;
    private bool spinFinished;

    void Start()
    {
        SpinText.transform.DOScale(1.4f, 0.4f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.InOutSine);
    }

    public void SpinWheel()
    {
        if (spinFinished)
        {
            return;
        }
        FindObjectOfType<Audiomanager>().Play("Spinning");
        float randomAngle = Random.Range(0, 360);
        GameManager.Instance.SetCurrentCategory(GetLandedCategory(randomAngle));
        Debug.Log(GetLandedCategory(randomAngle));
        float rotateAngle = (360 * AmountRotations) - randomAngle;
        Wheel.DOLocalRotate(new Vector3(0, 0, rotateAngle * -1), RotateDuration, RotateMode.FastBeyond360)
        .onComplete += WheelFinishedRotating;
        spinFinished = true;
    }

    public void WheelFinishedRotating()
    {
        PlayButton.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        PlayText.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    public string GetLandedCategory(float angle)
    {
        var anglePerCategory = 360 / Categories.Count;
        int index = (int)(angle / anglePerCategory);
        return Categories[index];
    }
}
