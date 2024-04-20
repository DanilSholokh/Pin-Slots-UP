using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWallLogic : MonoBehaviour
{

    private List<ArrowController> arrowControllers = new List<ArrowController>();

    private List<ArrowController> arsenalArrow = new List<ArrowController>();

    [SerializeField] private GameObject DopContentPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject ArsenalPanel;


    [SerializeField] private DopWallBeatMehanicManager mainManager;
    [SerializeField] private BowManager bowManager;

    [SerializeField] private List<ArrowController> arrowsPrefab;

    public void openDopContent()
    {
        DopContentPanel.SetActive(true);
        mainManager.createMap();


        for (int j = 0; j < arrowControllers.Count; j++)
        {
            arsenalArrow.Add(Instantiate(arrowControllers[j], ArsenalPanel.transform));
        }


        bowManager.createArrow();

        //if (arrowControllers.Count < 3)
        //{

        //    arrowControllers.Clear();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        addArrowToList();
        //    }
        //}



    }

    public void closeDopContent() 
    {
        mainManager.deleteMap();
        DopContentPanel.SetActive(false);

        arsenalArrow.Clear();
        arrowControllers.Clear();
    }

    public void loseScenario()
    {
        losePanel.SetActive(true);
    }

    public void winScenario()
    {
        winPanel.SetActive(true);
    }

    public void addArrowToList()
    {
        int arrow_rand = Random.Range(0, arrowsPrefab.Count);
        arrowControllers.Add(arrowsPrefab[arrow_rand]);

    }


    public ArrowController getArrow()
    {
        if (isCountArrow())
        {
            ArrowController arrowFake = arrowControllers[0];
            arrowControllers.RemoveAt(0);

            Destroy(arsenalArrow[0].gameObject);
            arsenalArrow.RemoveAt(0);

            return arrowFake;
        }
        

        return null;

    }

    public bool isCountArrow()
    { 
        return arrowControllers.Count > 0;
    }


}
