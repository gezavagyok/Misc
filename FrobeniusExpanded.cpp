/** 
 * Seven Eleven
 * A convenience store sells a gallon of milk for $7 and a loaf of
 * bread for $11. You are allowed to buy any combination of milk and 
 * bread, including only milk or only bread. Your total bill is 
 * always a whole number of dollars, but there are many whole numbers
 * that cannot be the total. For example, the total cannot be $15. 
 * What is the largest invalid bill?
 */
#include <iostream>

// since this problem is a simple formula of Frobenius, I want to
// print out all the invalid bills. (except the trivial ones)
const int MILK=3;
const int BREAD=5;

// after this, all number is possible, because A = x mod B used
// all the possible remainings.
const int SEARCH_RANGE=MILK*BREAD;

int main()
{
 // milk & loaf
 int A_number = MILK;
 int B_number = BREAD;
 
 // the possible sums are stored in this array.
 // the nth cell is true if n is a valid bill.
 bool number_line[SEARCH_RANGE] = { false };
 
 // some helper variable
 int runner1=0;
 int runner2=0;
 
 // first is the smaller
 int next_runner=(A_number>B_number)?B_number:A_number;

 while (next_runner < SEARCH_RANGE)
 {
	 while ( runner1 < SEARCH_RANGE )
	 {
		number_line[runner1] = true; 
		runner1+= A_number;
	 }

	 while( runner2 < SEARCH_RANGE )
	 {
		 number_line[runner2] = true;
		 runner2+= B_number;
	 }

	 // search until the next sum
	 while ( !number_line[++next_runner] ); 
	 
	 runner1 = runner2 = next_runner;
	
 }
 
 // printing out the results
 for(int i=(A_number>B_number)? B_number:A_number; i<SEARCH_RANGE;i++)
 {
	if(!number_line[i])
	{
		std::cout << i << " ";
	}
 }

 return 0;
}

