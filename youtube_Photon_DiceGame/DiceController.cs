using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform[] nums;
    public int num;

    public IEnumerator Roll()
    {
        transform.position = new Vector3(0, 3, 0);
        transform.localEulerAngles = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90));
        //angularVelocity -> 회전속도 , insideUnitSphere -> Vector3반환(각각 x,y,z 값 반환)
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(-1000, 1000);

        yield return new WaitForSeconds(3);

        while (true)
        {
            yield return null;
            if (rb.velocity.sqrMagnitude < 0.001f) break; //sqrMagnitude 대신 magnitude 사용해도되지만 계산량 향상
        }

        //주사위의 네모에서 1이상의 값은 맨 위값이라 생각하고 그 값은 가져와서 num에 대입
        for(int i =0; i < nums.Length; i++)
        {
            if (nums[i].position.y > 1)
            {
                num = i + 1;
                break;
            }
        }
    }
}
