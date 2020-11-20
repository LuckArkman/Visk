using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Photon.Chat;
using Photon.Pun;
using Photon.Realtime;

public class SelectCharacter : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform[] Object;

    [SerializeField]
    private Scrollbar scrollbar;

    [SerializeField]
    private int position = 0;
    
    void Start()
    {
        transform.localPosition = Object[position].transform.localPosition;
        
    }

    
    void Update()
    {
        switch(position)
        {
            case 0:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0f;
                    break;
                }
            case 1:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.1099864f;
                        break;
                }
            case 2:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.2212859f;
                        break;
                }
            case 3:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.3318206f;
                        break;
                }
            case 4:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.4400606f;
                        break;
                }
            case 5:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.5521251f;
                        break;
                }
            case 6:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.66113f;
                        break;
                }
            case 7:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.7709076f;
                        break;
                }
            case 8:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.8814422f;
                        break;
                }
            case 9:
                {
                    scrollbar.GetComponent<Scrollbar>().value = 0.991212f;
                    break;
                }

        }
        
    }

    public void Left()
    {
        if (position <= 0 )
        {
            position = 0;
            transform.localPosition = Object[position].localPosition;
        }
        else
        {
            position -= 1;
            transform.localPosition = Object[position].localPosition;

        }

    }

    public void Right()
    {
        if (position >= Object.Length -1)
        {
            position = Object.Length -1;
            transform.localPosition = Object[position].localPosition;
        }
        else
        {
            position += 1;
            transform.localPosition = Object[position].localPosition;

        }
    }
}
