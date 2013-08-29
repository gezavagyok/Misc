/**
 * ConsoleMarioStairs gets a number and prints 
 * a Super Mario-like stairs onto the console.
 * Since a standard console has 80 CPL, height
 * has a cap at 39. Too small height is invalid
 * as well.
 * @param towerHeight: whole number n: (2,39] .
 */
public void ConsoleMarioStairs(int towerHeight) 
{
	if ( towerHeight <= 2 || towerHeight > 39)
		return ;
		
	for (int i = 1; i <= towerHeight; i++)
	{
		int j = 0;
		for (; j < towerHeight - i; j++)
		{
			Console.Write(" ");
		}
		for (int g = 0; g < towerHeight - j + i; g++)
		{
			if (j + g == towerHeight)
			{
				Console.Write(" ");
			}
			Console.Write("#");
		}

		Console.Write("\n");
	}	
}