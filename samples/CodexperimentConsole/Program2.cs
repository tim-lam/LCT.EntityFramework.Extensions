
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Threading;
using BusinessLogic.Services;
using DAL.StepsContext;
using POCO;

namespace CodexperimentConsole
{
    internal class Program2
    {
        private static void Main(string[] args)
        {

            var country1 = new Country
            {
                Id = 6,
                CountryCode = "MX",
                Name = "Mexicodddddd123",
                States = new[]
                {
                    new State //Child entity (with key value)

                    {
                        CountryId = 6,
                        StateCode = "mx",
                        Name = "MX123"
                    },
                    new State
                    {
                        CountryId = 6,
                        StateCode = "m2",
                        Name = "m2"
                    }
                }
            };
            //var ctx  = new StepsContext(ConfigurationManager.ConnectionStrings["StepsContext"].ConnectionString);

            //ctx.Countries.Attach(country1);
            //ctx.SaveChanges();
            using (var uow = new UnitOfWork())
            {
                uow.Delete(country1);
               var a=  uow.Save();

            }

           
          
            using (var uow = new UnitOfWork())
            {
                var svcBase = new ServiceBase<Country>(uow);
                {
                    var cn = new Country
                    {
                        CountryCode = "PRC",
                        Name = "China",
                        States = new List<State>
                        {
                            new State
                            {
                                Id = 7,
                                StateCode = "HH",
                                Name = "Hong Koniiig"
                            },
                            new State
                            {
                                StateCode = "MC",
                                Name = "Mocow"
                            }
                        }
                    };

                    svcBase.AddOrUpdate(cn);
                    var reocordsAffected = uow.Save();
                }
            }
        }
    }
}
