using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public static AnimatorController instance;

    Transform myTrans;
    Animator myAnim;
    Vector2 artscaleCache;

    void Start()
    {
        myTrans = this.transform;
        myAnim = this.gameObject.GetComponent<Animator>();
        instance = this;
        artscaleCache = myTrans.localScale;


    }



    public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }




    IEnumerator HurtBlinker(float hurtTime)
    {
        //ignore collision with enemies 
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);


        // start looping blink anim
        myAnim.SetLayerWeight(1, 1);

        //wait for incibilty  to end 
        yield return new WaitForSeconds(hurtTime);

        // stop blinking animation and re-anable
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        myAnim.SetLayerWeight(1, 0);
    }

    



}
