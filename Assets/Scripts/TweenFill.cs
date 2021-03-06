//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the object's fill.
/// </summary>

[AddComponentMenu("NGUI/Tween/Tween fill")]
public class TweenFill : UITweener
{
#if UNITY_3_5
	public float from = 1f;
	public float to = 1f;
#else
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;
#endif

	UISprite mRect;

	public UISprite cachedRect
	{
		get
		{
			if (mRect == null)
			{
				mRect = GetComponent<UISprite>();
				if (mRect == null) mRect = GetComponentInChildren<UISprite>();
			}
			return mRect;
		}
	}

	[System.Obsolete("Use 'value' instead")]
	public float fill { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public float value { get { return cachedRect.fillAmount; } set { cachedRect.fillAmount = value; } }

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished) { value = Mathf.Lerp(from, to, factor); }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenFill Begin (GameObject go, float duration, float fill)
	{
		TweenFill comp = UITweener.Begin<TweenFill>(go, duration);
		comp.from = comp.value;
		comp.to = fill;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
