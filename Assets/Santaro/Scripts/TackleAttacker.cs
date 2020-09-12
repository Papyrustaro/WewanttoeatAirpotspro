using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 6の角のの処理。動くgameObjectにアタッチする。this.transformを参照するため。
/// </summary>
public class TackleAttacker : MonoBehaviour
{
    [SerializeField] private Movement movement;

    [SerializeField] private GameObject upSixHorn;
    [SerializeField] private GameObject rightSixHorn;
    [SerializeField] private GameObject leftSixHorn;

    private E_HornDirection currentHornDirection = E_HornDirection.Up;

    private void Update()
    {
        if (movement.canMove)
        {
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && this.currentHornDirection != E_HornDirection.Right)
            {
                this.currentHornDirection = E_HornDirection.Right;
                this.rightSixHorn.SetActive(true);
                this.leftSixHorn.SetActive(false);
                this.upSixHorn.SetActive(false);
            }
            if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && this.currentHornDirection != E_HornDirection.Left)
            {
                this.currentHornDirection = E_HornDirection.Left;
                this.rightSixHorn.SetActive(false);
                this.leftSixHorn.SetActive(true);
                this.upSixHorn.SetActive(false);
            }
            if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && this.currentHornDirection != E_HornDirection.Up)
            {
                this.currentHornDirection = E_HornDirection.Up;
                this.rightSixHorn.SetActive(false);
                this.leftSixHorn.SetActive(false);
                this.upSixHorn.SetActive(true);
            }
        }
        else
        {
            this.currentHornDirection = E_HornDirection.Up;
            this.rightSixHorn.SetActive(false);
            this.leftSixHorn.SetActive(false);
            this.upSixHorn.SetActive(true);
        }

        return;
    }

    private enum E_HornDirection
    {
        Up,
        Right,
        Left,
        Other
    }
}
