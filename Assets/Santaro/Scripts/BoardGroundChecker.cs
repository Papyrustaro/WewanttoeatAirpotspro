using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 8(board)の、接地判定用Collider
/// </summary>
public class BoardGroundChecker : MonoBehaviour
{
    [SerializeField] private BoardMovement boardMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            boardMovement.OnGrounded();
        }
    }
}
