namespace dependencyInAction{
    public class TemperatureResponse : ISensorResponse
    {
        private string subject;
        private string  unit;
        private double value;

        public TemperatureResponse(string unit, double value){
            this.subject = "temperature";
            this.unit = unit;
            this.value = value;
        }

        public TemperatureResponse(double value){
            this.subject = "temperature";
            this.unit = "celsius degree";
            this.value = value;
        }

        public string getSubject(){
            return subject;
        }

        public string getUnit(){
            return unit;
        }

        public double getValue(){
            return value;
        }
        
    }
}