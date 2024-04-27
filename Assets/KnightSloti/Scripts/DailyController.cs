using System;
using UnityEngine;

public class DailyController : MonoBehaviour
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
        if (IsNewDayComplete())
        {
            RewardDaily();

            _dailyPanel.SetActive(true);

            UpdateLastDate();
        }
    }

    public void dailyView()
    {
        CheckNewDay();

        if (IsNewDayComplete())
        {
            Destroy(_dailyPanel);
            _dailyPanel = null;
        }

        _economica.StopAllCoroutines();

    }

    private bool IsNewDayComplete()
    {
        return DateTime.Now.Date != _lastLoginDate.Date;
    }

    private void RewardDaily()
    {
        _economica.IncrementCurrency(100);
    }

    private void UpdateLastDate()
    {
        _lastLoginDate = DateTime.Now;
        PlayerPrefs.SetString("LastLoginDate", _lastLoginDate.ToString());
    }


    public bool isDayLoop()
    {
        int countDay = _lastLoginDate.Day;

        if (countDay > 0) 
        {

            RewardDaily();
            return true;
        }

        return false;

    }

}
