using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColor : MonoBehaviour
{
    public bool isRed;
    public SpriteRenderer spriteRenderer;
    public bool nowisRed;
    public bool nowisBlue;
    //public int score;


    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        isRed = true;
        nowisRed = false;
        nowisBlue = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isRed)
            {
                //Blue
                BlueState();
            }
            else
            {
                //Red
                RedState();
            }
        }
    }

    private void RedState()
    {
        if (nowisBlue)
        {
            GameManager.Instance.GameOver();
            Debug.Log("GameOver");
        }

        ChangeColor(Color.red);
        isRed = true;
    }

    private void BlueState()
    {
        if (nowisRed)
        {
            GameManager.Instance.GameOver();
            Debug.Log("GameOver");
        }
        ChangeColor(Color.blue);
        isRed = false;
    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Red"))
        {
            nowisRed = true;
            nowisBlue = false;
            if (!isRed)
            {
                GameManager.Instance.GameOver();
                Debug.Log("GameOver");
            }
        }
        else if (collision.gameObject.CompareTag("Blue"))
        {
            nowisRed = false;
            nowisBlue = true;
            if (isRed)
            {
                GameManager.Instance.GameOver();
                Debug.Log("GameOver");
            }
        }

        if (collision.gameObject.CompareTag("RedCoin") && isRed)
        {
            GameManager.Instance.setScore();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("BlueCoin") && !isRed)
        {
            GameManager.Instance.setScore();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            //GameManager.Instance.gameOver = true;
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Red"))
        {
            nowisRed = false;
        }
        else if (collision.gameObject.CompareTag("Blue"))
        {
            nowisBlue = false;
            
        }
    }
}
