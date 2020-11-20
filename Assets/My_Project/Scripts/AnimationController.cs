using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject gameObject;
    [SerializeField] private int Save = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        Save = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        

        if (Input.GetKeyDown(KeyCode.J))
        {
            Combate();
        }
    }

    void AttackA()
    {
        Save = 1;
    }
    void AttackB()
    {
        Save = 2;
    }
    void AttackC()
    {
        Save = 3;
    }
    void Resetar()
    {
        Save = 0;
        animator.SetBool("Combate", false);
    }

    void Combate()
    {
        switch(Save)
        {
            case 0:
                {
                    animator.Play("Combo_1");
                    break;
                }
            case 1:
                {
                    animator.Play("Combo_2");
                    break;
                }
            case 2:
                {
                    animator.Play("Combo_3");
                    break;
                }
            case 3:
                {
                    animator.Play("Combo_4");
                    break;
                }
        }
    }
}
