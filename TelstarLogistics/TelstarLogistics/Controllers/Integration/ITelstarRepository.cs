using TelstarLogistics.Models.ApiModel;

namespace TelstarLogistics.Controllers.Integration
{
    public interface ITelstarRepository
    {
        public List<City> GetCities();
        public List<Models.ApiModel.TelstarRoute> GetRoutes();
    }

}
