//www.elegoo.com
//2016.12.08
#include "SR04.h"   //Degining the Ultra Sonic Sensor Libarry
#define TRIG_PINy 12
#define ECHO_PINy 11
SR04 sensoryY = SR04(ECHO_PINy,TRIG_PINy);
long y;

#define TRIG_PINx 8
#define ECHO_PINx 9
SR04 sensoryX = SR04(ECHO_PINx,TRIG_PINx);
long x;


int buttonApin = 7; 



void setup() {  
  Serial.begin(9600);
  delay(1000);
  
  pinMode(buttonApin,INPUT_PULLUP);
   
}

void loop() {

   if (digitalRead(buttonApin) == LOW){
    Serial.println("On");
   }
   
   x=sensoryX.Distance();
   Serial.print(x);
   Serial.println("X");
   delay(1);
   
   y=sensoryY.Distance();
   Serial.print(y);
   Serial.println("Y");
   delay(1);

   
}
