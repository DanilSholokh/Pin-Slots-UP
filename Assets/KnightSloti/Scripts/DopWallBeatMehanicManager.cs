using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopWallBeatMehanicManager : MonoBehaviour
{


    [SerializeField] private List<RectTransform> wallsTransform;

    [SerializeField] private CandyWallData wallOrange;
    [SerializeField] private CandyWallData wallGreen;
    [SerializeField] private CandyWallData wallRed;

    [SerializeField] private List<CandyWallData> fakeWalls = new List<CandyWallData>();


    private int orangeCount = 8;
    private int greenCount = 7; 
    private int redCount = 6;


    public void createMap()
    {

        for (int i = 0; i < wallsTransform.Count; i++) 
        {
            fakeWalls.Add(Instantiate(randomColor(), wallsTransform[i]));

        }

    }

    public void deleteMap()
    {
        for (int i = fakeWalls.Count - 1; i >= 0; i--)
        {
            if (fakeWalls[i] != null)
            {
                Destroy(fakeWalls[i].gameObject);
            }

            fakeWalls.RemoveAt(i);
        }

        refreshData();

    }


    private CandyWallData randomColor()
    {

        List<CandyWallData> sprites = new List<CandyWallData>();

        if (orangeCount > 0)
        {
            sprites.Add(wallOrange);
        }
        if (greenCount > 0)
        {
            sprites.Add(wallGreen);
        }
        if (redCount > 0)
        {
            sprites.Add(wallRed);
        }

        if (sprites.Count == 0)
        {
            return null;
        }

        int rand = Random.Range(0, sprites.Count);
        CandyWallData randomSprite = sprites[rand];

        if (randomSprite == wallOrange)
        {
            orangeCount--;
        }
        else if (randomSprite == wallGreen)
        {
            greenCount--;
        }
        else if (randomSprite == wallRed)
        {
            redCount--;
        }

        return randomSprite;

    }    


    private void refreshData()
    {
        orangeCount = 7;
        greenCount = 7;
        redCount = 6;
    }    




}
