/**
 *	swaps two values a and b.
 */
private void swap(ref int a, ref int b) {
	int tmp = a;
	a=b;
	b=tmp;
}

/**
 *	Bubble sort
 * an easy to learn algorithm, but it takes more time to 
 * sort especially if the array has 1000+ elements.
 */
public void bubbleSort(ref int[] arr){													// ref: i can change the values of this array if i put this word before the type
	bool areValuesSwapped = true;														// the algorithm stops when no swaps were made, thus areValuesSwapped==false means no swaps were made by the for loop.
	while (areValuesSwapped ) {															// while it's possible to swap, we should run this over and over again
		areValuesSwapped = false;														// let's say, we can't make any more swaps.
		for(int targatCell = 0; targetCell+1 < arr.Length; targetCell++) {	// we check every cell in the array
			if(arr[targetCell] > arr[targetCell+1]) {									// indexing the targetCell and the next. if the target is greater than the following cell
				swap(ref arr[targetCell] ,ref arr[targetCell]);						// we swap these Cells.
				areValuesSwapped = true;												// and admit there were at least a swap.
			}
		}
	}
}

/**
 * it looks like this:
 * ...	arr[targetCell]	arr[targetCell+1]	arr[targetCell+2]	... < indexed cells of the array (aka we are in the first block)
 *	...	  [ 1023 ]				[ 1000 ]				[ 999 ]				... < value of the indexed cell
 * so the targetCell -th and the next cell isn't in order -> swap
 * after the swap:
 *		[1000]	[1023]	[999]
 * we set the areValuesSwapped to true because it just happened...
 * the for loop is increased in the end of the loop
 * now it looks like this:
 * ...	arr[targetCell-1]	arr[targetCell]	arr[targetCell+1]	... < indexed cells of the array (aka we are in the middle block)
 *	...	  [ 1000 ]				[ 1023 ]				[ 999 ]				... < value of the indexed cell
 * so the loop checks again the targetCell and the targetCell+1-> they are not oredered -> swap
 * after the swap:
 *		[1000]	 [999]	[1023]
 * we set the areValuesSwapped to true because it just happened...
 * the for loop is finished, but the array hasn't been sorted yet.
 * thats why we need the while loop, we start "running" from the first cell again:
 * ...	arr[targetCell]	arr[targetCell+1]	arr[targetCell+2]	... < indexed cells of the array (aka we are in the first block)
 *	...	  [ 1000 ]	[ 999 ]	[ 1023 ]				... < value of the indexed cell
 * and after a swap, we finally sorted the array.
 *   [999]	[1000]	[1023]
 */
 