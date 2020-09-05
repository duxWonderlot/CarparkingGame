using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manger : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject Winning_Losing_panel;
    public float meter_value;
    public static UI_Manger UI_reference;
    private void Awake()
    {
        if(UI_reference == null)
        {
            UI_reference = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        slider.maxValue = 20;
    }
    private void Start()
    {
        Winning_Losing_panel.SetActive(false);
    }
    private void Update()
    {
        slider.value = meter_value;
        if(meter_value >= slider.maxValue)
        {
            meter_value = 0;
        }
        
    }

    public void Winning_Panel()
    {
        Winning_Losing_panel.SetActive(true);
    }
}


