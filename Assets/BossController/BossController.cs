using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IDamagable
{
    public int hp = 100;
    private BossStateMachine stateMachine;    

    public void SetDamage(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        stateMachine = GetComponent<BossStateMachine>();
        stateMachine.SetState(0);

        var state = 1;

        while (true)
        {
            if (state == 0)
            {
                yield return new WaitForSeconds(5f);
                stateMachine.SetState(1);

                while (!stateMachine.playerReached)
                {
                    yield return new WaitForEndOfFrame();
                }

                //yield return new WaitForSeconds(0.01f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(1.1f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(1.1f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(1f);
                state = 1;
            }
            else if(state == 1)
            {
                yield return new WaitForSeconds(5f);
                stateMachine.isShooting = true;
                yield return new WaitForSeconds(8f);
                stateMachine.isShooting = false;

                state = 0;
            }
        }
    }    
}
