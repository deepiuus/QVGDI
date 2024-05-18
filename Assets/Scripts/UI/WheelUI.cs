using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheelUI : MonoBehaviour
{
    public List<string> Categories;
    public Transform Wheel;
    public float RotateDuration;
    public int AmountRotations;

    public void SpinWheel()
    {
        float randomAngle = Random.Range(0, 360);
        Debug.Log(GetLandedCategory(randomAngle));
        float rotateAngle = (360 * AmountRotations) - randomAngle;
        Wheel.DOLocalRotate(new Vector3(0, 0, rotateAngle * -1), RotateDuration, RotateMode.FastBeyond360);
    }

    public string GetLandedCategory(float angle)
    {
        var anglePerCategory = 360 / Categories.Count;
        int index = (int)(angle / anglePerCategory);
        return Categories[index];
    }
}
