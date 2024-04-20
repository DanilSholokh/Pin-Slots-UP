using System;
using UnityEngine;

public class DailyLogic : MonoBehaviour
{
    private DateTime _lastLoginDate;
    private EconomicaLogic _economica;

    [SerializeField] private GameObject _dailyPanel;

    private void Start()
    {
        _economica = GetComponent<EconomicaLogic>();

        string lastLoginDateString = PlayerPrefs.GetString("LastLoginDate", DateTime.Now.ToString());
        _lastLoginDate = DateTime.Parse(lastLoginDateString);

        CheckNewDay();
    }
      
    private void CheckNewDay()
    {
        if (IsNewDay())
        {
            RewardDailyLogin();

            _dailyPanel.SetActive(true);

            UpdateLastLoginDate();
        }
    }

    private bool IsNewDay()
    {
        return DateTime.Now.Date != _lastLoginDate.Date;
    }

    private void RewardDailyLogin()
    {
        _economica.IncrementCurrency(100);
    }

    private void UpdateLastLoginDate()
    {
        _lastLoginDate = DateTime.Now;
        PlayerPrefs.SetString("LastLoginDate", _lastLoginDate.ToString());
    }
}
