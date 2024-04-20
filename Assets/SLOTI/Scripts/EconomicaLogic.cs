using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomicaLogic : MonoBehaviour
{
    
    [SerializeField] private int currency;
    [SerializeField] private TextingManager textManager;

    [SerializeField] private GameObject insufficientFundsPanel;

    public int Currency { get => currency;}


    private void Start()
    {
        currency = PlayerPrefs.GetInt("gold", 1000);
    }

    public void IncrementCurrency(int incrementValue)
    {
        currency += incrementValue;
        PlayerPrefs.SetInt("gold", Currency);
        textManager.changeText(Currency);
    }    

    public void UpdateScore(int score) 
    {
        textManager.changeScore(score);
    }

    public bool DecrementCurrency(int decrementValue) 
    {
        if (currency > decrementValue)
        {
            currency -= decrementValue;
            PlayerPrefs.SetInt("gold", Currency);
            textManager.changeText(currency);
            return true;
        }

        insufficientFundsPanel.SetActive(true);
        return false;

    }

    public void UpdateStakeValue(int stake)
    {
        textManager.changeStacka(stake);
    }



}
