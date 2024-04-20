using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    [SerializeField] Sprite colorWall;
    [SerializeField] private int idArrow = 0; // 0 - greenWall, 1 - orange, 2 - red
    [SerializeField] private MoveObjectUp moveUp;

    private BowWallLogic bowWallLogic;
    private BowManager bowManager;

    public MoveObjectUp MoveUp { get => moveUp; set => moveUp = value; }
    public BowWallLogic BowWallLogic { get => bowWallLogic; set => bowWallLogic = value; }
    public BowManager BowManager { get => bowManager; set => bowManager = value; }

    private void Awake()
    {
        MoveUp = GetComponent<MoveObjectUp>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CandyWall")
        {
            int idWall = collision.GetComponent<CandyWallData>().IdWall;

            if (idWall == idArrow)
            {
                Destroy(collision.gameObject);

                if (bowManager.CurrentArrow == null)
                {
                    BowWallLogic.loseScenario();
                }

                Destroy(gameObject);
            }
            else if(idWall == 4)
            {
                BowWallLogic.winScenario();
            }
            else
            {
                if (bowManager.CurrentArrow == null)
                {
                    BowWallLogic.loseScenario();
                }
                
                Destroy(gameObject);
            }
        }
    }



}
