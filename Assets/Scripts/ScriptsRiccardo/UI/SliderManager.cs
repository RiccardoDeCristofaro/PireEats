using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    
    // healthpoints
    public Slider SliderHP;
    public Text HPtext;
    public float damage = 0.35f;  
    // time 
    public Slider SliderTime;
    public float speedTime = 0f;
    public Text TimeText;


    public void HealthPoint()
    {
        // hp
        SliderHP.value -= Mathf.Clamp(damage,0,1);
    }
    public void Timer(float timer)
    {
        speedTime = timer;
        SliderTime.value -= Time.deltaTime * speedTime;
        TimeText.text = SliderTime.value.ToString();
    }
}
