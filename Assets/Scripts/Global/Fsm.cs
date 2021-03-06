using System;

public enum FsmStateEvent
{
	eEnter = 0,
	eUpdate,
	eLeave,
	
	_eMax
}

public abstract class Fsm
{	
	/// Virtual method called when state enter, update or leave occur
	public abstract void OnStateUpdate(FsmStateEvent a_oEvent, uint a_oState);

	/// No state
	static uint GetNoState() { return uint.MaxValue;}
	
	/// Default constructor
	public Fsm()
	{
		m_oCurrentState = GetNoState();
		m_oRequestedState = GetNoState();
		m_oPreviousState = GetNoState();
		m_fCurrentTime = 0f;
		m_fDeltaTime = 0f;
		m_bIsInUpdate = false;
	}
	
	/// Start the state machine update with a state
	public void StartFsm(uint a_newState)
	{
		SetRequestedState(a_newState);
	}
	
	/// Update the state machine
	public void UpdateFsm(float a_fDeltaTime)
	{
		m_bIsInUpdate = true;
		m_fDeltaTime = a_fDeltaTime;
		m_fCurrentTime += a_fDeltaTime;

		_SwitchState();

		// Update current state
		if (m_oCurrentState != GetNoState())
		{
			_UpdateState();
		}
		
		_SwitchState();
		m_bIsInUpdate = false;
	}
	
	/// Stop the state machine update
	public void StopFsm()
	{
		SetRequestedState(GetNoState());
	}
	
	/// Get the current state. 
	/// \warning Return last state, even if state has been asked to leave.
	public uint GetState() { return m_oCurrentState; }
	
	/// Get the previous state. 
	public uint GetPreviousState() { return m_oPreviousState; }
	
	/// Get the requested state. 
	public uint GetRequestedState() { return m_oRequestedState; }
	
	/// Set the next state.
	public void SetRequestedState(uint a_oState)
	{
		_SetRequestedState(a_oState);
		if(m_bIsInUpdate == false)
		{
			_SwitchState();
		}
	}

	/// Get current state time
	public float GetFsmStateTime() { return m_fCurrentTime; }
	
	/// Get delta time
	public float GetFsmDeltaTime() { return m_fDeltaTime; }

	/// Set the current state
	void _SwitchState()
	{
		if (m_oRequestedState != m_oCurrentState)
		{
			//Leave the current state
			_Leave();
			
			// Reset new state time
			m_fCurrentTime = 0f;
			
			// Load new state;
			_Enter();
			
			// Save current state as requested
			m_oRequestedState = m_oCurrentState;
		}
	}
	
	/// Enter new state (use in function SetState)
	void _Enter()
	{
		m_oPreviousState = m_oCurrentState;
		
		// Load the new state
		m_oCurrentState = m_oRequestedState;
		
		// Enter new state
		if (m_oCurrentState != GetNoState())
		{
			OnStateUpdate(FsmStateEvent.eEnter, m_oCurrentState);
		}
	}
	
	/// Leave current state (use in function SetState)
	void _Leave()
	{
		// Leave current state
		if (m_oCurrentState != GetNoState())
		{
			OnStateUpdate(FsmStateEvent.eLeave, m_oCurrentState);
		}
	}
	
	/// Set requested state
	void _SetRequestedState(uint a_oState)
	{
		m_oRequestedState = a_oState;
	}

	void _UpdateState()
	{
		OnStateUpdate(FsmStateEvent.eUpdate, m_oCurrentState);
	}

	/// The current state
	uint m_oCurrentState;

	/// The requested state
	uint m_oRequestedState;
	
	/// The Previous state
	uint m_oPreviousState;
	
	/// Current delta time
	float m_fDeltaTime;
	
	/// Current state time
	float m_fCurrentTime;
	
	/// Ensure SetState is not called during update
	bool m_bIsInUpdate;
}


