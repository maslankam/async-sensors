using System.Threading.Tasks;

namespace dependencyInAction{
    public class SensorService{

        private ISensor sensor;

        public SensorService(ISensor sensor){
            this.sensor = sensor;
        }

        public string currnetLog(){
            ISensorResponse response = sensor.GetResponse();
            return formatResponse(response);
        }

        public async Task<string> currnetLogAsync(){
            ISensorResponse response = await sensor.GetResponseAsync();
            return formatResponse(response);
        }

        private string formatResponse(ISensorResponse response){
            return string.Format("{0} sensor: {1} reports: {2} {3}",
            response.getSubject(),
            sensor.getId(),
            response.getValue().ToString(),
            response.getUnit());
        }


    } 
}