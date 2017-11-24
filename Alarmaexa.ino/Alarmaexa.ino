#define Pecho 11
#define Ptrig 12

long duracion, distancia;
int incomingByte = 0;
int focoPin = 13;
bool flag = false;
int contra= 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(Pecho, INPUT);
  pinMode(Ptrig, OUTPUT);
  pinMode(focoPin, OUTPUT);
  digitalWrite(focoPin, LOW);
  incomingByte = Serial.read();
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(Ptrig, LOW);
  delayMicroseconds(2);
  digitalWrite(Ptrig, HIGH);
  delayMicroseconds(10);
  digitalWrite(Ptrig, LOW);

  duracion = pulseIn(Pecho, HIGH);
  distancia = (duracion/2) / 29;
  Serial.println(distancia);
  delay (500);
if (distancia <= 5  )
{  
     digitalWrite (focoPin,HIGH);
do
{
      contra = Serial.read();
      if (contra == '1' )
      {
        digitalWrite (focoPin,LOW);
      }
      
     
}
while (contra != '1');

}
     


}





