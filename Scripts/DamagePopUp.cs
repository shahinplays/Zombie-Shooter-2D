using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    // Show damage pop up
    public static DamagePopUp Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        Transform damagePopUpTransform = Instantiate(GameManager.instance.damagePopUp, position, Quaternion.identity);
        
        DamagePopUp damagePop = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePop.Setup(damageAmount, isCriticalHit);

        return damagePop;
    }




    private static int sortingOrder;

    private TextMeshPro textMesh;
    private float disappear_Timer_Max = 1;
    private float disappearTimer;
    private float desappearSpeed = 3f;
    private Color textColor;
    private Vector3 moveVictor;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    
    public void Setup(int damageAmount, bool isCriticalHit)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit)
        {
            textMesh.fontSize = 15f;
            textColor = Color.white;
        }
        else
        {
            textMesh.fontSize = 15f;
            textColor = Color.red;
        }
        textMesh.color = textColor;
        disappearTimer = disappear_Timer_Max;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        moveVictor = new Vector3(0.7f, 0.7f) * 10f;
    }



    private void Update()
    {       
        transform.position += moveVictor * Time.deltaTime;
        moveVictor -= moveVictor * 10f * Time.deltaTime;

        if (disappearTimer > disappear_Timer_Max * 0.5f)
        {
            //first half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            //second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            //start disappearing;
            textColor.a -= desappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }









}
