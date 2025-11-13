using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class EnumExtensions
{
	public static T RandomEnumValue<T> ()
	{
		var v = Enum.GetValues (typeof (T));
		return (T) v.GetValue (Random.Range(0, v.Length));
	}
	public static T RandomEnumValueExcept<T> (T except)
	{
		var v = Enum.GetValues (typeof (T));

		List<T> list = new List<T>();

		for (int i = 0; i < v.Length; i++)
		{
			list.Add((T)v.GetValue(i));
		}

		list.Remove(except);

		return list.GetRandom();
	}
	
	public static T RandomEnumValueExcept<T> (IEnumerable<T> except)
	{
		var v = Enum.GetValues (typeof (T));

		List<T> list = new List<T>();

		for (int i = 0; i < v.Length; i++)
		{
			var value = (T)v.GetValue(i);

			foreach (T e in except)
			{
				if (e.Equals(value))
				{
					continue;
				}
				
				list.Add(value);
			}
		}

		return list.GetRandom();
	}
}