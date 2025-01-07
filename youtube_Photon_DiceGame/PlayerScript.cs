using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int curPos, myNum, money;
    public NetworkManager NM;
    public PlayerScript otherPlayer;

    public IEnumerator Move(int diceNum)
    {

        int[] movePos = new int[diceNum];
        bool isZero = false;

        for(int i = 0; i < movePos.Length; i++)
        {
            int plusNum = curPos + i + 1;
            if (plusNum > 23)
            {
                isZero = true;
                plusNum -= 24;
            }
            movePos[i] = plusNum;
        }
        
        for(int i = 0; i < movePos.Length; i++)
        {
            Vector3 targetPos = NM.Pos[movePos[i]].position;
            while (true)
            {
                yield return null;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);
                if (transform.position == targetPos) break;
            }
        }

        if (isZero)
        {
            money += 30;
            print(myNum + "¹ú¾ú½À´Ï´Ù");
        }

        curPos = movePos[movePos.Length - 1];
        NM.Pos[curPos].GetComponent<GroundScript>().TypeSwitch(this, otherPlayer);
    }

    
}
