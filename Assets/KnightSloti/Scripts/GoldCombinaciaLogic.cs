using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GoldCombinaciaLogic : MonoBehaviour
{


    private int stavka = 10; 
    private EconomicaLogic economica;

    private float score = 0;

    [SerializeField] SlotsManager slotsManager;
    [SerializeField] BowWallLogic bowWallLogic;

    private FruitData[,] tableFruits;

    public int Stavka { get => stavka; set => stavka = value; }

    private void Start()
    {
        economica = GetComponent<EconomicaLogic>();
        tableFruits = new FruitData[slotsManager.getX(), 3];



    }


    public void winPrize(int prize)
    {
        economica.IncrementCurrency(prize);

    }



    public void combinacia()
    {

        slotsManager.ganarateDataResultSlots(tableFruits);

        score = 0;
        int max_y = slotsManager.getY();

        for (int y = 0; y < max_y; y++)
        {

            checkColumCombination(y, 0);

        }

        if (score > 0)
        {
            bowWallLogic.addArrowToList();
        }


        economica.UpdateScore((int)score);
        winPrize((int)score);


    }

    public void checkColumCombination(int fruitSlot_y, int itepritator)
    {

        int x_max = slotsManager.getX();
        int x_row = itepritator;

        FruitData currentFruit = tableFruits[itepritator, fruitSlot_y];

        if (itepritator < x_max)
        {

            int min_idCellColum = 0;
            int max_idCellColum = 0;

            if (fruitSlot_y == 0)
            {
                min_idCellColum = 0;
                max_idCellColum = 2;
            }
            else if (fruitSlot_y == 1)
            {
                min_idCellColum = 0;
                max_idCellColum = 3;
            }
            else if (fruitSlot_y == 2)
            {
                min_idCellColum = 1;
                max_idCellColum = 3;
            }


            for (int i = min_idCellColum; i < max_idCellColum; i++)
            {

                if (x_row + 1 < slotsManager.getX())
                {

                    if (currentFruit.IndexFruit == tableFruits[x_row + 1, i].IndexFruit)
                    {
                        tableFruits[x_row + 1, i].fruitWin();

                        score += currentFruit.Prize * Stavka;
                        score = score * (x_row + 1);

                        if (x_row + 1 < x_max)
                        {
                            checkColumCombination(i, x_row + 1);
                        }

                        break;

                    }
                }


            }

        }



    }



    public void upStavka()
    {
        int oldStavka = Stavka;
        Stavka = Stavka * 2;

        if (Stavka > 100)
        {
            Stavka = (oldStavka == 100) ? 10 : 100;
        }
        else if (Stavka < 10)
        {
            Stavka = 100;
        }

        economica.UpdateStakeValue(Stavka);
    }










}
