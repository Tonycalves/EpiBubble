using UnityEngine;
using System.Collections;

namespace com.javierquevedo{
	
	public class JQMath {
		
		public static int TruncateToInterval(int number, int min, int max){
			int outcome;
			outcome = number;
			if (number < min) outcome = min;
			if (number > max) outcome = max;
			return outcome;
		}
		
	}
}
