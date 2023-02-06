using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;

    public class IdleState : IState //�ݾ����A(�Ъ`�N�o�̪����A�O�o��FSM�̶i����U
{
    private FSM manager;         //�ޥη�e���󪺪��A��
    private Parameter parameter; //���o��e���󪺰Ѽ�(�Ҥl:E-10)
    private float timer;         //�ݾ��p�ɾ�

    public IdleState(FSM manager)   
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()   //���AĲ�o�ɰ���
    {
        parameter.Animator.Play("E-10_Idle");
        
    }
    public void onUpdate()  //���A�B�椤����
    {
        timer += Time.deltaTime;
       if (timer >= parameter.IdleTime)
        {
            manager.TransitionState(StateType.Teleport);
            
        }   
        
        

    }
    public void onExit()    //���A�h�X�����
    {
        timer = 0;
    }
}
public class TeleportState : IState //�ǰe���A
{
    FSM manager;
    private Parameter parameter;

    private int TeleportPosition = 0;
    public TeleportState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        parameter.Animator.Play("E-10_Teleport");
    }
    public void onUpdate()
    {
        
        if (parameter.A = true )
        {
            parameter.transform.position = new Vector3(parameter.TeleportPoint[TeleportPosition].position.x, parameter.transform.position.y, parameter.transform.position.z);
            manager.TransitionState(StateType.Idle);    // Debug.Log("�ҥΤ�");
        }
    }
    public void onExit()
    {
        parameter.A = false;    //�ǰe�}������
        TeleportPosition += Random.Range(0,2) ;     //�������H����ܶǰe�I�A�èϤU�@���ǰe�I���|����(��e�ǰe�IID�[�W�H����=�U�@�Ӷǰe�IID�A�p�G�Ȥj��M���`ID�ƱNID�k0)
        if (TeleportPosition >= parameter.TeleportPoint.Length)
        {
            TeleportPosition = 0;        
        }
    }
}

public class AttackPrepairState : IState //�����ǳ�
{
    FSM manager;
    Parameter parameter;
    public AttackPrepairState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        parameter.Animator.Play("E-10_AttackPrepair");
    }
    public void onUpdate()
    {

    }
    public void onExit()
    {

    }
}
public class AttackState : IState   //����Ĳ�o
{
    FSM manager;
    Parameter parameter;
    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        parameter.Animator.Play("E-10_Attack");
    }
    public void onUpdate()
    {
    }
        
    public void onExit()
    {


    }
    
}
public class nulls : IState
{
    FSM manager;
    Parameter parameter;
    public nulls(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        parameter.Animator.Play("E-10_X");
    }
    public void onUpdate()
    {

    }
    public void onExit()
    {

    }
}
