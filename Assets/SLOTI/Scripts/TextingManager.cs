using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class TextingManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textScore;

    [SerializeField] private TextMeshProUGUI textStavka;

    private void Start()
    {
        changeText(PlayerPrefs.GetInt("gold", 1000));
    }

    public void changeText(int goldTExt)
    {
        textGold.text = "" + goldTExt;
    }

    public void changeScore(int goldScore)
    {
        textScore.text = "" + goldScore;
    }

    public void changeStacka(int stacka)
    {
        textStavka.text = "" + stacka;
    }

}
