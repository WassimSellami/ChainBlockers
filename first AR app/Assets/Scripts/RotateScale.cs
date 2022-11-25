using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateScale : MonoBehaviour
{
    private Slider scaleSlider;
    private Slider rotateSlider;
    private Slider heightSlider;
    public float ScaleMinValue;
    public float ScaleMaxValue;
    public float RotateMinValue;
    public float RotateMaxValue;
    public float HeightMinValue;
    public float HeightMaxValue;
    void Start()
    {
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        heightSlider = GameObject.Find("HeightSlider").GetComponent<Slider>();
        rotateSlider = GameObject.Find("RotationSlider").GetComponent<Slider>();
        scaleSlider.minValue = ScaleMinValue;
        scaleSlider.maxValue = ScaleMaxValue;
        rotateSlider.minValue = RotateMinValue;
        rotateSlider.maxValue = RotateMaxValue;
        heightSlider.minValue = HeightMinValue;
        heightSlider.maxValue = HeightMaxValue;
        scaleSlider.onValueChanged.AddListener(updateScaleSlider);
        rotateSlider.onValueChanged.AddListener(updateRotateSlider);
        heightSlider.onValueChanged.AddListener(updateHeightSlider);
    }

    private void updateScaleSlider(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
    private void updateRotateSlider(float value)
    {
        transform.localEulerAngles = new Vector3(-90, value, 0);
    }
    private void updateHeightSlider(float value)
    {
        transform.position = new Vector3(transform.position.x, value, transform.position.z);
    }
}
