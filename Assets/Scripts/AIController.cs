using UnityEngine;
using System.Collections;

public interface IAIState{
	void Handle (AIController context);
}
public class DoNothingState : IAIState{
	public const int m_key = 1;
	public const int HOLDTIME = 2;	// 每次站立时间
	public int m_beginTime;			// 站立开始时间

	public DoNothingState(){
		this.m_beginTime = Time.time;
	}

	public void Handle (AIController context){
		if(Time.time - this.m_beginTime > this.HOLDTIME){	// 站立结束
			int Rnd = Random.Range(0, 3);
			switch(Rnd){
			case 0:
				context.m_currentState = new DoNothingState();
				break;
			case 1:
				context.m_currentState = new PatrolState();
				break;
			default:
				break;
			}
		}
	}
}
public class PatrolState : IAIState{
	public const int m_key = 2;
	public Vector3 m_nextPosition;

	public PatrolState(){
		var randX = Random.Range (0, 100);
		var randY = Random.Range (0, 100);
		var randZ = Random.Range (0, 100);
		this.m_nextPosition = new Vector3 (randX, randY, randZ);
	}
	public void Handle (AIController context){
		var isFindHero = context.IsFindHero ();
		if (isFindHero) {
			context.m_currentState = new RunningState ();
		} else {
			
		}
	}
}
public class RunningState : IAIState{
	public const int m_key = 3;

	public void Handle (AIController context){
		context.RunForFight ();
	}
}
public class FightingState : IAIState{
	public const int m_key = 4;

	public void Handle (AIController context){
		
	}
}


public class AIController : MonoBehaviour {
	//游戏角色
	public GameObject Hero;
	const int AI_ATTACT_DISTANCE = 5;
	const int AI_FIND_DISTANCE = 100;

	public IAIState m_currentState;

	public int m_runningSpeed = 2;
	public int m_patrolSpeed = 1;

	public void RunForFight(){
		
	}
	public bool IsFindHero(){
		return Vector3.Distance (transform.position, Hero.transform.position) < AI_FIND_DISTANCE;
	}
	public bool CanFight(){
		return Vector3.Distance (transform.position, Hero.transform.position) < AI_ATTACT_DISTANCE;
	}
	public void MoveTo(Vector3 targetPosition){
		
	}

	void Start () 
	{
	}

	void Update () 
	{
	}
}
