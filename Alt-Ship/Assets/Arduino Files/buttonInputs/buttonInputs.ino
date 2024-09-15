int button1 = 12;

int gunLED = 11;

int healthLED1 = 5;
int healthLED2 = 6;
int healthLED3 = 7;

void setup() {

  Serial.begin(9600);
  delay(1000);
  // put your setup code here, to run once:
  pinMode(button1, INPUT_PULLUP);
  pinMode(gunLED, OUTPUT);

  pinMode(healthLED1, OUTPUT);
  pinMode(healthLED2, OUTPUT);
  pinMode(healthLED3, OUTPUT);  

  
}

void loop() {
  // put your main code here, to run repeatedly:

  
  
  if(digitalRead(button1) == LOW)
    {
    Serial.println("shoot");
    }
    else
    {
      Serial.println("dontShoot");
    }


    char untiyOutput = Serial.read();
    if (untiyOutput == 'n')
    {
      digitalWrite(gunLED, HIGH);
    }
    else if (untiyOutput == 'f')
    {
      digitalWrite(gunLED, LOW);
    }



    if (untiyOutput == '2'){
      digitalWrite(healthLED3, LOW);
    }
    else if (untiyOutput == '1'){
      digitalWrite(healthLED2, LOW);
    }
    else if (untiyOutput == '0'){
      digitalWrite(healthLED1, LOW);
    }
    else if (untiyOutput == '3'){
      digitalWrite(healthLED1, HIGH);
      digitalWrite(healthLED2, HIGH);
      digitalWrite(healthLED3, HIGH);
    }


    
  
  

}
