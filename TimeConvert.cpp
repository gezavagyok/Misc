/**
 * A function that converts a number into hh:mm
 */ 
std::string TimeConvert(int num) 
{ 
  int hours = num / 60;
  int minutes = num % 60;
  
  int d2= -1;					// 2nd digit of hours
  if ( hours > 9 ) {
    d2 = (hours % 10) + 48;		// set the 2nd digit first, because the hours modofies itself.
    hours = hours / 10 + 48;	// exploiting ascii -> '48' == 0
  } else {
    hours += 48;				// -  "  -
  }
  
  int d3= -1;
  if ( minutes > 9 ) {
    d3 = (minutes % 10) + 48;		// same as in case of hours.
    minutes = minutes / 10 + 48;
  } else {
    minutes += 48;
  }
  
  string r = "";			// assembling the return string
  r+= hours;				// hXXXX
  if(d2!=-1){
    r+=d2;					// hhXXX
  }
  
  r+=":";					// hh:XX
  
  r+= minutes;				// hh:mX
  if(d3!=-1){
    r+=d3;					// hh:mm
  }
  
  return r; 
            
}
