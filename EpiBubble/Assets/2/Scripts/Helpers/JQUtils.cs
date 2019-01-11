using UnityEngine;
using System.Collections;

namespace com.javierquevedo{
	
	public class JQUtils {

		public static T GetRandomEnum<T>()
			{	
	    		System.Array A = System.Enum.GetValues(typeof(T));
	    		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
	    		return V;
			}	
		
		public static Color ColorForBubbleColor(BubbleColor color){
		  switch (color){
			case BubbleColor.Black:
				return new Color(0.3f, 0.3f, 0.3f);
			case BubbleColor.Blue:
				return new Color(0.0f, 0.0f, 1.0f);
			case BubbleColor.Green:
				return new Color(0.0f, 1.0f, 0.0f);
			case BubbleColor.Red:
				return new Color(1.0f, 0.0f, 0.0f);
			case BubbleColor.White:
				return new Color(1.0f, 1.0f, 1.0f);
			case BubbleColor.Yellow:
				return new Color(1.0f, 1.0f, 0.0f);
			default:
				return new Color(0.0f, 1.0f, 1.0f);
			}
		}
		
		public static ArrayList FilterByColor(ArrayList bubbles, BubbleColor color){
			ArrayList filtered = new ArrayList();
			foreach (Bubble bubble in bubbles){
				if (bubble.color == color)
					filtered.Add(bubble);
				}
			return filtered;
		}
	}
}
