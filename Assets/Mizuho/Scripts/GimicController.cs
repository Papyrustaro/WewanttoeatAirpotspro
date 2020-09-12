using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicController : MonoBehaviour
{
    [SerializeField] private int level = 0;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (level)
        {
            case 0:
                //StartCoroutine("ZeroGimic");
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            default:
                break;
        }
    }

    /*
    IEnumerator ZeroGimic()
    {
        rb2D.velocity = Vector2.left * 3f;
        //yield return new WaitForSecondsRealtime(1f);
        while (transform.localPosition.x > -1f)
        {
            yield return null;
        }

        StartCoroutine("ZeroGimicBack");
    }
    IEnumerator ZeroGimicBack()
    {
        rb2D.velocity = Vector2.right * 1f;
        //yield return new WaitForSecondsRealtime(3f);
        while (transform.localPosition.x < 1f)
        {
            yield return null;
        }
        rb2D.velocity = Vector2.zero;
    }
    */

}
