using DvdLibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibraryApi.Data
{
    public class RepositoryFactory
    {
        public static IMovieRepository GetMovieRepository()
        {
            IMovieRepository repo = null;

            switch (ConfigurationManager.AppSettings["MovieRepository"])
            {
                case null:
                    throw new NotImplementedException("No repository is specified.");

                default:
                    throw new NotImplementedException("Configured repository does not exist.");

                case "Test":
                    repo = new TestRepository();
                    break;

                case "Dapper":
                    repo = new DapperRepository();
                    break;
            }

            return repo;
        }
    }
}