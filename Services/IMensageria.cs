using NewsPub.Domain;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NewsPub.Services
{
    public interface IMensageria
    {
        public void Configuration(Solicitation solicitation);
        
    }
}
