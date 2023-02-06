using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum StateType //���A���O���U(�T�|����)
{ 
    Idle,Teleport,AttackPrepair,Attack
}
[Serializable]
public class Parameter //�򥻰ѼƩw�q�A�åѳo�����Τ@�޲z
{
    public int Health;                  //�ͩR��
    public float IdleTime;              //�ݾ��ɶ�
    public float TeleportCD;            //�ǰe�N�o�ɶ�
    public bool A = false;              //�ǰe����}��
    public Animator Animator;           //����ʵe�޲z��
    public Transform transform;         //����ۨ��y�ЦV�q
    public Transform[] TeleportPoint;   //�q�ǰe�I�C������y�ЦV�q
    public GameObject TeleportTarget;   //�ǰe�ؼ�
}
public class FSM : MonoBehaviour
{
    public Parameter parameter;
    private IState currentState;    //�Ҧ���{�o��IState��(class)�A���i
    private Dictionary<StateType,IState> States = new Dictionary<StateType, IState>();  //�n���@�Ӧr��Ӥ�K�d�䪬�A(�r�媺Key�Ȭ��W���Ыت�StateType)
    void Start()
    {
        parameter.Animator = GetComponent<Animator>();  //����ʵe�޲z��
        parameter.transform = GetComponent<Transform>();
        States.Add(StateType.Idle, new IdleState(this));            //�s�W�r�夺��ȹ�-�ݾ�(�NIdleState.cs�̪�IdleState���U�i�Ө�l���A�P�z)
        States.Add(StateType.Teleport, new TeleportState(this));    //�s�W�r�夺��ȹ�-�ǰe
        //States.Add(StateType.Attack, new AttackState(this));

        TransitionState(StateType.Idle);                            //�b�}�l�ɱN���A�������ݾ�

        
    }

    void Update()
    {
        currentState.onUpdate();     // �C�������U���A�һݰ��檺�N�X(�ثe��U���A�ޥΦ�IdleState.cs��)
    }
    public void TransitionState(StateType type)     //���A���������(��k)
    {
        if (currentState!= null)
            currentState.onExit();  //�p�G���e�@�Ӫ��A�A������e�@�q���A���������
        currentState=States[type];  //�������A�����w���A
        currentState.onEnter();     //����s���A
    }
    public void FlipTo(Transform target) //�ݦV���a�o���(��k)
    {
        if (target != null)
        {
            if(transform.position.x >target.position.x)
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }
    }

    public void TT() //�ǰe�ʵeĲ�o�ǰe�}��
    {
        parameter.A = true;
        Debug.Log("Ĳ�o");
    }
}
